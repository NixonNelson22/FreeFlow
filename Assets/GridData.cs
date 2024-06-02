using System.IO;
using UnityEngine;

public class GridData : MonoBehaviour
{
    
//   File.WriteAllText(Application.dataPath+"/save.txt","test"); 
    private objectPool objectPool;
    private Grid grid;
    
    void Start()
    {
        grid = GetComponent<Grid>();
        PlaceObjects();
    }
    public void PlaceObjects(){
        objectPool.objectsData.ForEach(delegate(ObjectData objectData){
            Vector3Int cellPosition = grid.WorldToCell(objectData.Position);
            Instantiate(objectData.Prefab,grid.GetCellCenterWorld(cellPosition),Quaternion.identity);
        });
        
    }
   
}