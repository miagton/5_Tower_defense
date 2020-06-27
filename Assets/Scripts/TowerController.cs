using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
   //parametrs
    [Tooltip("Range on wich Tower attacks")]
    [SerializeField] float towerRange = 30f;
    [SerializeField] Transform objectToSpin;
    [SerializeField] GameObject[] guns;
    //state
    Transform targetEnemy;

    public TowerHolder baseHolder;//what the tower is tsanding on
    void Update()
    {
        SetTargetEnemy();
        AttackEnemy();
    }

    private void SetTargetEnemy()
    {
        var allEnemies = FindObjectsOfType<Enemy>();
        if (allEnemies.Length == 0) { return; }

        Transform closestEnemy = allEnemies[0].transform;

        foreach(Enemy testEnemy in allEnemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;

        
    }

    private Transform GetClosestEnemy(Transform transformA, Transform transformB)
       
    {
        float distanceA = Vector3.Distance(transform.position, transformA.position);
        float distanceB= Vector3.Distance(transform.position, transformB.position);
        if (distanceA > distanceB){ return transformB;}
        else { return transformA; }
    }

    private void AttackEnemy()
    {

        if (targetEnemy)
        {
            
            ShootAtEnemy();
        }
       else if (targetEnemy == null)
        {
            EnableEmission(false);
           // return;
        }
       
    }

    private void ShootAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(transform.position, targetEnemy.position);
        if (distanceToEnemy <= towerRange)
        {
            objectToSpin.LookAt(targetEnemy.position+Vector3.up*2);
            EnableEmission(true);

        }
        else
        {
            EnableEmission(false);
        }
    }

    private void EnableEmission(bool IsActive)
    {
       
       foreach(var gun in guns)
        {
        var gunEmmision = gun.GetComponent<ParticleSystem>().emission;
        gunEmmision.enabled = IsActive;

        }
    }
}
