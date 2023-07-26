using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] private float knockbackForce = 20f;

    private void OnCollisionEnter(Collision col)
    {

        
        Rigidbody rb = col.collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 dir = col.transform.position - transform.position;
            dir.y = 0;
            rb.AddForce(dir.normalized * knockbackForce, ForceMode.VelocityChange);
        }


        //var body = gameObject.GetComponent<Rigidbody>();
        //Vector3 direction = body.transform.position - col.gameObject.transform.position;
        //body.AddForceAtPosition(direction.normalized * 100000f, transform.position);

    }



}
