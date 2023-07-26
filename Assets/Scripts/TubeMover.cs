using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeMover : MonoBehaviour
{
    public GameObject target;


    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(target.transform.position, Vector3.forward, 40 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(target.transform.position, Vector3.back, 40 * Time.deltaTime);
        }
        transform.Translate(Vector3.back * (Time.deltaTime * 25));

    }
}
