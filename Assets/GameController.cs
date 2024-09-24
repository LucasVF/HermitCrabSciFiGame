using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    bool _isVictorious = false;
    
    public bool IsVictorious(){
        return _isVictorious;
    }
    public int RoomsCleared(){
        return 0;
    }
}
