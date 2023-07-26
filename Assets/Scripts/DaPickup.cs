using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MLAPI.NetworkVariable
{
    public class DaPickup : MonoBehaviour
    {

        public Text scoring;
        public int scrCnt;
        public GameObject whatScriptOn;
        public float boostMult = .5f;
        public int boostLength = 3;
        PlayerCharge charge;
        public float RankingScoring = 0;
        public GameObject sign;


        private void Start()
        {
            charge = gameObject.transform.GetComponent<PlayerCharge>(); 
            scoring = gameObject.transform.Find("INGAME_UI_Parent").gameObject.transform.Find("UI").gameObject.transform.Find("PickupCnt").GetComponent<Text>();
            //sign = GameObject.Find("sign_buddy");
            whatScriptOn = gameObject;
            scrCnt = 0;
        }

        private void OnTriggerStay(Collider other)
        {


            if (other.GetComponent<ParticleBeamSegment>())
            {

                ///charge.IncreasePlayerCharge();
                Debug.Log("charging");
            }

        }

        public void UpDatePlayerPrefs()
        {
            RankingScoring = transform.GetComponent<FollowNodes>().RankingScoring;
            PlayerPrefs.SetFloat("SaveScore", PlayerPrefs.GetFloat("SaveScore") + RankingScoring);
            PlayerPrefs.Save();
            //Debug.LogError(PlayerPrefs.GetFloat("SaveScore"));
        }

        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (whatScriptOn.tag == "Player")
            {
                if (other.CompareTag("Pickup"))
                {
                   // Destroy(other.gameObject);
                    scrCnt += 1;
                    scoring.text = scrCnt.ToString();
                }

                if (other.CompareTag("Boost"))
                {
                    //Destroy(other.gameObject);
                    StartCoroutine(Boost());
                    //should boost pick up just add to speed or be a temp boost, this is temp boost

                }
                if (other.CompareTag("Green Slices"))
                {

                    scrCnt += 10;
                    scoring.text = scrCnt.ToString();
                    StartCoroutine(Boost());
                }
                if (other.name == "Production_Target_LID")
                {

                    if (other.GetComponent<ProductionTargetSweetSpot>().isFinal == true)
                    {
                        scrCnt += 50;
                        scoring.text = scrCnt.ToString();
                        GetComponent<FollowNodes>().ResetNodes(other.transform);
                        scrCnt += 50;
                    }
                    else
                    {


                        scrCnt += 20;
                        scoring.text = scrCnt.ToString();
                    }
                }
                if (other.name == "ShieldColliders")
                {
                   
                    scrCnt += 10;
                    scoring.text = scrCnt.ToString();
                    GetComponent<FollowNodes>().ResetNodes(other.transform);
                }
                if (other.name == "newEnd")
                {
                    GetComponent<FollowNodes>().ResetNodes(other.transform);
                }
                if (other.name == "carbon_atom(Clone)")
                {
                    GetComponent<FollowNodes>().ResetNodes(other.transform);
                }
                if (other.name == "SignTrigger")
                {
                    
                    int signNumber = other.GetComponent<SignTrigger>().getNumber();
                    //Debug.LogError("sign_buddy" + signNumber);
                    sign = GameObject.Find("sign_buddy" + signNumber);
                    sign.gameObject.transform.GetComponent<SignMoveIn>().SetMove();
                    
                }

            }
            //else ai or other object is coliding with pickup 
            else
            {
                if (other.CompareTag("Pickup"))
                {
                    Debug.Log("Play Boost SFX");
                    FindObjectOfType<SFXManager>().Play("Boost");
                    //Destroy(other.gameObject);
                }

                if (other.CompareTag("Boost"))
                {
                    scrCnt += 10;
                    //Destroy(other.gameObject);
                    StartCoroutine(Boost());
                    //should boost pick up just add to speed or be a temp boost, this is temp boost

                }
                if (other.CompareTag("Green Slices"))
                {
                    Debug.Log("Play Pass Through SFX");
                    FindObjectOfType<SFXManager>().Play("Pass");
                    scrCnt += 10;
                    scoring.text = scrCnt.ToString();
                    StartCoroutine(Boost());
                }
                if (other.name == "Production_Target_LID")
                {

                    if (other.GetComponent<ProductionTargetSweetSpot>().isFinal == true)
                    {
                        scrCnt += 50;
                        //scoring.text = scrCnt.ToString();
                        GetComponent<FollowNodesGhost>().ResetNodes();
                        scrCnt += 50;
                    }
                    else
                    {
                        scrCnt += 20;
                        //scoring.text = scrCnt.ToString();
                    }
                }
                if (other.name == "ShieldColliders")
                {

                    scrCnt += 10;
                    //scoring.text = scrCnt.ToString();
                    GetComponent<FollowNodesGhost>().ResetNodes();
                }
                if (other.name == "newEnd")
                {
                    GetComponent<FollowNodesGhost>().ResetNodes();
                }
                if (other.name == "carbon_atom(Clone)")
                {
                    GetComponent<FollowNodesGhost>().ResetNodes();
                }
            }

            /* James 8/13
            
            if(other.GetComponent<ProductionTargetSweetSpot>() != null)
            {

                if(other.GetComponent<ProductionTargetSweetSpot>().isFinal){
                    scrCnt += 50;
                    scoring.text = scrCnt.ToString();
                    GetComponent<FollowNodes>().ResetNodes();
                    scrCnt += 50;
                }else{


                    scrCnt += 20;
                    scoring.text = scrCnt.ToString();
                }
            }

            if(other.GetComponent<ProductionTargetShield>() != null)
            {

                scrCnt += 10;
                scoring.text = scrCnt.ToString();
                GetComponent<FollowNodes>().ResetNodes();
            }
            

            if(other.GetComponent<RFQGreenSlice>()){

                scrCnt += 10;
                scoring.text = scrCnt.ToString();
                StartCoroutine(Boost());
            }
            */
            

        }

        

        IEnumerator Boost()
        {

            //player.GetComponent<OffGround>().boostNorm = true;
            //player.GetComponent<OffGround>().zoomCurrent = player.GetComponent<OffGround>().zoomCurrent * boostMult;
            //player.GetComponent<OffGround>().notAtDefault = true;
            //yield return new WaitForSeconds(boostLength);
            //player.GetComponent<OffGround>().boostNorm = false;

            if (whatScriptOn.tag == "Player")
            {
                Debug.Log("Play Boost SFX");
                FindObjectOfType<SFXManager>().Play("Boost");

                whatScriptOn.GetComponent<FollowNodes>().boostNorm = true;
                whatScriptOn.GetComponent<FollowNodes>().zoomCurrent = whatScriptOn.GetComponent<FollowNodes>().zoomCurrent + (whatScriptOn.GetComponent<FollowNodes>().zoomCurrent * boostMult);
                whatScriptOn.GetComponent<FollowNodes>().notAtDefault = true;
                whatScriptOn.GetComponent<FollowNodes>().boostEffect.GetComponent<ParticleSystem>().Play();
                yield return new WaitForSeconds(boostLength);
                whatScriptOn.GetComponent<FollowNodes>().boostNorm = false;
                whatScriptOn.GetComponent<FollowNodes>().boostEffect.GetComponent<ParticleSystem>().Stop();
            }
            else
            {
                whatScriptOn.GetComponent<FollowNodesGhost>().boostNorm = true;
                whatScriptOn.GetComponent<FollowNodesGhost>().zoomCurrent = whatScriptOn.GetComponent<FollowNodesGhost>().zoomCurrent + (whatScriptOn.GetComponent<FollowNodesGhost>().zoomCurrent * boostMult);
                whatScriptOn.GetComponent<FollowNodesGhost>().notAtDefault = true;
                whatScriptOn.GetComponent<FollowNodesGhost>().boostEffect.GetComponent<ParticleSystem>().Play();
                yield return new WaitForSeconds(boostLength);
                whatScriptOn.GetComponent<FollowNodesGhost>().boostNorm = false;
                whatScriptOn.GetComponent<FollowNodesGhost>().boostEffect.GetComponent<ParticleSystem>().Stop();
            }


        }
    }
}
