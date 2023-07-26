using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameBut : MonoBehaviour
{

    public void UnloadMenuLight()
    {
        GameObject.Find("Menu Directional Light").GetComponent<Light>().intensity = 0;

    }


}
