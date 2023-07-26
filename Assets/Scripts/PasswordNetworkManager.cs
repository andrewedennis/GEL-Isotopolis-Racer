using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using TMPro;
using System.Text;
using System;

namespace MLAPI.NetworkVariable
{
    public class PasswordNetworkManager : NetworkBehaviour
    {
        //refernece to text in pass entry field 
        [SerializeField] private TMP_InputField passwordInputField;
        //refernece to ui to host or join
        [SerializeField] private GameObject passwordEntryUI;
        [SerializeField] private GameObject LobbyInfo;
        //reference to leave button 
        [SerializeField] private GameObject leaveButton;
        [SerializeField] private NetworkObject ghost1;
        [SerializeField] private NetworkObject ghost2;
        NetworkObject ghostInstance1;
        NetworkObject ghostInstance2;
        public NetworkVariable<int> playerCount = new NetworkVariable<int>();
        public GameObject hostButton;
        public bool full = false;

        [Header("Temp to get stuff workin")]
        public GameObject playerPrefab;



        Vector3 SaveStart;
        //public Transform ghostPrefab;
        //public Transform ghostPrefab2;

        private void Start()
        {

            StartCoroutine(StartGameBut());
            playerCount.Value = 1;
            /*
            NetworkManager.Singleton.OnServerStarted += HandleServerStarted;
            NetworkManager.Singleton.OnClientConnectedCallback += HandleClientConnected;
            NetworkManager.Singleton.OnClientDisconnectCallback += HandleClientDisconnect;
            */
            //SaveStart = GameObject.FindGameObjectWithTag("RespawnManager").GetComponent<RespawnManager>().savedStart;
        }

        private void Update()
        {

        }


        IEnumerator StartGameBut()
        {

            GameObject.Find("Menu Directional Light").GetComponent<Light>().intensity = 0;
            yield return new WaitForSeconds(3);
            HostButton();


        }
        private void OnDestroy()
        {
            /*
            if (NetworkManager.Singleton == null) { return; }

            NetworkManager.Singleton.OnServerStarted -= HandleServerStarted;
            NetworkManager.Singleton.OnClientConnectedCallback -= HandleClientConnected;
            NetworkManager.Singleton.OnClientDisconnectCallback -= HandleClientDisconnect;
            */
        }

        public void LeaveButton()
        {
            //handle host leaving 
            if (NetworkManager.Singleton.IsHost)
            {
                NetworkManager.Singleton.StopHost();
                NetworkManager.Singleton.ConnectionApprovalCallback -= ApprovalCheck;

            }
            //handle client leaving
            else if (NetworkManager.Singleton.IsClient)
            {
                NetworkManager.Singleton.StopClient();
            }
            //set ui elements
            passwordEntryUI.SetActive(true);
            leaveButton.SetActive(false);
        }
        public void HostButton()
        {

            //control period to create method easier
            NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
            //start hosting, also set host postion could do more 
           NetworkManager.Singleton.StartHost(new Vector3(211.869247f, 10, 849.981384f));
            //spawnGhostServerRpc();
            //Instantiate(ghostPrefab, new Vector3(211.869247f, 10, 849.981384f), Quaternion.identity);
            //Instantiate(ghostPrefab2, new Vector3(211.869247f, 10, 849.981384f), Quaternion.identity);
           //GameObject player = Instantiate(playerPrefab);
            //player.transform.position = new Vector3(211.869247f, 10, 849.981384f);
            GameObject.Find("INGAME_UI_Parent").transform.Find("UI").gameObject.SetActive(true);
            //GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().offMenu = true;
            //GameObject.FindGameObjectWithTag("Player").transform.localEulerAngles = new Vector3(0, 180, 0);
            hostButton.SetActive(false);

        }

        [ServerRpc]
        private void spawnGhostServerRpc()
        {

             ghostInstance1 = Instantiate(ghost1, new Vector3(211.869247f, 10, 849.981384f), Quaternion.identity);
            ghostInstance1.SpawnWithOwnership(OwnerClientId);
             ghostInstance2 = Instantiate(ghost2, new Vector3(211.869247f, 10, 849.981384f), Quaternion.identity);
            ghostInstance2.SpawnWithOwnership(OwnerClientId);
        }

        [ClientRpc]
        private void spawnGhostClientRpc()
        {

        }

        [ServerRpc]
        private void destoryGhost1ServerRpc()
        {
            ghostInstance1.Despawn(true);
        }

        [ServerRpc]
        private void destoryGhost2ServerRpc()
        {
            ghostInstance2.Despawn(true);
        }

        public void ClientButton()
        {
            NetworkManager.Singleton.NetworkConfig.ConnectionData = Encoding.ASCII.GetBytes(passwordInputField.text);
            //start client
            NetworkManager.Singleton.StartClient();
            if (full == false)
            {
                GameObject.Find("INGAME_UI_Parent").transform.Find("UI").gameObject.SetActive(true);
            }else
            {
                GameObject.Find("LobbyFullCanvas").transform.Find("Text").gameObject.SetActive(true);
            }
            //GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().offMenu = true;
        }

        private void ApprovalCheck(byte[] connectionData, ulong clientID, NetworkManager.ConnectionApprovedDelegate callback)
        {
            playerCount.Value += 1;
            //convert data passed into string for password
            string password = Encoding.ASCII.GetString(connectionData);

            //check if given password is equal to actual password 
            bool approveConnection = password == passwordInputField.text;

            //set default spawn 
            Vector3 spawnPos = Vector3.zero;
            //could also set the default rotation did not do for now 

            //find how many people are connected
            switch (NetworkManager.Singleton.ConnectedClients.Count)
            {
                case 1:
                    spawnPos = new Vector3(213.869247f, 10, 849.981384f);
                    break;
                case 2:
                    spawnPos = new Vector3(209.869247f, 10, 849.981384f);
                    break;
            }

            //pass in weither we should aprove, spawn, what prefab to spawn
            //first if should spawn in player, player prefabhash, approve bool, position, rotation), these are parameters
            if (playerCount.Value == 2)
            {
                destoryGhost1ServerRpc();
                callback(true, null, approveConnection, spawnPos, null);
                Debug.LogError(NetworkManager.ConnectedClientsList.Count);
               
            }
            if (playerCount.Value == 3)
            {
                destoryGhost2ServerRpc();
                callback(true, null, approveConnection, spawnPos, null);
            }
            if(playerCount.Value > 3)
            {
                full = true;
                GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<LobbyFull>().Full = true;
                callback(true, null, false, spawnPos, null);
            }
        }

        private void HandleClientConnected(ulong clientId)
        {
            if (clientId == NetworkManager.Singleton.LocalClientId)
            {
                passwordEntryUI.SetActive(false);
                LobbyInfo.SetActive(false);
                //leaveButton.SetActive(true);
            }
        }

        private void HandleClientDisconnect(ulong clientId)
        {
            if (clientId == NetworkManager.Singleton.LocalClientId)
            {
                passwordEntryUI.SetActive(true);
                LobbyInfo.SetActive(true);
                leaveButton.SetActive(false);
            }
        }

        //have to manually call for host 
        private void HandleServerStarted()
        {
            if (NetworkManager.Singleton.IsHost)
            {
                HandleClientConnected(NetworkManager.Singleton.LocalClientId);
            }
        }

    }
}
