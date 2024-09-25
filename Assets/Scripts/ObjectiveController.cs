using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{
    GameController _gameController;

    void OnCollisionEnter2D(Collision2D collision) 
    { 
        if(_gameController == null){
            _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        }
        _gameController.RoomCompleted();
    }
}
