using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PositionTracking : MonoBehaviour
{

    public GameObject[] Racers;
    public int temp;
    public int high = 0;
    public GameObject first;
    // Start is called before the first frame update
    void Start()
    {
        Racers = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < Racers.Length; i++)
        {
           temp =  Racers[i].GetComponent<OffGround>().Lapcount;
           if (temp > high)
            {
                high = temp;
                first = Racers[i];
                if(first.name == GameObject.Find("BeanMobile").name)
                {
                    GameObject.Find("PositionCnt").GetComponent<Text>().text = "1st";
                }
                else
                {
                    GameObject.Find("PositionCnt").GetComponent<Text>().text = "2nd";
                }
            }

        }
        //comparing checkPoints
        for (int i = 0; i < Racers.Length; i++)
        {
            for (int j = Racers.Length; i >= 0; i--)
            {
                if(Racers[i].GetComponent<OffGround>().whatCheck > Racers[j].GetComponent<OffGround>().whatCheck)
                {

                }
                else if(Racers[i].GetComponent<OffGround>().whatCheck < Racers[j].GetComponent<OffGround>().whatCheck)
                {

                }
                //case if they are at the same checkpoint
                else
                {

                }
            }
        }




    }

    //what we need to do:
    //Get list of all players.
    //check what lap the player is on
    //check what checkpoint inside that lap they are on
    //then if inbetweeen the same checkpoint - this is the hardest task for us to find. C
    //Things we can do have object on the front runner so use that as comparison but thats hard to check which player passes it since can move in diff directionsk, but would distance to next checkpoint work well enough. 

}
