using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{

    public GameObject particleObject;

    public float particleVelocty = 1f;
    public float spawnRate = 2f;
    public Vector3 range = new Vector3(0, 0, 0);
    float timer = 0f;
    public GameObject holder;

    private void OnDrawGizmosSelected()
    {


        Gizmos.DrawCube(transform.position, range*2f);

    }

    private void Awake()
    {

        //GetComponent<BoxCollider>().size = range*2f;
        holder = new GameObject("Holder");

    }

    private void Update()
    {
        
        if(timer > spawnRate)
        {

            SpawnParticle();
            timer = 0;

        }
        else
        {
            timer += Time.deltaTime;
        }

    }

    public void SpawnParticle()
    {

        GameObject atom = Instantiate(particleObject);
        atom.transform.parent = holder.transform;
        atom.transform.rotation =Quaternion.Euler( new Vector3(Random.Range(-360f, 360f), Random.Range(-360f, 360f), Random.Range(-360f, 360f)));
        Vector3 direction = new Vector3(Random.Range(-10f,10), Random.Range(-10f, 10), Random.Range(-10f, 10));
        Vector3 pos = new Vector3(Random.Range(-1f * range.x, range.x)+transform.position.x, Random.Range(-1f * range.y, range.y) + transform.position.y, Random.Range(-1f * range.z, range.z) + transform.position.z);
        atom.transform.position = pos;
        atom.GetComponent<Rigidbody>().AddForce(direction*particleVelocty);

    }


    void OnTriggerExit(Collider other)
    {
        
        if(other.GetComponent<CollisionAtom>() != null)
        {

            Destroy(other.gameObject);

        }


    }
}
