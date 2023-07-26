using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ShowWorldPos : MonoBehaviour
{

    public Vector3 worldPos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {

        worldPos.x = transform.position.x;
        worldPos.y = transform.position.y;
        worldPos.z = transform.position.z;
        
    }
}
