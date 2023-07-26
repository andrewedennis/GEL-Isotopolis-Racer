using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody cubeBody;
    void Start()
    {
        cubeBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            cubeBody.AddForce(transform.forward * 20);
        }
    }
}
