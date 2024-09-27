using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ScriptableObject created to fufill Row configuration for use on multiple Stages
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RowScriptableObject", order = 2)]
public class RowScriptableObject : ScriptableObject
{
    public List<GameObject> Obstacles;
}
