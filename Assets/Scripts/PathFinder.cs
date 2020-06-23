using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] WayPoint startPoint , endPoint;
   
    Dictionary<Vector2Int, WayPoint> worldGrid = new Dictionary<Vector2Int, WayPoint>();
    Queue<WayPoint> queue = new Queue<WayPoint>();
    
    bool isRunning = true;
    WayPoint searchCenter;//to track current search center

    Vector2Int[] directions =

    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,
    };


    private void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        PathFind();
       
    }

    private void PathFind()
    {
        queue.Enqueue(startPoint);
        while(queue.Count > 0&& isRunning)
        {
            searchCenter =queue.Dequeue();
            searchCenter.isExplored = true;
            
            StopIfEndFounded();
            ExploreNearBlocks();
        }
        //todo make up path
        print("finish pathfinding?");
    }

    private void StopIfEndFounded()
    {
        if(searchCenter== endPoint)
        {
           
            isRunning = false;
        }
    }

    private void ExploreNearBlocks()
    {
        if (!isRunning){ return; }
        foreach(var direction in directions)
        {
            Vector2Int explorationCoordinates = searchCenter.GetGridPos() + direction;
            try
            {
                QueueNewMember(explorationCoordinates);
            }
            catch
            {
                //donothing
            }
           
        }
    }

    private void QueueNewMember(Vector2Int explorationCoordinates)
    {
        WayPoint neighbour = worldGrid[explorationCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            
            //slip this block > do nothing
        }
        else
        {
           
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }

    private void ColorStartAndEnd()
    {
        startPoint.SetTopColor(Color.blue);
        endPoint.SetTopColor(Color.red);
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
