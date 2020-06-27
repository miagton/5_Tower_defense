using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHolder : MonoBehaviour
{
   
   public bool isOccupiedByTower = false;

   

    private void OnMouseDown()
    {
      
        if ( !isOccupiedByTower)
        {
            FindObjectOfType<TowerFactory>().AddTower(this);
            
        }
       
        Debug.Log("Placing Tower at: " + gameObject.name);
    }
}
