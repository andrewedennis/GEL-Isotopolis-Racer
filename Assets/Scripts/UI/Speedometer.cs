using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public Text speedText;
    public OffGround player;

    void Update()
    {
        string speed = (player.zoomCurrent).ToString("f2");

        speedText.text = speed + " m/s";
    }
}

