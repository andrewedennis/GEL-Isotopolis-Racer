using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MLAPI.NetworkVariable
{
    public class ProductionTarget : MonoBehaviour
    {

        public GameObject sweetSpot;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.GetComponent<ParticleRacer>())
            {
                Debug.Log("Play Crash SFX");
                FindObjectOfType<SFXManager>().Play("Crash");

                RespawnManager.scenario.ResetPlayer(collision.gameObject);
            }

        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<ParticleRacer>())
            {
                Debug.Log("Play Crash SFX");
                FindObjectOfType<SFXManager>().Play("Crash");

                RespawnManager.scenario.ResetPlayer(other.gameObject);
            }
        }

        void AdjustProductionTarget()
        {



        }
    }
}