using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{   
    [SerializeField] [Range(1f, 20f)] float gridSize=10f;

    TextMesh textMesh;

    private void Awake()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        
    }

    void Update()
    {
        Vector3 snapPosition;
      
        snapPosition.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;//Rounds inner math then multipl by 10 to get world coordinate back
        snapPosition.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPosition.x, 0, snapPosition.z);//new Vector3(snapPosition.x, 0, snapPosition.z);

        string labelText = snapPosition.x / gridSize + "," + snapPosition.z / gridSize;//label  to get not exact coordinates but proper label
        textMesh.text = labelText;
        gameObject.name = labelText;
    }

   
}
