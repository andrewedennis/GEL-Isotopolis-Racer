using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class BGMPlayer : MonoBehaviour {

    [Header("Audio Source References")]
    [Tooltip("The Audio Source which contains the opening or intro")]
    public AudioSource opening;
    [Tooltip("The Audio Source which contains the main loop")]
    public AudioSource loop;
    
    [Header("Timing Controls")]
    [Tooltip("The time in the opening when the loop should be turned on in seconds, match to the length of the opening clip to start the loop after the opening clip ends")]
    public float timeToGoToLoop;

	void Update () {
        SwitchToLoop();
    }

    public void SwitchToLoop()
    {
        if (opening.time >= timeToGoToLoop)
        {
            if (!loop.isPlaying)
            {
                loop.Play();
            }          
        }
    }
}
