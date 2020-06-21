using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<WayPoint> path;

    [Tooltip("Time between each move")]
    [SerializeField] float dwellingTime = 1f; 

    void Start()
    {
        StartCoroutine(FollowPath());
    }

   

    IEnumerator FollowPath()
    {
            print("Starting patrol!");
       
        foreach (var block in path)
        {
            transform.position = block.transform.position;
            print("visiting block : " + block.name);
            yield return new WaitForSeconds(dwellingTime);
        }
            print("Walking finished!");
    }
}
