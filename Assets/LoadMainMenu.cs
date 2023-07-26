using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MLAPI;
using MLAPI.Messaging;
public class LoadMainMenu : MonoBehaviour
{


    public void LoadMainMenuFunc()
    {
        NetworkManager.Singleton.StopHost();

        IsotopeCollection.Global.LoadMainMenuAct();
        Destroy(transform.parent.parent.parent.gameObject);
    }


}
