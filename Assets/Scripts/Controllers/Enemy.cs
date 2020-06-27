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

    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip deathSound;

    AudioSource audioSource;
    Transform parent;
    Vector3 startPosition;
    bool pathCompleted = false;

    void Start()
    {
         audioSource = GetComponent<AudioSource>();
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
        pathCompleted = true;
        SelfDestroy();

        
            
    }

    private void SelfDestroy()
    {
        if (endEffect != null&& pathCompleted)
        {
            CreateEffect(endEffect);
            Destroy(this.gameObject);
        }
        else
        {
            ProccesDeath();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitsToDie <= 0)
        {
            SelfDestroy();
           
        }
    }
   

    private void ProcessHit()
    {
        hitsToDie--;
        audioSource.PlayOneShot(hitSound);
        if (hitEffect != null)
        {
            
            CreateEffect(hitEffect);
        }
       
    }
    private void ProccesDeath()
    {
       // audioSource.PlayOneShot(deathSound);
        
        if (deathEffect != null)
        {
           
            CreateEffect(deathEffect);
        }
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position);
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
