using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MLAPI.NetworkVariable
{
    public class savePoint : MonoBehaviour
    {
        private RespawnManager RespawnMG;
        public GameObject player;
        private Text lapCnt;
        public int LapCounter;
        public int whatCheckpoint;
        public Vector3 Chkpostion;
        public float RotSpeed = .5f;
        //public bool atStart = true;
        // Start is called before the first frame update
        void Start()
        {
            // RespawnMG = GameObject.FindGameObjectWithTag("RespawnManager").GetComponent<RespawnManager>();
            //player = GameObject.FindGameObjectWithTag("Player");
            //lapCnt = GameObject.Find("LapCnt").GetComponent<Text>();
            //LapCounter = 1;
            //Chkpostion = gameObject.transform.position;
        }
        /*
        // Update is called once per frame
        void OnTriggerEnter(Collider check)
        {
            //this is going to trigger for every player going inside 
            if (check.CompareTag("Player"))
            {
                RespawnMG.savedCheck.position = transform.position;
                RespawnMG.resetRot.eulerAngles = new Vector3(0, player.transform.rotation.eulerAngles.y, 0);
                player.GetComponent<OffGround>().whatCheck = gameObject.GetComponent<savePoint>().whatCheckpoint;
                if (transform.tag == "Start")
                {
                    if (player.GetComponent<OffGround>().atStart == false)
                    {
                        //LapCounter += 1;
                        //lapCnt.text = LapCounter.ToString();
                        string playerName;
                        playerName = check.name;
                        GameObject.Find(playerName).GetComponent<OffGround>().Lapcount = GameObject.Find(playerName).GetComponent<OffGround>().Lapcount + 1;


                    }
                    player.GetComponent<OffGround>().atStart = true;
                }
                else
                {
                    player.GetComponent<OffGround>().atStart = false;
                }

            }

        }
        */
        //void OnTriggerEnter2D(Collider2D check)
        //{
        //    Debug.Log("CircleCheck");
        //    if (check.CompareTag("Player"))
        //    {
        //        RespawnMG.savedCheck = transform.position;
        //        RespawnMG.resetRot.eulerAngles = new Vector3(0, player.transform.rotation.eulerAngles.y, 0);
        //        if (transform.tag == "Start")
        //        {
        //            if (player.GetComponent<KartController>().atStart == false)
        //            {
        //                LapCounter += 1;
        //                lapCnt.text = LapCounter.ToString();
        //            }
        //            player.GetComponent<KartController>().atStart = true;
        //        }
        //        else
        //        {
        //            player.GetComponent<KartController>().atStart = false;
        //        }

        //    }

        //}
    }

}