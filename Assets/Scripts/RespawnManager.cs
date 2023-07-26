using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MLAPI.NetworkVariable
{
    public class RespawnManager : MonoBehaviour
    {
        public Vector3 savedCheck;
        public Vector3 respawnPosition;
        public int whatWayPointWasLast = 69420;
        public Vector3 LastWayPointPosition;
        public Vector3 savedStart;
        public Quaternion resetRot;
        public static RespawnManager scenario;
        public GameObject victoryUI;
        public GameObject player;
        // Start is called before the first frame update
        private void Awake()
        {
            //if (scenario == null)
            //{
            //    scenario = this;
            //    DontDestroyOnLoad(scenario);
            //}
            //else Destroy(gameObject);

            savedCheck = GameObject.Find("Nodes").GetComponent<NodeList>().nodes[0].position;
            savedStart = savedCheck;

            //WE ARE NOT GETTING THE RESET ROT FROM ANYWHERE AT BEGIN
            //resetRot = 
        }

        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            savedCheck = LastWayPointPosition;
            respawnPosition = savedCheck;
            if (gameObject.transform.parent.tag == "Player")
            {
                if (gameObject.transform.parent.GetComponent<startLock>().downDone == true)
                {
                    //null check
                    if(whatWayPointWasLast != 69420)
                    {
                        LastWayPointPosition = NodeList.Global.nodes[whatWayPointWasLast].position;

                    }

                }
            }

            if (gameObject.transform.parent.tag == "Ghost")
            {
                if (gameObject.transform.parent.GetComponent<startLockGhost>().downDone == true)
                {
                    //null check
                    if (whatWayPointWasLast != 69420)
                    {
                        LastWayPointPosition = NodeList.Global.nodes[whatWayPointWasLast].position;

                    }
                }
            }


        }

        public void ResetPlayer(GameObject player)
        {
            if (player.GetComponent<FollowNodes>().LapCount > 3)
            {

                victoryUI.SetActive(true);

            }
            else
            {

                player.GetComponent<FollowNodes>().ResetNodes();
                //player.GetComponent<OffGround>().atStart = true;
                player.transform.position = savedStart;
                player.GetComponent<startLock>().Relock();
            }


        }
    }
}
