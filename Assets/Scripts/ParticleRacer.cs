using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the elements related to the particles property and interactions with track elements and ui
/// </summary>
/// 
[CreateAssetMenu(fileName = "NewParticleRacer", menuName = "ScriptableObjects/ParticleRacer", order = 1)]
public class ParticleRacer : ScriptableObject
{
    /*
    private GameObject racerUI;
    private GameObject timedBoostUI;
    private GameObject ionizationUI;

    private TimedBoost timedBoost;
    public enum RacerState { timedBoost, ionization, };

    private RacerState state;
    private float ionizationBoostAmount = 0f;  

    public bool lockInput = false;
    public Animation ionizationTargetPulse;

    */

    public GameObject racerModel;
    public GameObject characterModel;

    public string racerName;


}
