using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MLAPI.NetworkVariable
{
    public class OutOfBounds : MonoBehaviour
    {
        public GameObject player;
        public RespawnManager RespawnMG;
        // Start is called before the first frame update
        void Start()
        {
            if (transform.parent.CompareTag("Player"))
            {
                RespawnMG = gameObject.transform.parent.Find("RespawnMG").GetComponent<RespawnManager>();
            }

            if (transform.parent.CompareTag("Ghost"))
            {
                RespawnMG = gameObject.transform.parent.Find("RespawnMG_Ghost").GetComponent<RespawnManager>();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider check)
        {
            if (check.CompareTag("OutOfBounds"))
            {
                transform.parent.position = RespawnMG.savedCheck;
                transform.parent.eulerAngles = RespawnMG.resetRot.eulerAngles;
            }

        }
    }
}
