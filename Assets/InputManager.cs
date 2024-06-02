using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
	private Camera sceneCamera;
	private Vector3 lastPosition;

	[SerializeField]
	private LayerMask placementLayermask;
    public event Action OnCircle,OnClicked, OnExit;
    private Vector3 mousePos;
	[SerializeField]
	private GameObject mouseIndicator;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        
    }
    
	private void Update(){
        Ray ray = sceneCamera.ScreenPointToRay(mousePos);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit, 100,placementLayermask))
		{
			if (hit.collider.gameObject.name == "Circle")
            {
                OnCircle?.Invoke();
            }
		}
		if(Input.GetMouseButtonDown(0)){
			OnClicked?.Invoke();
		}
		if(Input.GetKeyDown(KeyCode.Escape)){
			OnExit?.Invoke();
		}
	
	}

   public Vector3 getDraggedPosition()
	{
		mousePos = Input.mousePosition;
		mousePos.z = sceneCamera.nearClipPlane;
		Ray ray = sceneCamera.ScreenPointToRay(mousePos);
		Debug.DrawLine(mousePos,Vector3.forward,Color.red);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit, 100,placementLayermask))
		{
			lastPosition = hit.point;
			mouseIndicator.transform.position = lastPosition;
		}
		return lastPosition;
	}
}
