using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateParent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            //        beanChild.transform.RotateAround(target.transform.position, target.transform.forward, 40 * Time.deltaTime);
            //     beanChild.transform.Rotate(0, 0, 5f * Time.deltaTime);
            transform.Translate(0, 2f * Time.deltaTime, 0, Space.World);
            transform.Rotate(0, 0, 15f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0, -2f * Time.deltaTime, 0, Space.World);
            transform.Rotate(0, 0, -15f * Time.deltaTime);
            //      beanChild.transform.RotateAround(target.transform.position, -target.transform.forward, 40 * Time.deltaTime);

        }
    }
}
