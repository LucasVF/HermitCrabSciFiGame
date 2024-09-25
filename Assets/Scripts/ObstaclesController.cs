using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    GameController _gameController;

    void OnCollisionEnter2D(Collision2D collision) 
    { 
        if(_gameController == null){
            _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        }
        _gameController.PlayerHit();
    }
}
