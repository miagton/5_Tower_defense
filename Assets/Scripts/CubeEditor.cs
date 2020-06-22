using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(WayPoint))]
public class CubeEditor : MonoBehaviour
{   
   

    
  
    WayPoint wayPoint;

    private void Awake()
    {
      
        wayPoint = GetComponent<WayPoint>();


    }

    void Update()
    {
        SnapToGrid();

        UpdateLabel();
    }

    private void SnapToGrid()
    {
       // int gridSize = wayPoint.GetGridSize();
        
        transform.position = new Vector3(
            wayPoint.GetGridPos().x,
            0,
            wayPoint.GetGridPos().y
            );
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        int gridSize = wayPoint.GetGridSize();
        string labelText = wayPoint.GetGridPos().x / gridSize + "," + wayPoint.GetGridPos().y / gridSize;//label  to get not exact coordinates but proper label
        textMesh.text = labelText;
        gameObject.name = labelText;
    }

}
