using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyFull : MonoBehaviour
{
    public bool Full = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Full == true)
        {
            fullUI();
        }
    }

    public void fullUI()
    {
        GameObject.Find("LobbyFullCanvas").transform.Find("Text").gameObject.SetActive(true);
    }
}
