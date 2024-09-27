using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Class to control Game Loop and to store Game Information
public class GameController : MonoBehaviour
{
    const int COUNTDOWN_VALUE = 3;

    //Should be true if the Player reaches the end of the last Row
    bool _isVictorious = false;
    //Should be increased after each row completed and should be zero when starting a new run
    int _rowsCleared = 0;
    GameView _gameView;

    [SerializeField]
    ViewController _viewController;

    //Stage is set here as the only stage to be played as of yet
    [SerializeField]
    StageScriptableObject _stage;    
    [SerializeField]
    StageFactory _stageFactory;

    public void AssignGameView(GameView gameView) => _gameView = gameView;

    void Start(){
        _viewController.Initiate();
        AudioSingleton.Instance.TriggerThemeAudio();
        _viewController.GoToMainMenu(); 
    }
    
    public bool IsVictorious()
    {
        return _isVictorious;
    }

    //Method called to reset Game information
    public void ResetGame()
    {
        _rowsCleared = 0;
        _gameView.UpdateScoreText(_rowsCleared);
    }

    public int RowsCleared()
    {
        return _rowsCleared;
    }

    // Method called when a Row is completed
    public void RowCompleted()
    {
        _rowsCleared++;
        //If all rows are completed, call End Game
        if(_rowsCleared == _stage.rows.Count){
            _isVictorious = true;
            EndGame();
        }else
        {
            //If there are still rows available, send player to next row
            _gameView.UpdateScoreText(_rowsCleared);
            NextRow();
        }        
    }

    //Method called when Player is hit
    //Current implementation send player to Results View with failure
    public void PlayerHit()
    {
        _isVictorious = false;
        EndGame();
    }

    //Method to send Player to Results View
    private void EndGame()
    {
        _viewController.GoToResults();
    }

    //Method which calls StageFactory to instantiate the stage to be played
    public void CreateStage()
    {
        _stageFactory.CreateStage(_stage, _gameView.gameObject);
    }

    //Method to send Player to the next Row
    void NextRow()
    {
         _gameView.GetPlayer().transform.position = _gameView.StartPosition() - new Vector3(0f, Constants.NextRowHeight, 0f);
    }

    //Coroutine to call when starting the Game View, so as to hold the Player for a Countdown before the character starts running
    public IEnumerator WaitBeforeStart(Text timerText){
         _gameView.GetPlayer().TurnActive(false);
         AudioSingleton.Instance.TriggerCountdownAudio();

        for(int i = COUNTDOWN_VALUE; i > 0; i--)
        {
            timerText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        timerText.text = "";
        _gameView.GetPlayer().TurnActive(true);
    }
}
