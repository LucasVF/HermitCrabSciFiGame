using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RowScriptableObject", order = 2)]
public class RowScriptableObject : ScriptableObject
{
    public List<GameObject> Obstacles;
}
