using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewIsotopeSo", menuName = "ScriptableObjects/IsotopeSO", order = 1)]
public class IsotopeSO : ScriptableObject
{
    public enum IsoType {medical,bio_research, nuclear, battery, structure,star };
    public IsoType type;
    public string isotopeName;
    public GameObject isotopeModel;
    public bool unlocked;

}