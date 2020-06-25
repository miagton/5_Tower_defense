using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   

    [Tooltip("Time between each move")]
    [SerializeField] float dwellingTime = 1f;

    [SerializeField] GameObject hitEffect = null;
    [SerializeField] GameObject deathEffect = null;
    [SerializeField] int hitsToDie = 6;
    
    Transform parent;
    Vector3 startPosition;

    void Start()
    {
         parent = FindObjectOfType<Parent>().transform;
         startPosition = transform.position;
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

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitsToDie <= 0)
        {
            ProccesDeath();
        }
    }

    private void ProcessHit()
    {
        if (hitEffect != null)
        {
            GameObject fx1 = Instantiate(hitEffect, transform.position, Quaternion.identity);
            fx1.transform.parent = parent;
        }
        hitsToDie--;
       
    }
    private void ProccesDeath()
    {
        if (deathEffect != null)
        {
            GameObject fx2 = Instantiate(deathEffect, transform.position, Quaternion.identity);
            fx2.transform.parent = parent;
        }
        Destroy(gameObject);
    }

   
}
