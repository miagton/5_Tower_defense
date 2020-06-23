using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   

    [Tooltip("Time between each move")]
    [SerializeField] float dwellingTime = 1f; 

    void Start()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
         StartCoroutine(FollowPath(path));
    }

   

    IEnumerator FollowPath(List<WayPoint> path)
    {
            print("Starting patrol!");
       
        foreach (WayPoint block in path)
        {
            transform.position = block.transform.position;
            
            yield return new WaitForSeconds(dwellingTime);
        }
            print("Walking finished!");
    }
}
