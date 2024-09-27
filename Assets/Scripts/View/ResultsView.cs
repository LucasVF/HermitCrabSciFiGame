using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//View class responsible for displaying Results for the Game
public class ResultsView : BaseView
{
    const string VICTORY_TEXT = "Pass";
    const string FAILURE_TEXT = "Failure";
    const string VICTORY_BUTTON_TEXT = "Play Again";
    const string FAILURE_BUTTON_TEXT = "Retry";

    public override ViewNames GetName() => ViewNames.Results;

    [SerializeField]
    Text _mainResultText;
    [SerializeField]
    Text _scoreText;
    [SerializeField]
    Text _retryButtonText;
    [SerializeField]
    Outline _outlineMainResultText;
    [SerializeField]
    GameObject _victoriousImage;
    [SerializeField]
    GameObject _loserImage;

    GameController _gameController;
    
    //Sets up Results view depending on Victory of Failure of previous Game run.
    public override void SetUpView()
    {
        if(_gameController == null){
            _gameController = GameObject.FindGameObjectWithTag(Constants.GameControllerTag).GetComponent<GameController>();
        }
        bool isVictorious = _gameController.IsVictorious();
        _mainResultText.text = isVictorious ? VICTORY_TEXT : FAILURE_TEXT;
        _scoreText.text = Constants.ScoreText + _gameController.RowsCleared();
        _retryButtonText.text = isVictorious ? VICTORY_BUTTON_TEXT : FAILURE_BUTTON_TEXT;
        _outlineMainResultText.effectColor = isVictorious ? Color.green : Color.red;
        _victoriousImage.SetActive(isVictorious);
        _loserImage.SetActive(!isVictorious);
        if(isVictorious)
        {
            AudioSingleton.Instance.TriggerSuccessAudio();
        }else
        {
            AudioSingleton.Instance.TriggerFailureAudio();
        }
    }
}
