using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.Connection;

namespace MLAPI.NetworkVariable
{
    public class FollowNodes : NetworkBehaviour
    {
        public Transform[] nodes;
        public Transform[] nodesTest;
        public string currentNode;
        public float speed;
        public float rotSpeed;
        public float rotSpeedX;
        private int currNode;
        private Vector3 Next;
        private Vector3 StartPos;
        private Vector3 Dif;
        public bool atStart = true;
        public RespawnManager RespawnMG;
        public int LapCount = -1;
        private Text lapCnt;
        private Text DistanceToNext;
        public bool boostingStart = false;
        public bool boostNorm = false;
        public bool notAtDefault = false;
        public float zoomDefault = 5;
        public float zoomCurrent = 0;
        public float zoomCap = 1000;
        public float smoothMove = .5f;
        public bool locked = false;
        public bool ionizationDone = false;
        public float distanceToNext;
        public GameObject boostEffect;
        public bool lapsEND = false;

        public float lap1Time;
        public float lap2Time;
        public float lap3Time;
        public float lapAverage; 
        public Transform playerCam;
        public Transform InGameUI;
        public NetworkVariableBool isReady = new NetworkVariableBool(false);
        public GameObject readyBut;
        public bool ScriptStart = false;
        public NetworkVariable<int> whatPlayer = new NetworkVariable<int>();
        public Mesh Model;
        public GameObject ghost1;
        public GameObject ghost2;
        float Empty = 0;
        public float RankingScoring = 0;
        public GameObject scorePrefab;
        public GameObject scoreUI;
        public Slider speedSlider;
        // Start is called before the first frame update
        void Start()
        {
            Model = gameObject.transform.Find("Capsule").transform.Find("Model").GetComponent<MeshFilter>().mesh;
            whatPlayer.Value = GameObject.Find("PassUi_Parent").GetComponent<PasswordNetworkManager>().playerCount.Value;
            //this doesnt have support for multiple players, need a solution to this. 
            RespawnMG = gameObject.transform.Find("RespawnMG").GetComponent<RespawnManager>();
            //RespawnMG = gameObject.GetComponent<RespawnManager>();
            //lapCnt = GameObject.Find("LapCnt").GetComponent<Text>();
            //DistanceToNext = GameObject.Find("DistanceToNext").GetComponent<Text>();
            //boostEffect = gameObject.transform.Find("Speed Lines").gameObject;
            //boostEffect.GetComponent<ParticleSystem>().Stop();
            //readyBut = GameObject.Find("ReadyButton");


            
           

            if(whatPlayer.Value == 2)
            {
                gameObject.transform.Find("RespawnMG").GetComponent<RespawnManager>().resetRot.eulerAngles = new Vector3(0, 180, 30);
                gameObject.transform.Find("Capsule").transform.Find("Model").GetComponent<MeshFilter>().mesh = GameObject.Find("Fe_Model").GetComponent<MeshFilter>().mesh;
            }
            if (whatPlayer.Value == 3)
            {
                gameObject.transform.Find("RespawnMG").GetComponent<RespawnManager>().resetRot.eulerAngles = new Vector3(0, 180, 330);
            }

            playerCam = GetComponentInChildren<Camera>().transform;
            InGameUI = gameObject.transform.Find("INGAME_UI_Parent");
            if (IsLocalPlayer)
            {

            }
            else
            {
                playerCam.gameObject.SetActive(false);
                InGameUI.gameObject.SetActive(false);
            }
            //transform.localEulerAngles = new Vector3(0, 180, 0);

            //nodesTest = GameObject.FindGameObjectsWithTag("Start");
            //Boost Effect can be called in update, respawnMG reference not working in update
            //need to make a new function and only call once after update to do the stuff we are doing start.
            //need to find what other references are causing other issues in here and scripts, known that rotatePlayer has issues

            //GameObject.Find("INGAME_UI_Parent").transform.Find("UI").gameObject.SetActive(true);
           // GameObject.Find("Menu Directional Light").GetComponent<Light>().intensity = 0;

        }

