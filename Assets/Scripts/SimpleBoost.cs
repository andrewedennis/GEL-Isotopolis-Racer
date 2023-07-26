using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBoost : MonoBehaviour
{

    private GameObject player;
    public float boostLength = 1;
    public float boostMult = 5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("BeanMobile");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<OffGround>() != null)
        {

            StartCoroutine(Boost());

        }


    }

    IEnumerator Boost()
    {

        player.GetComponent<OffGround>().boostNorm = true;
        player.GetComponent<OffGround>().zoomCurrent = player.GetComponent<OffGround>().zoomCurrent * boostMult;
        player.GetComponent<OffGround>().notAtDefault = true;
        yield return new WaitForSeconds(boostLength);
        player.GetComponent<OffGround>().boostNorm = false;

        //float oldZoom = player.GetComponent<OffGround>().zoomCurrent;
        //player.GetComponent<OffGround>().zoomCurrent = player.GetComponent<OffGround>().zoomCurrent * boostMult;
        //player.GetComponent<OffGround>().notAtDefault = true;
        //yield return new WaitForSeconds(boostLength);
        //player.GetComponent<OffGround>().zoomCurrent = oldZoom;



    }
}
