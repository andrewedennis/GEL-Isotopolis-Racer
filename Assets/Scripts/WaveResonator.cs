using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveResonator : MonoBehaviour
{
    private bool isFirst = true;
    public List<GameObject> firstPoints = new List<GameObject>();
    public List<GameObject> secondPoints = new List<GameObject>();

    public float boostAmount = 5f;
    public float alternateTime = 1f;
    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        
        if(timer >= alternateTime)
        {

            timer = 0;

            SwitchWave();
        }
        else
        {

            timer += Time.deltaTime;
        }


    }

    void SwitchWave()
    {
        if (isFirst)
        {

            foreach(GameObject ele in firstPoints)
            {

                if (ele != null) ele.SetActive(false);
            }

            foreach (GameObject ele in secondPoints)
            {

                if (ele != null) ele.SetActive(true);
            }

            isFirst = false;
        }
        else
        {


            foreach (GameObject ele in firstPoints)
            {
                if (ele != null) ele.SetActive(true);
            }

            foreach (GameObject ele in secondPoints)
            {

                if (ele != null) ele.SetActive(false);
            }

            isFirst = true;

        }


    }
}
