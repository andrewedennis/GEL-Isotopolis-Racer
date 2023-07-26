using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MLAPI.NetworkVariable
{
    public class FollowNodesGhost : MonoBehaviour
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
        public float lap1Time;
        public float lap2Time;
        public float lap3Time;
        public float lapAverage;
        public int LapCount = 1;
        private Text lapCnt;
        private Text DistanceToNext;
        public bool boostingStart = false;
        public bool boostNorm = false;
        public bool notAtDefault = false;
        public float zoomDefault = 5;
        public float zoomCurrent = 0;
        public float zoomCap = 25;
        public float smoothMove = .5f;
        public bool locked = false;
        public bool ionizationDone = false;
        public float distanceToNext;
        public GameObject boostEffect;
        public Mesh Model;
        public bool lapsEND = false;
        float Empty = 0;
        public float RankingScoring = 0;


        // Start is called before the first frame update
        void Start()
        {
            nodes = GameObject.Find("Nodes").GetComponent<NodeList>().nodes;

            //RespawnMG = GameObject.FindGameObjectWithTag("RespawnManager").GetComponent<RespawnManager>();
            //lapCnt = GameObject.Find("LapCnt").GetComponent<Text>();
            //DistanceToNext = GameObject.Find("DistanceToNext").GetComponent<Text>();
            //boostEffect = gameObject.transform.Find("GhostSpeedLines").gameObject;
            //boostEffect = GameObject.Find("GhostSpeedLines");
            boostEffect.GetComponent<ParticleSystem>().Stop();
            //nodesTest = GameObject.FindGameObjectsWithTag("Start");
        }

        // Update is called once per frame
        void Update()
        {
            Model = gameObject.transform.Find("GhostCapsule").transform.Find("Model").GetComponent<MeshFilter>().mesh;
            RespawnMG = gameObject.transform.Find("RespawnMG_Ghost").GetComponent<RespawnManager>();
            //lapCnt.text = LapCount.ToString();
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
                    zoomCurrent -= .05f;
                }
                else
                {
                    notAtDefault = false;
                }

                if (notAtDefault = true && zoomCurrent > zoomCap)
                {
                    zoomCurrent = zoomCap;
                }

                if (zoomCurrent < 25 && boostingStart == false)
                {
                    zoomCurrent = 25;
                }
                if (lapsEND == true)
                {
                    zoomCurrent = 0;
                    if (transform.gameObject.name == "BeanGhost(Clone)")
                    {
                        GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().ghost1LapsDone = true;
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                        transform.Find("GhostCapsule").GetComponent<GhostRotate>().enabled = false;
                        //transform.transform.rotation = Quaternion.Euler(0, 180, 30);
                    }
                    if (transform.gameObject.name == "BeanGhost 2(Clone)")
                    {
                        GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().ghost2LapsDone = true;
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                        transform.Find("GhostCapsule").GetComponent<GhostRotate>().enabled = false;
                        //transform.transform.rotation = Quaternion.Euler(0, 180, -30);
                    }
                }

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

                    //Vector3 pos = Vector3.MoveTowards(transform.position, nodes[currNode].position, zoomCurrent * Time.deltaTime);
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
                    RespawnMG.resetRot = transform.rotation;
                    currNode = (currNode + 1) % nodes.Length;
                    RespawnMG.GetComponent<RespawnManager>().whatWayPointWasLast = currNode;

                    //transform.rotation = Quaternion.Euler(0, y, 0);
                }
            }
        }

        void PositionCheck()
        {



            Dif = nodes[currNode].position - transform.position;
            distanceToNext = Vector3.Distance(nodes[currNode].position, transform.position);
            //DistanceToNext.text = distanceToNext.ToString();
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


                if (nodes[currNode].tag == "EndTrack")
                {

                    ResetNodes();
                    atStart = true;



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

        public void ResetNodes()
        {
            if (transform.gameObject.name == "BeanGhost(Clone)")
            {



                if (LapCount == 1)
                {
                    lap1Time = GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().Ghost1TimeValue - 5.00f;
                    transform.GetComponent<DaPickup>().scrCnt = (int)(transform.GetComponent<DaPickup>().scrCnt + (lap1Time / 2.0));
                    transform.GetComponent<DaPickup>().scoring.text = transform.GetComponent<DaPickup>().scrCnt.ToString();

                }
                if (LapCount == 2)
                {
                    lap2Time = GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().Ghost1TimeValue;
                    transform.GetComponent<DaPickup>().scrCnt = (int)(transform.GetComponent<DaPickup>().scrCnt + (lap1Time / 2.0));
                    transform.GetComponent<DaPickup>().scoring.text = transform.GetComponent<DaPickup>().scrCnt.ToString();
                }
                if (LapCount == 3)
                {
                    lap3Time = GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().Ghost1TimeValue;
                    transform.GetComponent<DaPickup>().scrCnt = (int)(transform.GetComponent<DaPickup>().scrCnt + (lap1Time / 2.0));
                    transform.GetComponent<DaPickup>().scoring.text = transform.GetComponent<DaPickup>().scrCnt.ToString();
                }

                GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().Ghost1TimeValue = Empty;

                currNode = 1;
                LapCount = LapCount + 1;
                RespawnMG.savedCheck = RespawnMG.savedStart;
                transform.position = RespawnMG.savedStart;
                RespawnMG.GetComponent<RespawnManager>().whatWayPointWasLast = 1;

                if (LapCount > 3)
                {
                    LapCount = LapCount - 1;
                    //gameObject.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("VictoryUI").transform.gameObject.SetActive(true);
                    lapsEND = true;
                    gameObject.transform.GetComponent<FollowNodesGhost>().zoomCurrent = 0;
                    lapAverage = (lap1Time + lap2Time + lap3Time) / 3;
                    //gameObject.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("PostRaceInfo").transform.gameObject.SetActive(true);
                    //gameObject.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("PostRaceInfo").transform.Find("TotalPoints").GetComponent<Text>().text = transform.GetComponent<DaPickup>().scrCnt.ToString();
                    //gameObject.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("PostRaceInfo").transform.Find("AverageTime").GetComponent<Text>().text = lapAverage.ToString();
                    RankingScoring = transform.GetComponent<DaPickup>().scrCnt / lapAverage;

                }
            }
            else
            {
               
                if (LapCount == 1)
                {
                    lap1Time = GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().Ghost2TimeValue - 5.00f;
                    transform.GetComponent<DaPickup>().scrCnt = (int)(transform.GetComponent<DaPickup>().scrCnt + (lap1Time / 2.0));
                    transform.GetComponent<DaPickup>().scoring.text = transform.GetComponent<DaPickup>().scrCnt.ToString();

                }
                if (LapCount == 2)
                {
                    lap2Time = GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().Ghost2TimeValue;
                    transform.GetComponent<DaPickup>().scrCnt = (int)(transform.GetComponent<DaPickup>().scrCnt + (lap1Time / 2.0));
                    transform.GetComponent<DaPickup>().scoring.text = transform.GetComponent<DaPickup>().scrCnt.ToString();
                }
                if (LapCount == 3)
                {
                    lap3Time = GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().Ghost2TimeValue;
                    transform.GetComponent<DaPickup>().scrCnt = (int)(transform.GetComponent<DaPickup>().scrCnt + (lap1Time / 2.0));
                    transform.GetComponent<DaPickup>().scoring.text = transform.GetComponent<DaPickup>().scrCnt.ToString();
                }

                GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().Ghost2TimeValue = Empty;

                currNode = 1;
                LapCount = LapCount + 1;
                RespawnMG.savedCheck = RespawnMG.savedStart;
                transform.position = RespawnMG.savedStart;
                RespawnMG.GetComponent<RespawnManager>().whatWayPointWasLast = 1;

                if (LapCount > 3)
                {
                    LapCount = LapCount - 1;
                    //gameObject.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("VictoryUI").transform.gameObject.SetActive(true);
                    lapsEND = true;
                    gameObject.transform.GetComponent<FollowNodesGhost>().zoomCurrent = 0;
                    lapAverage = (lap1Time + lap2Time + lap3Time) / 3;
                    //gameObject.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("PostRaceInfo").transform.gameObject.SetActive(true);
                    //gameObject.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("PostRaceInfo").transform.Find("TotalPoints").GetComponent<Text>().text = transform.GetComponent<DaPickup>().scrCnt.ToString();
                    //gameObject.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("PostRaceInfo").transform.Find("AverageTime").GetComponent<Text>().text = lapAverage.ToString();
                    RankingScoring = transform.GetComponent<DaPickup>().scrCnt / lapAverage;

                }
            }
        }
    }

}