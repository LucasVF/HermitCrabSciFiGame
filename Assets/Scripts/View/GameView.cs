using System.Collections;
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

    [SerializeField]
    StageScriptableObject _stage;
    [SerializeField]
    StageFactory _stageFactory;

    GameController _gameController;
    int _roomsCleared = -1;

    public override void SetUpView()
    {
        if(_gameController == null){
            _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        }
        _gameController.ResetGame();        
        _player.transform.position = _startPostion;
        _stageFactory.SetUpStage(_stage);
    }

    void Update()
    {
        if(_gameController != null && _roomsCleared != _gameController.RoomsCleared())
        {
            _roomsCleared = _gameController.RoomsCleared();
            _scoreText.text = "Rooms Cleared: "+_roomsCleared;
        }        
    }

    public int CountRooms()
    {
        return _stage.rows.Count;
    }
    
    public void NextRoom()
    {
         _player.transform.position = _startPostion - new Vector3(0f,1.93f,0f);
    }

    void OnEnable()
    {        
        StartCoroutine(WaitBeforeStart());
    }

    private IEnumerator WaitBeforeStart(){
         _player.TurnActive(false);
         AudioSingleton.Instance.TriggerCountdownAudio();
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