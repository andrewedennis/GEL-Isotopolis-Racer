using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffGround : MonoBehaviour
{
    
    public float strength = 10.0f;
    public float distanceToGround;
    public float distance = 5.0f;
    Vector3 forward;
    private float turn;
    public GameObject bean;
    public float zoomDefault = 5;
    public float zoomCurrent = 0;
    public float zoomCap = 25;
    public GameObject beanChild;
    public GameObject target;

    //attempt just through pure raycasting 
    // Start is called before the first frame update
    //private void FixedUpdate()
    //{
    //RaycastHit cast;
    //if(Physics.Raycast(transform.position, Vector3.up, out cast))
    //{

    //    distanceToGround = cast.distance;
    //    //Vector3 pyer = cast.point;

    //    //Ray heyUpward =  new Ray(player, transform.position - player);

    //    //Vector3 heyDist = heyUpward.GetPoint(5);
    //    //transform.position = Vector3.Lerp(transform.position, heyDist, distance);
    //}
    //}

    private float groundHeight;
    private float maxDistance = 25f;
    public Vector3 player;
    private RaycastHit cast;
    public Transform orginOfCast;
    public Transform curveStart;
    public GameObject lastStart;
    float zRot;
    public bool locked = false;
    public bool boostingStart = false;
    public bool boostNorm = false;
    public bool notAtDefault = false;
    public bool ionizationDone = false;
    public bool atStart = true;
    public int playerPosition;
    public int Lapcount = 1;
    private Text lapCnt;
    private Text distanceToNxtT;
    public int whatCheck = 1;
    public string nextCheckName;
    public float distanceToNext;
    public GameObject nextCheck;

    public RotateScript rotScript;

    private void Start()
    {
        beanChild = GameObject.Find("KartVisual");
        target = GameObject.Find("CenterPoint");
        lastStart = null;
        zoomCurrent = zoomDefault;
        lapCnt = GameObject.Find("LapCnt").GetComponent<Text>();
        //distanceToNxtT = GameObject.Find("DistanceToNext").GetComponent<Text>();

    }
    private void Update()
    {

        if (gameObject.name == "BeanMobileStuck")
        {
            locked = true;
        }
        if (gameObject.name == "BeanMobile")
        {
            lapCnt.text = Lapcount.ToString();
        }

        if (transform.name == ("BeanMobile"))
        {
            nextCheckName = (whatCheck + 1).ToString();
            nextCheck = GameObject.Find(nextCheckName);
            //distanceToNext = Vector3.Distance(nextCheck.transform.position, transform.position);
            //distanceToNxtT.text = distanceToNext.ToString();
        }





        Physics.Raycast(orginOfCast.position, -orginOfCast.up, out cast, maxDistance);

       

        ////raycast with distance off ground 
        player = transform.position;
        float height = cast.distance;

        Debug.DrawRay(orginOfCast.position, -orginOfCast.up * height, Color.blue);

        //Debug.LogError(height);

        //transform.localPosition = new Vector3(transform.localPosition.x, height + distance, transform.localPosition.z);

        

        if (height > distance)
        {
            float dif = height - distance;
            transform.position -= dif * transform.up;
        }
        else if(height < 1)
        {
            //case for if it gets to close, this is causing the jittering !!!
            transform.localPosition = new Vector3(transform.localPosition.x, distance, transform.localPosition.z);
        }


       if (locked == false)
       {
            if (Input.GetKey(KeyCode.A))
        {
            //        beanChild.transform.RotateAround(target.transform.position, target.transform.forward, 40 * Time.deltaTime);
            //     beanChild.transform.Rotate(0, 0, 5f * Time.deltaTime);
            //       transform.Translate(0, 2f * Time.deltaTime, 0, Space.World);
            //zRot += 30f * Time.deltaTime;
            //transform.rotation = Quaternion.Euler(0, 0, zRot);
            transform.Rotate(0, 0, 29f * Time.deltaTime);
      //      transform.Rotate(0, 0, 30f * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D))
        {
            //          transform.Translate(0, -2f * Time.deltaTime, 0, Space.World);
            //zRot += -30f * Time.deltaTime;
            //transform.rotation = Quaternion.Euler(0, 0, zRot);
            transform.Rotate(0, 0, -29f * Time.deltaTime);
            //      beanChild.transform.RotateAround(target.transform.position, -target.transform.forward, 40 * Time.deltaTime);
        }

        if(boostingStart == false && zoomCurrent > zoomDefault)
            {
                //zoomCurrent -= .05f;
            }
            else
            {
               
               
            }

        if (boostNorm == false && zoomCurrent > zoomDefault && ionizationDone == true)
        {
                zoomCurrent -= .05f;
        }
            else
            {
                
            }

        if(notAtDefault = true && zoomCurrent > zoomCap)
            {
                zoomCurrent = zoomCap;
            }

        if(zoomCurrent < 5 && boostingStart == false)
            {
                zoomCurrent = 5;
            }

            //Debug.Log(bean.transform.forward * Time.deltaTime * zoomCurrent);
            transform.position += bean.transform.forward * Time.deltaTime * zoomCurrent;
       }

    }



}
