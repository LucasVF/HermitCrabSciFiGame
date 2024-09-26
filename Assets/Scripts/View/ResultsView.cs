using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsView : BaseView
{
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
    
    public override void SetUpView()
    {
        if(_gameController == null){
            _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        }
        bool isVictorious = _gameController.IsVictorious();
        _mainResultText.text = isVictorious ? "Pass":"Failure";
        _scoreText.text = "Rooms Cleared: "+_gameController.RoomsCleared();
        _retryButtonText.text = isVictorious ? "Play Again":"Retry";
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
