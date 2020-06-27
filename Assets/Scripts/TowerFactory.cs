using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] TowerController[] towers = null;
    [SerializeField] int towerLimit = 3;

    int towersCreated = 0;
   
    public void AddTower(TowerHolder baseHolder)
    {
        if (towersCreated < towerLimit)
        {
            CreateNewTower(baseHolder);

           

        }
        else 
        {
            MoveExistingTower();
        }
    }

    private static void MoveExistingTower()
    {
        print("cant place more towers");
    }

    private void CreateNewTower(TowerHolder baseHolder)
    {
        towersCreated++;
        int i = Random.Range(0, towers.Length);
        TowerController newTower = Instantiate(towers[i], baseHolder.transform.position, Quaternion.identity);
        newTower.transform.parent = this.transform;
        baseHolder.isOccupiedByTower = true;
    }
}
