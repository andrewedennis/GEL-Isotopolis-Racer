using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RFQSliceRotator : MonoBehaviour
{
    //<summary>
    // Rotates the RFQ Slices left or right
    //</summary>

    public bool rotateRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateRight)
        {

            transform.Rotate(Vector3.right * 10f * Time.deltaTime);
        }
        else
        {

            transform.Rotate(Vector3.right * -10f * Time.deltaTime);
        }
    }
}
