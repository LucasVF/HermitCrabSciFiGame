using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.UI;
using UnityEngine;

public class GameView : BaseView
{
    public override ViewNames GetName() => ViewNames.Game;

    [SerializeField]
    Vector3 _startPostion;
    [SerializeField]
    Transform _playerTransform;
    
    public override void SetUpView()
    {
        _playerTransform.position = _startPostion;
    }
}