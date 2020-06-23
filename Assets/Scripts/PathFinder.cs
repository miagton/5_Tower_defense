using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] WayPoint start , end;
   
    Dictionary<Vector2Int, WayPoint> worldGrid = new Dictionary<Vector2Int, WayPoint>();

    

    private void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
    }

    private void ColorStartAndEnd()
    {
        start.SetTopColor(Color.blue);
        end.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<WayPoint>();
        foreach(WayPoint wayPoint in waypoints)
        {
            var gridPos = wayPoint.GetGridPos();
           
            if (worldGrid.ContainsKey(gridPos)) { Debug.Log("Skipping overlapping block: " + wayPoint); }
            
            else
            { 
                worldGrid.Add(gridPos, wayPoint);
               // if(wayPoint== start) { wayPoint.SetTopColor(Color.magenta); }
               // if (wayPoint == end) { wayPoint.SetTopColor(Color.blue); }
              
            } 
        }
        
    }
}