        // Update is called once per frame
        void Update()
        {
    
            if (ScriptStart == false)
            {
                boostEffect = gameObject.transform.Find("Capsule").gameObject.transform.Find("Speed Lines").gameObject;
                readyBut = gameObject.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("ReadyButton").gameObject;
                boostEffect.GetComponent<ParticleSystem>().Stop();
                ScriptStart = true;
                
            }
            //old if checking, this swaps the ghost model to same as players choice
            //if (whatPlayer.Value == 1 && GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<PlayerList>().playerList.Count == 1 && ScriptStart == false)

            if (ghost1 != null)
            {
                ghost1 = GameObject.Find("BeanGhost(Clone)").gameObject;
                ghost2 = GameObject.Find("BeanGhost 2(Clone)").gameObject;
                ghost1.transform.Find("GhostCapsule").transform.Find("Model").GetComponent<MeshFilter>().mesh = Model;
                ghost2.transform.Find("GhostCapsule").transform.Find("Model").GetComponent<MeshFilter>().mesh = Model;
                ghost1.transform.Find("GhostCapsule").transform.Find("Model").transform.localScale = gameObject.transform.Find("Capsule").transform.Find("Model").transform.localScale;
                ghost2.transform.Find("GhostCapsule").transform.Find("Model").transform.localScale = gameObject.transform.Find("Capsule").transform.Find("Model").transform.localScale;
            }

            //foreach (GameObject p in GameObject.FindGameObjectsWithTag("Player"))
            //{
            //    gameObject.transform.Find("Capsule").transform.Find("Model").GetComponent<MeshFilter>().mesh = Model;
            //}
            if (!lapsEND)
            {
                if (whatPlayer.Value == 1 && GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<PlayerList>().playerList.Count == 2)
                {
                    if (IsLocalPlayer)
                    {

                    }
                    else
                    {
                        gameObject.transform.Find("Capsule").transform.Find("Model").GetComponent<MeshFilter>().mesh = gameObject.transform.Find("Capsule").transform.Find("Model").GetComponent<MeshFilter>().mesh;
                    }
                }
                if (whatPlayer.Value == 2 && GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<PlayerList>().playerList.Count == 2)
                {
                    if (IsLocalPlayer)
                    {
                        ghost2 = GameObject.Find("BeanGhost 2(Clone)").gameObject;
                        ghost2.transform.Find("GhostCapsule").transform.Find("Model").GetComponent<MeshFilter>().mesh = gameObject.transform.Find("Capsule").transform.Find("Model").GetComponent<MeshFilter>().mesh;
                        ghost2.transform.Find("GhostCapsule").transform.Find("Model").transform.localScale = gameObject.transform.Find("Capsule").transform.Find("Model").transform.localScale;
                    }
                    else
                    {
                        gameObject.transform.Find("Capsule").transform.Find("Model").GetComponent<MeshFilter>().mesh = gameObject.transform.Find("Capsule").transform.Find("Model").GetComponent<MeshFilter>().mesh;
                    }

                }
                if (whatPlayer.Value == 2 && GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<PlayerList>().playerList.Count == 3)
                {
                    if (IsLocalPlayer)
                    {

                    }
                    else
                    {
                        gameObject.transform.Find("Capsule").transform.Find("Model").GetComponent<MeshFilter>().mesh = gameObject.transform.Find("Capsule").transform.Find("Model").GetComponent<MeshFilter>().mesh;
                    }
                }



                //readyBut = gameObject.transform.Find("IGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("ReadyButton").gameObject;
                nodes = GameObject.Find("Nodes").GetComponent<NodeList>().nodes;
                lapCnt = gameObject.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("LapCnt").GetComponent<Text>();
                DistanceToNext = gameObject.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("DistanceToNext").GetComponent<Text>();
                //position tracking 
                PositionCheck();
                currentNode = nodes[currNode].name;
                //readyBut.GetComponent<Button>().onClick.AddListener(ReadyClick);
            }
            //readyBut = gameObject.transform.Find("IGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("ReadyButton").gameObject;
            nodes = GameObject.Find("Nodes").GetComponent<NodeList>().nodes;
            lapCnt = gameObject.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("LapCnt").GetComponent<Text>();
            DistanceToNext = gameObject.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("DistanceToNext").GetComponent<Text>();
            //position tracking 
            PositionCheck();
            currentNode = nodes[currNode].name;


            if (locked == false)
            {

                if (boostingStart == false && zoomCurrent > zoomDefault)
                {
                    //zoomCurrent -= .05f;

                }
                else
                {
                    notAtDefault = false;

                }

                if (boostNorm == false && zoomCurrent > zoomDefault && ionizationDone == true)
                {
                    //zoomCurrent -= .05f;
                }
                else
                {
                    notAtDefault = false;
                }

                if (notAtDefault = true && zoomCurrent > zoomCap)
                {
                    zoomCurrent = zoomCap;
                }

                if (zoomCurrent < 25 && boostingStart == false && lapsEND == false)
                {
                    zoomCurrent = 25;
                }

                if(lapsEND ==true)
                {
                    zoomCurrent = 0;
                    if(IsLocalPlayer)
                    {
                        GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().lapsDone = true;
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                }
                else
                {
                    speedSlider.value = zoomCurrent;

                    float y = nodes[currNode].eulerAngles.y;
                    float x = nodes[currNode].eulerAngles.x;
                    rotSpeed = nodes[currNode].gameObject.GetComponent<savePoint>().RotSpeed;
                    if (transform.position != nodes[currNode].position)
                    {
                        //figure out which is actually moving, more of the purpose of movePosition
                        //attempt to just move foward instead of moving towards and see the results because we should be getting angle fine by the position check

                        //case 2 line 98 using that zoomCUrent is causing issues, maybe why we are getting bouncing but we need that value to still move at the desired speed.
                        //getting the position to move to 
                        transform.position = Vector3.MoveTowards(transform.position, nodes[currNode].position, zoomCurrent * Time.deltaTime);
                        //actually moving it, move position can be used with additional variables  m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
                        //GetComponent<Rigidbody>().MovePosition(pos);
                        //GetComponent<Rigidbody>().MovePosition(pos * Time.deltaTime * 1);
                        if (transform.rotation.y != y)
                        {
                            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, y, 0), rotSpeed * Time.deltaTime);
                        }
                        //additional check for x axis so we can have up or down pieces and player rotation will match the angle the waypoint is 
                        if (transform.rotation.x != x)
                        {
                            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(x, transform.rotation.y, 0), rotSpeedX * Time.deltaTime);
                        }
                    }
                    else
                    {
                        //best place to update once stuff has reached its current waypoint 
                        Debug.Log("nodes");
                        RespawnMG.resetRot = transform.rotation;
                        currNode = (currNode + 1);
                        RespawnMG.GetComponent<RespawnManager>().whatWayPointWasLast = currNode;
                        //transform.rotation = Quaternion.Euler(0, y, 0);
                    }
                }

            }

            
        }

        void PositionCheck()
        {



            Dif = nodes[currNode].position - transform.position;
            distanceToNext = Vector3.Distance(nodes[currNode].position, transform.position);
            DistanceToNext.text = distanceToNext.ToString();
            bool zCheck = false;
            bool xCheck = false;

            if ((Dif.x <= 0.001 && Dif.x >= -0.001))
            {
                xCheck = true;
            }
            if ((Dif.z <= 0.001 && Dif.z >= -0.001))
            {
                zCheck = true;
            }

            if (xCheck == true || zCheck == true)
            {
                //GameObject.Find("RespawnMG").GetComponent<RespawnManager>().resetRot = transform.rotation;


                if (nodes[currNode].tag == "EndTrack")
                {

                    //LapCounter += 1;
                    //lapCnt.text = LapCounter.ToString();
                    //string playerName;
                    //playerName = transform.name;
                    //     LapCount = LapCount + 1;
                    ResetNodes();




                    //nodes[currNode] = nodes[1];
                    atStart = true;
                    //belive this is the issue on second time through the waypoint tagged end is getting ignored
                    //     nodes[currNode] = nodes[1];



                }

                if (nodes[currNode].tag == "START")
                {

                }
                else
                {
                    atStart = false;
                }
            }



        }

        public void ResetNodes(Transform collidedObj = null)
        {
            //Debug.Log(collidedObj);
            currNode = 1;
            gameObject.transform.Find("Capsule").transform.localRotation = Quaternion.Euler(90,0,0);
            gameObject.transform.Find("Capsule").transform.localPosition = new Vector3(0, -7.75f, 0);
            // GeneralTimer.text = Empty.ToString();
            //update refrences so not using GameObject 
            if (LapCount == 1)
            {
                lap1Time = GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().TimeValue - 5.00f;
                transform.GetComponent<DaPickup>().scrCnt = (int)(transform.GetComponent<DaPickup>().scrCnt + (lap1Time / 2.0));
                transform.GetComponent<DaPickup>().scoring.text = transform.GetComponent<DaPickup>().scrCnt.ToString();

            }
            if (LapCount == 2)
            {
                lap2Time = GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().TimeValue;
                transform.GetComponent<DaPickup>().scrCnt = (int)(transform.GetComponent<DaPickup>().scrCnt + (lap1Time / 2.0));
                transform.GetComponent<DaPickup>().scoring.text = transform.GetComponent<DaPickup>().scrCnt.ToString();
            }
            if (LapCount == 3)
            {
                lap3Time = GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().TimeValue;
                transform.GetComponent<DaPickup>().scrCnt = (int)(transform.GetComponent<DaPickup>().scrCnt + (lap1Time / 2.0));
                transform.GetComponent<DaPickup>().scoring.text = transform.GetComponent<DaPickup>().scrCnt.ToString();
            }


            GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().TimeValue = Empty;


            LapCount = LapCount + 1;


            if (LapCount > 3)
            {
                LapCount = LapCount - 1;
                //gameObject.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("VictoryUI").transform.gameObject.SetActive(true);
                lapsEND = true;
                CollisionObj.Global.Swap();
                PostGameParticles.Global.PostGameAwards();
                gameObject.transform.GetComponent<FollowNodes>().zoomCurrent = 0;
                lapAverage = (lap1Time + lap2Time + lap3Time) / 3;
                gameObject.transform.Find("PostRaceInfo").gameObject.SetActive(true);
                gameObject.transform.Find("INGAME_UI_Parent").gameObject.SetActive(false);
                gameObject.transform.Find("PostRaceInfo").transform.Find("UI").gameObject.transform.Find("TotalPoints").GetComponent<Text>().text = transform.GetComponent<DaPickup>().scrCnt.ToString();
                gameObject.transform.Find("PostRaceInfo").transform.Find("UI").gameObject.transform.Find("AverageTime").GetComponent<Text>().text = ((Mathf.Round(lapAverage * 100)) / 100.0).ToString();
                InGameUI.transform.Find("UI").gameObject.transform.Find("Timer Text").GetComponent<Text>().text = "0.00";
                RankingScoring = transform.GetComponent<DaPickup>().scrCnt / lapAverage;
                IsotopeCollection.Global.AddIsotope();
                gameObject.GetComponent<DaPickup>().UpDatePlayerPrefs();
                


            }
            else
            {
                if (!lapsEND)
                {
                    if(collidedObj != null)
                    {
                        StartCoroutine(CollisionHold(collidedObj));

                    }
                    else
                    {
                        StartCoroutine(NoCollisionHold(collidedObj));
                    }
                   

                }

            }


        }


        IEnumerator CollisionHold(Transform collidedobj = null)
        {
            GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().offMenu = false;
            InGameUI.GetComponentInChildren<FadeToWhite>().Fade();
            //GameObject obj = Instantiate((GameObject)Resources.Load("TempPos"));
            //obj.transform.position = transform.position;
            //playerCam.gameObject.GetComponent<SmoothFollow>().target = obj.transform;
            //playerCam.gameObject.GetComponent<SmoothFollow>().followBehind = false;
            yield return new WaitForSeconds(5);
            InGameUI.GetComponentInChildren<FadeToWhite>().ResetFade();
            //playerCam.gameObject.GetComponent<SmoothFollow>().followBehind = false;
            //playerCam.gameObject.GetComponent<SmoothFollow>().target = GetComponentInChildren<RotatePlayer>().transform;
            RespawnMG.savedCheck = RespawnMG.savedStart;
            transform.position = RespawnMG.savedStart;
            RespawnMG.GetComponent<RespawnManager>().whatWayPointWasLast = 1;
            GetComponent<startLock>().Relock();
            lapCnt.text = LapCount.ToString();

        }

        IEnumerator NoCollisionHold(Transform collidedobj = null)
        {
            GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().offMenu = false; 
            //InGameUI.GetComponentInChildren<FadeToWhite>().Fade();
            GameObject obj = Instantiate((GameObject)Resources.Load("TempPos"));
            obj.transform.position = transform.position;
            playerCam.gameObject.GetComponent<SmoothFollow>().target = obj.transform;
            playerCam.gameObject.GetComponent<SmoothFollow>().followBehind = false;
            yield return new WaitForSeconds(5);
            //InGameUI.GetComponentInChildren<FadeToWhite>().ResetFade();
            playerCam.gameObject.GetComponent<SmoothFollow>().followBehind = false;
            playerCam.gameObject.GetComponent<SmoothFollow>().target = GetComponentInChildren<RotatePlayer>().transform;
            RespawnMG.savedCheck = RespawnMG.savedStart;
            transform.position = RespawnMG.savedStart;
            RespawnMG.GetComponent<RespawnManager>().whatWayPointWasLast = 1;
            GetComponent<startLock>().Relock();
            lapCnt.text = LapCount.ToString();

        }

        public void ReadyClick()
        {
            //readyUPServerRpc();
            isReady.Value = true;
            GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<PlayerList>().allClear = true;
        }

        [ServerRpc]
        private void readyUPServerRpc()
        {
            ulong localClientId = NetworkManager.Singleton.LocalClientId;

            if (!NetworkManager.Singleton.ConnectedClients.TryGetValue(localClientId, out NetworkClient networkClient))
            {
                return;
            }
            isReady.Value = true;
        }



    }
}
