using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StageScriptableObject", order = 1)]
public class StageScriptableObject : ScriptableObject
{
    public int id;
    public List<RowScriptableObject> rows;
    public float speedIncreasePerRowCompleted;
}