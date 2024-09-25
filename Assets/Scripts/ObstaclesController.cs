using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    GameController _gameController;

    public void SetUp(int paddingX = 0, int paddingY = 0, int paddingz = 0)
    {
        transform.position = new Vector3(transform.position.x + paddingX, transform.position.y + paddingY, transform.position.z+  + paddingz);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    { 
        if(_gameController == null){
            _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        }
        _gameController.PlayerHit();
    }
}
