using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{

    public Collider enterObject;
    public GameObject start;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //Debug.LogError(player.GetComponent<OffGround>().lastStart);
        start = player.GetComponent<OffGround>().lastStart;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        enterObject = other;
        start.GetComponent<RotateScript>().enter = false;

        //if(gameObject.transform.CompareTag("END"))
        //{

        //    end = true;
        //}

    }
}
