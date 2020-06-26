using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHolder : MonoBehaviour
{
    [SerializeField] TowerController tower = null;
    Transform parentForTowers = null;
    bool isOccupiedByTower = false;

    void Start()
    {
        parentForTowers = GameObject.Find("Enemies").transform;
    }

    private void OnMouseDown()
    {
        if ( !isOccupiedByTower)
        {
            TowerController newTower = Instantiate(tower, transform.position, Quaternion.identity);
            newTower.transform.parent = parentForTowers;
            isOccupiedByTower = true;
        }
        Debug.Log("Placing Tower at: " + gameObject.name);
    }
}
