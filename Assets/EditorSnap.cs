using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{   
    [SerializeField] [Range(1f, 20f)] float gridSize=10f;

    
    void Update()
    {
        Vector3 snapPosition;
        snapPosition.x = Mathf.RoundToInt( transform.position.x/ gridSize) * gridSize;//Rounds inner math then multipl by 10 to get world coordinate back
        snapPosition.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = new Vector3(snapPosition.x, 0, snapPosition.z);
    }
}
