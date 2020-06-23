using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    //using public cause in pure data class
    public WayPoint exploredFrom;
    public bool isExplored = false;

    [SerializeField] Color exploredColor;
    const int gridSize = 10;
    private void Update()
    {
        if (isExplored)
        {
            SetTopColor(exploredColor);
        }
    }
    public int GetGridSize()
    {
        return gridSize;
    }
    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
         Mathf.RoundToInt(transform.position.x / gridSize) ,
         Mathf.RoundToInt(transform.position.z / gridSize) 
         );
    }

    public void SetTopColor(Color newColor)
    {
        var obj = transform.Find("Top");
        obj.gameObject.GetComponent<MeshRenderer>().material.color = newColor;
    }
}
