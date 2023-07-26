using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera MainCamera;
    public Camera CameraTwo;

    void Start()
    {
        MainCamera = Camera.main;
        MainCamera.enabled = true;
        CameraTwo.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (MainCamera.enabled)
            {
                CameraTwo.enabled = true;
                MainCamera.enabled = false;
            }
            else if (!MainCamera.enabled)
            {
                CameraTwo.enabled = false;
                MainCamera.enabled = true;
            }
        }
    }
}
