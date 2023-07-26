using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.Connection;

namespace MLAPI.NetworkVariable
{
    public class GoToSceneButton : MonoBehaviour
    {

        public int levelToLoad = 0;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void LoadScenePlz()
        {
            //Application.LoadLevel(levelToLoad);
            GameObject.Find("NetworkManagerPre").GetComponent<NetworkManager>().StopServer();
            Destroy(GameObject.Find("NetworkManagerPre"));
            SceneManager.UnloadSceneAsync(0);
            SceneManager.UnloadSceneAsync(1);
            SceneManager.LoadScene(levelToLoad);


        }
    }
}
