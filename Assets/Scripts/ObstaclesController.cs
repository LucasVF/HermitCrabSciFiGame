using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to attach to Obstacles, which are situated at Rows
public class ObstaclesController : MonoBehaviour
{
    GameController _gameController;

    //SetUp can be done in order to move the position of the obstacle when setting up each row
    public void SetUp(int paddingX = 0, int paddingY = 0, int paddingz = 0)
    {
        transform.position = new Vector3(transform.position.x + paddingX, transform.position.y + paddingY, transform.position.z+  + paddingz);
    }

    //When a Player collides with Obstacle, it informs the GameController the player was hit
    void OnCollisionEnter2D(Collision2D collision) 
    { 
        if(_gameController == null){
            _gameController = GameObject.FindGameObjectWithTag(Constants.GameControllerTag).GetComponent<GameController>();
        }
        _gameController.PlayerHit();
    }
}
