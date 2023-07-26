using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAtom : MonoBehaviour
{


    private void OnTriggerExit(Collider other)
    {

        Destroy(gameObject);

    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<CollisionAtom>())
        {

            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CollisionAtom>())
        {

            Destroy(gameObject);
        }
    }
}
