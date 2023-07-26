using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterPointSwap : MonoBehaviour
{
    public GameObject player;
    public GameObject newCenter;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        newCenter = GameObject.Find("CenterPoint (1)");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.GetComponent<OffGround>().target = newCenter;
        }
    }
}
