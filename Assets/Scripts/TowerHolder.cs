using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHolder : MonoBehaviour
{
    [SerializeField] TowerController[] towers = null;
    Transform parentForTowers = null;
    bool isOccupiedByTower = false;

    void Start()
    {
        parentForTowers = GameObject.Find("Towers").transform;
    }

    private void OnMouseDown()
    {
      
        if ( !isOccupiedByTower)
        {
            int i = Random.Range(0, towers.Length );
            TowerController newTower = Instantiate(towers[i], transform.position, Quaternion.identity);
            newTower.transform.parent = parentForTowers;
            isOccupiedByTower = true;
        }
       
        Debug.Log("Placing Tower at: " + gameObject.name);
    }
}
