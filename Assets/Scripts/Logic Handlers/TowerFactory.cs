using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] TowerController[] towers = null;
    [SerializeField] int towerLimit = 1;
    [SerializeField] bool IsRandomTower = false;

    Queue<TowerController> towerControllers = new Queue<TowerController>();
    
    
   public int GetTurretLimit()
    {
        return towerLimit;
    }
    public void IncreaseTowerLimit()
    {
        towerLimit++;
    }

    public void AddTower(TowerHolder baseHolder)
    {
        var towers = towerControllers.Count;
        if (towers < towerLimit)
        {
            CreateNewTower(baseHolder);
            

           

        }
        else 
        {
            MoveExistingTower(baseHolder);
        }
    }

    private  void MoveExistingTower(TowerHolder newBaseHolder)
    {
        //take bottom tower off que
       var oldTower= towerControllers.Dequeue();
        //set the placable flags
        oldTower.baseHolder.isOccupiedByTower = false;  
       // baseHolder.isOccupiedByTower = false;
        //set the  base towerholder
        oldTower.baseHolder = newBaseHolder;
        newBaseHolder.isOccupiedByTower = true;
        //move 
        oldTower.transform.position = newBaseHolder.transform.position;
        //set old tower to the top of the queue
        towerControllers.Enqueue(oldTower);
    }

    private void CreateNewTower(TowerHolder baseHolder)
    {
        TowerController newTower;
        if (IsRandomTower)
        {
         int i = Random.Range(0, towers.Length);
         newTower = Instantiate(towers[i], baseHolder.transform.position, Quaternion.identity);

        }
        else
        newTower = Instantiate(towers[0], baseHolder.transform.position, Quaternion.identity);
        newTower.transform.parent = this.transform;
        baseHolder.isOccupiedByTower = true;

        newTower.baseHolder = baseHolder;
        towerControllers.Enqueue(newTower);
        
    }
}
