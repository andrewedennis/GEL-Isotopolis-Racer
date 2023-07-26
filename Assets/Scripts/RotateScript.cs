using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public Transform curveEnd;
    public bool enter = false;
    public Collider enterObject;
    public GameObject player;
    public bool end;
    public GameObject start;
    public float speed = .5f;

    // Start is called before the first frame update
    void Start()
    {
        enter = false;
        
        //start = GameObject.FindGameObjectWithTag("START");
    }

    // Update is called once per frame
    void Update()
    {
        //if(end == true)
        //{
        //    start.GetComponent<RotateScript>().end = true;
        //    //Debug.Log(enter);
        //}

        player = GameObject.FindGameObjectWithTag("Player");

        if (enter == true)
        {
            if (enterObject.CompareTag("Player"))
            {
                float y = curveEnd.eulerAngles.y;
                Debug.LogError(y);
                Vector3 targetDir = curveEnd.position - enterObject.transform.position;
                targetDir.y = 0;
                if (player.transform.rotation.y != y)
                {
                    player.transform.rotation = Quaternion.Lerp(enterObject.transform.rotation, Quaternion.Euler(0, y, 0), speed * Time.deltaTime);
                }
                else
                {
                    player.transform.rotation = Quaternion.Euler(0, y, 0);
                }



                //    Vector3 targetDir = curveEnd.position - enterObject.transform.position;
                //    Debug.DrawRay(player.transform.position,targetDir, Color.green);


                //    //.5 value is important should make a float for speed
                //    Vector3 newDir = Vector3.RotateTowards(enterObject.transform.forward, targetDir, .5f * Time.deltaTime, 0.0f);
                //    Debug.DrawRay(enterObject.transform.position, newDir, Color.red);
                //    newDir.y = 0;
                //    Quaternion newRot = Quaternion.LookRotation(newDir);

                //    //        enterObject.transform.Rotate(newRot.eulerAngles);
                //    //    Quaternion diffAngle = Quaternion.Angle(enterObject.transform.rotation, newRot);
                //    enterObject.transform.localRotation = new Quaternion(0, newRot.y, enterObject.transform.rotation.z,newRot.w);
                ////    enterObject.transform.forward = newDir;
                //    //enterObject.transform.eulerAngles = newRot * enterObject.transform.eulerAngles;
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        enterObject = other;
        enter = true;
        if (other.CompareTag("Player"))
        {
            other.GetComponent<OffGround>().lastStart = gameObject;
        }

            //if(gameObject.transform.CompareTag("END"))
            //{

            //    end = true;
            //}

    }
}
