using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//View responsible for Setting Up Gameplay View
public class GameView : BaseView
{
    public override ViewNames GetName() => ViewNames.Game;

    //Where the player will start each Stage
    [SerializeField]
    Vector3 _startPostion;
    [SerializeField]
    PlayerController _player;

    [SerializeField]
    Text _timerText;
    [SerializeField]
    Text _scoreText;

    GameController _gameController;

    public Vector3 StartPosition() => _startPostion;
    public PlayerController GetPlayer() => _player;

    //Method that sets up the game View, positioning the player at start position and calling Game Controller to create the Stage and reset Game Info
    public override void SetUpView()
    {
        if(_gameController == null){
            _gameController = GameObject.FindGameObjectWithTag(Constants.GameControllerTag).GetComponent<GameController>();
            _gameController.AssignGameView(this);
        }
        _gameController.ResetGame();        
        _player.transform.position = _startPostion;
        _gameController.CreateStage();
    }

    //Method to update Score Text
    public void UpdateScoreText(int rowCompleted)
    {
        _scoreText.text = Constants.ScoreText + rowCompleted;
    }

    //When Game View is enabled, Game Controller is called to initiate Countdown before game starts
    void OnEnable()
    {  
        StartCoroutine(_gameController.WaitBeforeStart(_timerText));
    }   
}