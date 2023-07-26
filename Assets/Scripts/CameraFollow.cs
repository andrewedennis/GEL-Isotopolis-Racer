using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;


    private void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        vcam.LookAt = this.gameObject.transform;
        vcam.Follow = this.gameObject.transform;
    }

    private void Update()
    {

    }




}
