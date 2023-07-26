using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MLAPI.NetworkVariable
{
    public class startLockGhost : MonoBehaviour
    {
        public Text time;
        public float timeCnt;
        public bool downDone;
        public bool Begin = false;
        public int numClicks;
        public Text Clicks;
        public GameObject IonizeBut;
        public GameObject ghost;
        public float clickConversion = .5f;
        public float zoomDefault;
        public bool lobbyReady = false;
        public bool prt1 = false;


        // Start is called before the first frame update
        void Start()
        {
            //IonizeBut = GameObject.Find("IonizeButton");
            ghost = gameObject;
            time = GameObject.Find("CntDown").GetComponent<Text>();
            //Clicks = GameObject.Find("ClkCount").GetComponent<Text>();
            timeCnt = 3;
            gameObject.transform.GetComponent<FollowNodesGhost>().locked = true;
            //StartCoroutine(start());
            //downDone = false;
            //numClicks = 0;
            //zoomDefault = ghost.GetComponent<FollowNodesGhost>().zoomDefault;
        }


        //zoom is variable of offground that controls speed, how should we effect this for momentary boost at start 
        // Update is called once per frame
        void Update()
        {
            lobbyReady = !GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<PlayerList>().stopStart;

            if (lobbyReady == true && prt1 == false)
            {
                //readyButton.SetActive(false)
                StartCoroutine(start());
                downDone = false;
                numClicks = 0;
                zoomDefault = gameObject.GetComponent<FollowNodesGhost>().zoomDefault;
                prt1 = true;
            }


            if (downDone == false && prt1 == true)
            {
                timeCnt -= Time.deltaTime;
                time.text = Mathf.Round(timeCnt).ToString() ;
                if (timeCnt < 0.00)
                {
                    downDone = true;
                    timeCnt = 0.00f;
                    time.text = Mathf.Round(timeCnt).ToString() ;
                    time.enabled = false;
                }
            }
            else
            {
                //spawnedBeam.SetActive(false);
            }

        }


        IEnumerator start()
        {
            
            yield return new WaitForSeconds(3);
            Debug.Log("starting");
            gameObject.transform.GetComponent<FollowNodesGhost>().locked = false;
            StartCoroutine(applyStartBoost());
            GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().offMenu = true;

        }

        IEnumerator applyStartBoost()
        {
            ghost.GetComponent<FollowNodesGhost>().boostingStart = true;
            numClicks = Random.Range(15, 30);
            ghost.GetComponent<FollowNodesGhost>().zoomCurrent = ghost.GetComponent<FollowNodesGhost>().zoomDefault + (clickConversion * numClicks);
            ghost.GetComponent<FollowNodesGhost>().notAtDefault = true;
            ghost.GetComponent<FollowNodesGhost>().boostEffect.GetComponent<ParticleSystem>().Play();
            yield return new WaitForSeconds(3);
            ghost.GetComponent<FollowNodesGhost>().boostingStart = false;
            ghost.GetComponent<FollowNodesGhost>().ionizationDone = true;
            ghost.GetComponent<FollowNodesGhost>().boostEffect.GetComponent<ParticleSystem>().Stop();


            //float oldZoom = player.GetComponent<OffGround>().zoom;
            //player.GetComponent<OffGround>().zoom = player.GetComponent<OffGround>().zoom + (clickConversion * numClicks);
            //yield return new WaitForSeconds(3);
            //player.GetComponent<OffGround>().zoom = oldZoom;
        }

        public void CountClicks()
        {
            if (downDone == false)
            {
                //Debug.Log("click");
                numClicks += 1;
                Clicks.text = numClicks.ToString();

            }
        }

        public void Relock()
        {
            ghost.GetComponent<FollowNodesGhost>().boostingStart = true;
            gameObject.transform.GetComponent<FollowNodesGhost>().notAtDefault = true;
            gameObject.transform.GetComponent<FollowNodesGhost>().locked = false;
            gameObject.transform.GetComponent<FollowNodesGhost>().locked = true;
            time.enabled = true;
            timeCnt = 5;
            downDone = false;
            numClicks = 0;
            //IonizeBut.SetActive(true);
            StartCoroutine(start());
            downDone = false;
        }
    }
}
