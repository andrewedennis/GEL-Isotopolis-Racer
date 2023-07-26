using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MLAPI.NetworkVariable
{
    public class GhostRotate : MonoBehaviour
    {
        public bool moving = false;
        public float timer;
        public bool test = false;
        public bool randomSet = false;
        public float rotateValue;
        public float randomNum;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (transform.parent.GetComponent<FollowNodesGhost>().locked == false)
            {
                test = true;
                StartCoroutine(Movement());
            }
        }

        public IEnumerator Movement()
        {
            if (randomSet == false)
            {
                int random = Random.Range(0, 3);
                if (random == 0)
                {
                    rotateValue = -30;
                }
                if (random == 1)
                {
                    rotateValue = 0;
                }
                if (random == 2)
                {
                    rotateValue = 30;
                }
                randomNum = Random.Range(1.5f, 5);
                moving = true;
                randomSet = true;
            }
            if (timer < randomNum)
            {
                timer += Time.deltaTime;
                transform.RotateAround(transform.parent.position, transform.parent.forward, rotateValue * Time.deltaTime);
            }
            else
            {
                timer = 0f;
                moving = false;
                randomSet = false;
            }
            yield return null;
        }



    }
}