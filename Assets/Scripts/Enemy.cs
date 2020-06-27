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

    [SerializeField] GameObject endEffect = null;

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
            
       
        foreach (WayPoint block in path)
        {
            transform.position = block.transform.position;
            
            yield return new WaitForSeconds(dwellingTime);
        }
        SelfDestroy();

        
            
    }

    private void SelfDestroy()
    {
        if (endEffect != null)
        {
            GameObject fx = Instantiate(endEffect, transform.position, Quaternion.identity);
            fx.transform.parent = parent;
        }
        Destroy(this.gameObject);
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
        hitsToDie--;
        if (hitEffect != null)
        {
            
            CreateEffect(hitEffect);
        }
       
    }
    private void ProccesDeath()
    {
        if (deathEffect != null)
        {
           
            CreateEffect(deathEffect);
        }
         Destroy(gameObject);
       // ResetEnemy();
    }

   void CreateEffect(GameObject effect)
    {
        GameObject fx = Instantiate(effect, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
       
    }

    IEnumerator ResetEnemy()
    {
        transform.position = startPosition;
        gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(true);
    }
}
