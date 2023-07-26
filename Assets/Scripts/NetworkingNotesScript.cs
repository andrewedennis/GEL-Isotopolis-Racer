using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkingNotesScript : MonoBehaviour
{

    // figure out camera, get ghost racer in network scene, continue on with networking stuff. Positioning of ghost and other player racers is off,
    //though with respawn manager being a child object we should be able to change this. How many players we have support for james said 2 teams but we are having 4 different racing teams. 
    //Find a way to change name of player racers so they are not just all the the same clone copy, this will help with stuff like positioning. 

    //notes 8/5/21 network manager has support to have multiple network prefabs so i am going to make 3 seperate player prefabs so we have to spawn to make sure we can get the names and variables easier.
    //network hash was getting a bunch of errors but this is because when you copy a prefab it keeps its network hashname the same. 
    //When i believe i got it set up it was gibbing me an error in network manager about the client spawning in need to go more in depth and figure out what was wrong.
    // when using multiple player prefabs we now need to unset create player prefab and for each of the prefabs to not have default player prefab set.
    // Then in each section of password network manager we need to insaniate/ create the specific player prefab for the situation 

    //ex 

    //public void HostButton()
    //{
    //    //control period to create method easier
    //    NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
    //    //start hosting, also set host postion could do more 
    //    NetworkManager.Singleton.StartHost(new Vector3());
    //    host = Instantiate(hostPrefab, new Vector3(211.869247f, 10, 849.981384f), Quaternion.identity).gameObject;
    //    host.GetComponent<NetworkObject>().SpawnWithOwnership(NetworkManager.Singleton.LocalClientId, null, true);


    //    GameObject.Find("INGAME_UI_Parent").transform.Find("UI").gameObject.SetActive(true);
    //    //GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().

    //    //GameObject.FindGameObjectWithTag("Player").transform.localEulerAngles = new Vector3(0, 180, 0);

    //}


    //public void ClientButton()
    //{
    //    NetworkManager.Singleton.NetworkConfig.ConnectionData = Encoding.ASCII.GetBytes(passwordInputField.text);
    //    //start client
    //    NetworkManager.Singleton.StartClient();
    //    client = Instantiate(clientPrefab, new Vector3(211.869247f, 10, 849.981384f), Quaternion.identity).gameObject;
    //    client.GetComponent<NetworkObject>().SpawnWithOwnership(NetworkManager.Singleton.LocalClientId, null, true);
    //    //believe this is where we are not setting the clients ui to active since there is no way to differenciate what player
    //    GameObject.Find("INGAME_UI_Parent").transform.Find("UI").gameObject.SetActive(true);
    //    //GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().offMenu = true;
   // }

    //this also requieres 4 new prefabs 2 for transform for host and client 
    //and twwo for the gameobects for the prefabs of host and client 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

