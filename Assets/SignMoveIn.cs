using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignMoveIn : MonoBehaviour
{
    bool Move = false;
    bool MoveStarted = false;
    public Transform startPos;
    public Transform endPos;
    public float speed = 1f;
    public float SpeedUP = 10;
    public float startTime;
    public float Length;
    public float distCovered;
    public float fractionOfJourney;
    public float signStayLenght = 3;
    public int signNumber;
    public int sentNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Move)
        {
            if(MoveStarted == false)
            {
                startTime = Time.time;
                MoveStarted = true;
            }
            
            startPos = GameObject.Find("SignBegin").transform;
            endPos = GameObject.Find("SignFinal").transform;
            Length = Vector3.Distance(startPos.position, endPos.position);

            distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            fractionOfJourney = distCovered / Length;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startPos.position, endPos.position, fractionOfJourney * SpeedUP);

            if(transform.position == endPos.transform.position)
            {
                StartCoroutine(ResetSign());
                Move = false;
                MoveStarted = false;
            }

            //this.transform.position = GameObject.Find("SignFinal").gameObject.transform.position;
        }
    }

    public void SetMove()
    {
        Move = true;
    }

    IEnumerator ResetSign()
    {
        //Debug.LogError("ResetCalled");
        yield return new WaitForSeconds(signStayLenght);
       // Debug.LogError("Reset");
        transform.position = startPos.transform.position;
    }
}
