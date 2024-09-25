using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    bool _isVictorious = false;
    int _roomsCleared = 0;
    [SerializeField]
    ViewController _viewController;
    
    public bool IsVictorious()
    {
        return _isVictorious;
    }

    public void ResetGame()
    {
        _roomsCleared = 0;
    }

    public int RoomsCleared()
    {
        return _roomsCleared;
    }

    public void LevelCompleted()
    {
        _isVictorious = true;
        _roomsCleared++;
        EndGame();
    }

    public void PlayerHit()
    {
        _isVictorious = false;
        EndGame();
    }

    private void EndGame()
    {
        _viewController.GoToResults();
    }
}
