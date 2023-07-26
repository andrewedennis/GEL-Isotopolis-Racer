using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MLAPI.NetworkVariable
{
    public class inGameScoreTrack : MonoBehaviour
    {
        public int playerCount;
        public float playerScore;
        public int ranking;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        public void Update()
        {
            playerCount = GameObject.Find("GameObjectToBeUsedForValuesAtStart").GetComponent<PlayerList>().playerList.Count;
            
            //case no other players, compare to the two other ghosts 
            if(playerCount == 1)
            {
                playerScore = gameObject.GetComponent<DaPickup>().scrCnt;
                if (GameObject.Find("BeanGhost(Clone)") != null)
                {
                    if (playerScore > GameObject.Find("BeanGhost(Clone)").GetComponent<DaPickup>().scrCnt)
                    {
                        if (playerScore > GameObject.Find("BeanGhost 2(Clone)").GetComponent<DaPickup>().scrCnt)
                        {
                            ranking = 1;
                            gameObject.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("PositionCnt").GetComponent<Text>().text = 1.ToString();
                        }
                    }
                    else if (playerScore > GameObject.Find("BeanGhost 2(Clone)").GetComponent<DaPickup>().scrCnt)
                    {
                        ranking = 2;
                        gameObject.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("PositionCnt").GetComponent<Text>().text = 2.ToString();
                    }
                    else if (playerScore < GameObject.Find("BeanGhost 2(Clone)").GetComponent<DaPickup>().scrCnt)
                    {
                        ranking = 3;
                        gameObject.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("PositionCnt").GetComponent<Text>().text = 3.ToString();
                    }
                }

            }

            if (playerCount == 2)
            {

            }

            if (playerCount == 3)
            {

            }
        }

        
    }
}
