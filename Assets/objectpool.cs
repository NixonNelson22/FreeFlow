using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "gridData", menuName = "gridData" )]
public class objectPool : ScriptableObject
{
    public List<ObjectData> objectsData;
    
    

}
[Serializable]
public class ObjectData
{
    // [field:SerializeField]
    // public int ID {get; private set;}

    [field:SerializeField]
    public Vector3 Position {get; private set;}
    
    [field:SerializeField]
    public Color Color {get; private set;}
    
    
    [field:SerializeField]
    public GameObject Prefab {get; private set;}

}
