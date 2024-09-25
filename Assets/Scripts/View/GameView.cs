using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.UI;
using UnityEngine;
using UnityEngine.UI;

public class GameView : BaseView
{
    public override ViewNames GetName() => ViewNames.Game;

    [SerializeField]
    Vector3 _startPostion;
    [SerializeField]
    PlayerController _player;

    [SerializeField]
    Text _timerText;
    [SerializeField]
    Text _scoreText;

    GameController _gameController;

    public override void SetUpView()
    {
        if(_gameController == null){
            _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        }
        _gameController.ResetGame();
        _scoreText.text = "Rooms Cleared: "+_gameController.RoomsCleared();
        _player.transform.position = _startPostion;
    }

    void OnEnable()
    {        
        StartCoroutine(WaitBeforeStart());
    }

    private IEnumerator WaitBeforeStart(){
         _player.TurnActive(false);
         _timerText.text = "3";
        yield return new WaitForSeconds(1f);
        _timerText.text = "2";
        yield return new WaitForSeconds(1f);
        _timerText.text = "1";
        yield return new WaitForSeconds(1f);
        _timerText.text = "";
        _player.TurnActive(true);
    }
}