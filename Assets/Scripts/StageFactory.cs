using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFactory : MonoBehaviour
{
    [SerializeField]
    GameObject _stageRowPrefab;
    [SerializeField]
    Vector3 _stageRowSpawnPoint;

    GameObject stageRow;

    public void SetUpStage(StageScriptableObject stageSO)
    {
        if(stageRow == null){
            int paddingY = 0;
            foreach(RowScriptableObject row in stageSO.rows)
            {
                stageRow = Instantiate(_stageRowPrefab, _stageRowSpawnPoint, Quaternion.identity, gameObject.transform);
                foreach(GameObject obstacle in row.Obstacles){
                    GameObject instantiatedObstacle = Instantiate(obstacle, stageRow.transform);
                    instantiatedObstacle.GetComponent<ObstaclesController>().SetUp();
                }
                stageRow.transform.position = new Vector3(stageRow.transform.position.x, stageRow.transform.position.y - (paddingY*1.93f), stageRow.transform.position.z);
                paddingY++;
            }
        }        
    }
}
