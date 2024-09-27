using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to attach to Objective GameObject
//Objective GameObject should contain a Collider2D
public class ObjectiveController : MonoBehaviour
{
    GameController _gameController;

    //If player collides with Objective, it informs Game Controller that the Row is Completed
    //Current implementation takes into account that Objective and Obstacles cannot collide with each other, only the player can collide with objective, as such, there is no need to confirm that the other element is the player
    void OnCollisionEnter2D(Collision2D collision) 
    { 
        if(_gameController == null){
            _gameController = GameObject.FindGameObjectWithTag(Constants.GameControllerTag).GetComponent<GameController>();
        }
        _gameController.RowCompleted();
    }
}
