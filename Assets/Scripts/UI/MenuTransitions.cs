using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class MenuTransitions : MonoBehaviour
{
    public CinemachineVirtualCamera currentCamera;

    void Start()
    {
        //currentCamera.Priority++;
    }

    public void UpdateCamera(CinemachineVirtualCamera target)
    {
        currentCamera.Priority--;
        currentCamera = target;
        currentCamera.Priority++;
    }

    public void StartSelect()
    {
        Debug.Log("firing");
        SceneManager.UnloadSceneAsync("Updated Menu");
        GameObject.Find("Canvas").SetActive(false);
        SceneManager.LoadScene("FRIBMAINCOPYwNET 1", LoadSceneMode.Additive);
        
    }
}
