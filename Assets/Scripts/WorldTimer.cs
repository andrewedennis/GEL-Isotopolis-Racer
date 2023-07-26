using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WorldTimer : MonoBehaviour
{
    public Text Timer;
    public float TimeValue = 0;
    public float Ghost1TimeValue =0;
    public float Ghost2TimeValue =0;
    public double trueTimeValue =0;
    public bool offMenu = false;
    public bool lapsDone = false;
    public bool ghost1LapsDone = false;
    public bool ghost2LapsDone = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (offMenu == true && lapsDone == false )
        {
            if (GameObject.Find("Timer Text") != null)
            {
                Timer = GameObject.Find("Timer Text").GetComponent<Text>();
                TimeValue += Time.deltaTime;
                trueTimeValue = System.Math.Round(TimeValue, 2);



                Timer.text = trueTimeValue.ToString();

                Ghost1TimeValue += Time.deltaTime;
                Ghost2TimeValue += Time.deltaTime;
            }
        }

        if(lapsDone == true)
        {
            //Timer = GameObject.Find("GeneralTimer").GetComponent<Text>();
            //Timer.text = (0.00).ToString();
        }
        
    }
}
