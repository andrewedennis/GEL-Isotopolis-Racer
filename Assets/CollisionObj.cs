using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObj : MonoBehaviour
{
    public static CollisionObj Global;
    public GameObject collCamera;

    private void Awake()
    {
        Global = this;
    }


    public void Swap()
    {

        Camera oldMain = Camera.main;

        //oldMain.tag = "Untagged";
        collCamera.SetActive(true);
        oldMain.gameObject.SetActive(false);
        //collCamera.tag = "MainCamera";
    }


}
