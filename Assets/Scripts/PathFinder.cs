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
    List<WayPoint> path = new List<WayPoint>() ;
    bool isRunning = true;
    WayPoint searchCenter;//to track current search center

   // bool pathCreated = false;
    Vector2Int[] directions =

    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,
    };
    public List<WayPoint> GetPath()
    {
        if (path.Count==0) 
     
        {
            LoadBlocks();
           
            BreadthFirstSearch();
            FormPath();
        }
            return path;
       
    }

    

    private void FormPath()
    {
        path.Add(endPoint);
        WayPoint previous = endPoint.exploredFrom;
        while(previous!= startPoint)
        {
            //add intermediate waypoint
            path.Add(previous);
            previous = previous.exploredFrom;
        }
       
        path.Add(startPoint);
       
        path.Reverse();
       // pathCreated = true;
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startPoint);
        while(queue.Count > 0&& isRunning)
        {
            searchCenter =queue.Dequeue();
            searchCenter.isExplored = true;
            
            StopIfEndFounded();
            ExploreNearBlocks();
        }
       
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
            if(worldGrid.ContainsKey(explorationCoordinates))
            {
                QueueNewMember(explorationCoordinates);
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
               
              
            } 
        }
        
    }
    
}
