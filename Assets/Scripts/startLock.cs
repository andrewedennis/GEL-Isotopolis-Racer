using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MLAPI.NetworkVariable
{
    public class startLock : MonoBehaviour
    {
        public Text time;
        public float timeCnt;
        public bool downDone;
        public bool Begin = false;
        public int numClicks;
        public Text Clicks;
        public GameObject IonizeBut;
        public GameObject player;
        public float clickConversion = .5f;
        public float zoomDefault;
        public bool lobbyReady = false;
        public bool prt1 = false;
        public GameObject readyButton;
        public bool allowIonize = false;

        //public GameObject spawnedBeam;
        public bool scriptStart = false;

        // Start is called before the first frame update
        void Start()
        {
            //IonizeBut = GameObject.Find("IonizeButton");
            //player = GameObject.FindGameObjectWithTag("Player");

            //time = GameObject.Find("CntDown").GetComponent<Text>();
            //Clicks = GameObject.Find("ClkCount").GetComponent<Text>();
            //timeCnt = 5;
            //gameObject.transform.GetComponent<FollowNodes>().locked = true;
            //StartCoroutine(start());
            //downDone = false;
            //numClicks = 0;
            //zoomDefault = player.GetComponent<FollowNodes>().zoomDefault;
        }


        //zoom is variable of offground that controls speed, how should we effect this for momentary boost at start 
        // Update is called once per frame
        void Update()
        {
            //readyButton = transform.Find("ReadyButton").gameObject;
            IonizeBut = gameObject.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("IonizeButton").gameObject;
            player = gameObject;
            time = gameObject.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("CntDown").GetComponent<Text>();
            Clicks = gameObject.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("ClkCount").GetComponent<Text>();
            if (scriptStart == false)
            {
                timeCnt = 5;
                gameObject.transform.GetComponent<FollowNodes>().locked = true;
                scriptStart = true;

            }

            lobbyReady = !GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<PlayerList>().stopStart;
            if (lobbyReady == true && prt1 == false)
            {
                GameObject.Find("LobbyFullCanvas").transform.Find("Text").gameObject.SetActive(false);
                allowIonize = true;
                readyButton.SetActive(false);
                StartCoroutine(start());
                downDone = false;
                numClicks = 0;
                zoomDefault = player.GetComponent<FollowNodes>().zoomDefault;
                prt1 = true;
            }

            if (downDone == false && prt1 == true)
            {
                //IonizeBut.GetComponent<Button>().onClick.AddListener(CountClicks);
                timeCnt -= Time.deltaTime;
                //time.text = Mathf.Round(timeCnt).ToString();

                if (!time.GetComponent<Animation>().isPlaying){
                    time.GetComponent<Animation>().Play();
                }


                if (timeCnt < 1.00)
                {
                    downDone = true;
                    timeCnt = 0.00f;
                    //time.text = Mathf.Round(timeCnt).ToString();
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
            yield return new WaitForSeconds(4);
            gameObject.transform.GetComponent<FollowNodes>().locked = false;
            StartCoroutine(applyStartBoost());
            GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<WorldTimer>().offMenu = true;

        }

        IEnumerator applyStartBoost()
        {
            IonizeBut.SetActive(false);
            player.GetComponent<FollowNodes>().boostingStart = true;
            numClicks = Random.Range(15, 30);
            player.GetComponent<FollowNodes>().zoomCurrent = player.GetComponent<FollowNodes>().zoomDefault + (clickConversion * numClicks);
            player.GetComponent<FollowNodes>().notAtDefault = true;
            player.GetComponent<FollowNodes>().boostEffect.GetComponent<ParticleSystem>().Play();
            yield return new WaitForSeconds(3);
            player.GetComponent<FollowNodes>().boostingStart = false;
            player.GetComponent<FollowNodes>().ionizationDone = true;
            player.GetComponent<FollowNodes>().boostEffect.GetComponent<ParticleSystem>().Stop();
            //GetComponent<PlayerCharge>().EndIonization(); James 8/13

            //float oldZoom = player.GetComponent<OffGround>().zoom;
            //player.GetComponent<OffGround>().zoom = player.GetComponent<OffGround>().zoom + (clickConversion * numClicks);
            //yield return new WaitForSeconds(3);
            //player.GetComponent<OffGround>().zoom = oldZoom;
        }

        public void CountClicks()
        {
            if (allowIonize == true)
            {
                //Debug.Log("click");
                Debug.Log("Play Ionize SFX");
                FindObjectOfType<SFXManager>().Play("Ionize");
                numClicks += 1;
                Clicks.text = numClicks.ToString();

                //spawnedBeam.SetActive(true);

                //GetComponent<PlayerCharge>().Ionize(); James 8/13

            }
        }

        public void Relock()
        {
            player.GetComponent<FollowNodes>().boostingStart = true;
            gameObject.transform.GetComponent<FollowNodes>().notAtDefault = true;
            gameObject.transform.GetComponent<FollowNodes>().locked = true;
            time.enabled = true;
            timeCnt = 5;
            downDone = false;
            numClicks = 0;
            //IonizeBut.SetActive(true);
            StartCoroutine(start());
            //GetComponent<FollowNodes>().InGameUI.transform.Find("UI").gameObject.transform.Find("Timer Text").GetComponent<Text>().text = "0.00";
            downDone = false;
        }
    }
}

