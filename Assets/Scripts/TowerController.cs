﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [Tooltip("Range on wich Tower attacks")]
    [SerializeField] float towerRange = 30f;
    
    [SerializeField] Transform objectToSpin;
    [SerializeField] Transform objToLookAt;
    [SerializeField] GameObject gun;

    void Update()
    {
        
        AttackEnemy();
    }

    private void AttackEnemy()
    {
        if (objToLookAt == null)
        {
            EnableEmission(false);
            return;
        }
        if(Vector3.Distance(transform.position,objToLookAt.position)<= towerRange)
        {
            objectToSpin.LookAt(objToLookAt);
            EnableEmission(true);
        }
        else 
        {
            EnableEmission(false);
        }
    }

    private void EnableEmission(bool IsActive)
    {
       
        var gunEmmision = gun.GetComponent<ParticleSystem>().emission;
        gunEmmision.enabled = IsActive;
    }
}
