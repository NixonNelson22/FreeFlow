using UnityEngine;

public class flowcode : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;
    [SerializeField]
    private GameObject gameObject;
    private GridData gridData;
    [SerializeField]
    private Grid grid;
    [SerializeField]
    private InputManager inputManager;

    void Start()
    {
        grid = GetComponent<Grid>();
        inputManager.OnCircle += StartFlow;
        inputManager.OnClicked += DisplayFlow;
        //level 1 Data load 
        
        
    }
    private void StartFlow(){
        Vector3 PrefabPosition = grid.WorldToCell(gameObject.transform.position);   
        lineRenderer.SetPosition(0,PrefabPosition);// initial position of the flow
    }
    
    private void DisplayFlow(){
        
        lineRenderer.positionCount++;
        Vector3 mousePosition = inputManager.getDraggedPosition();
        Vector3 mousePosGrid = grid.WorldToCell(mousePosition);
        lineRenderer.SetPosition(lineRenderer.positionCount-1, mousePosGrid);       
        
    }

    void Update()
    {
        
    }
}
