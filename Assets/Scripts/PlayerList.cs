using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace MLAPI.NetworkVariable
{
    public class PlayerList : MonoBehaviour
    {
        public List<GameObject> playerList = new List<GameObject>();
        public NetworkVariable<List<GameObject>> playerListNetwork = new NetworkVariable<List<GameObject>>();
        public bool stopStart = true;
        public bool allClear = true;
        //music component given notes by alec
        public GameObject musicManager;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
            foreach (GameObject p in GameObject.FindGameObjectsWithTag("Player"))
            {
                playerList.Add(p);
                playerList = playerList.Distinct().ToList();
            }
            
            /*
            foreach (GameObject p in playerList)
            {

                if (p.GetComponent<FollowNodes>().isReady.Value == false)
                {
                    allClear = false;
                }

            }
            */
            /*
            foreach (GameObject p in playerList)
            {
                p.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.SetActive(true);
            }
            */
            if (allClear == true)
            {
                stopStart = false;
            }
            else
            {
                stopStart = true;
            }
            //musicManager = GameObject.Find("BeanWORKINGFROMMAIN(Clone)").transform.Find("AudioManager").gameObject;

            if (allClear == true)
            {
                //musicManager.transform.Find("MusicManager").transform.gameObject.SetActive(true);
            }
        }
    }

}
