using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
   // Vector2Int snapPosition;
    const int gridSize = 10;
    public int GetGridSize()
    {
        return gridSize;
    }
    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
         Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
         Mathf.RoundToInt(transform.position.z / gridSize) * gridSize
         );
    }

    public void SetTopColor(Color newColor)
    {
        var obj = transform.Find("Top");
        obj.gameObject.GetComponent<MeshRenderer>().material.color = newColor;
    }
}
