using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Factory class to instantiate each Stage
public class StageFactory : MonoBehaviour
{
    //Prefab that is the base of all rows
    [SerializeField]
    GameObject _stageRowPrefab;
    //Vector3 to inform where the Stages will start spawning from
    [SerializeField]
    Vector3 _stageRowSpawnPoint;

    GameObject stageRow;

    //Method to create a stage based on information inside a StageScriptableObject
    //Current implementation only accounts for 1 stage
    //TODO: Implement a pooling system for Stages and Rows
    public void CreateStage(StageScriptableObject stageSO, GameObject parent)
    {
        //If stage is not created, create the stage
        if(stageRow == null){
            int paddingY = 0;
            //Instantiate each Row
            foreach(RowScriptableObject row in stageSO.rows)
            {
                stageRow = Instantiate(_stageRowPrefab, _stageRowSpawnPoint, Quaternion.identity, parent.transform);
                //Instantiate each Obstacle
                foreach(GameObject obstacle in row.Obstacles){
                    GameObject instantiatedObstacle = Instantiate(obstacle, stageRow.transform);
                    instantiatedObstacle.GetComponent<ObstaclesController>().SetUp();
                }
                //Move the instantiated Row to below the previous Row
                stageRow.transform.position = new Vector3(stageRow.transform.position.x, stageRow.transform.position.y - (paddingY * Constants.NextRowHeight), stageRow.transform.position.z);
                paddingY++;
            }
        }        
    }
}
