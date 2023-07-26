using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.Connection;
using UnityEngine.UI;
    public class SignTrigger : MonoBehaviour
{
    public int signNumber;
    public bool isLapBuddy = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public int getNumber()
    {
        if (isLapBuddy)
        {

            signNumber = int.Parse(GameObject.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("LapCnt").GetComponent<Text>().text);
            return signNumber;
        }
        else
        {

            return signNumber;

        }
    }

}
