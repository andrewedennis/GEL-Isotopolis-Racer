using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MLAPI.NetworkVariable
{
    public class CartPosition : MonoBehaviour
    {
        public RespawnManager RespawnMG;
        public KartController kartControl;
        public bool OutOfBounds = false;
        public bool atStart = true;

        // Start is called before the first frame update
        void Start()
        {

            //RespawnMG = GameObject.FindGameObjectWithTag("RespawnManager").GetComponent<RespawnManager>();
            //kartControl = this.GetComponent<KartController>();

            //need to have rotation being set here
        }

        // Update is called once per frame
        void Update()
        {

            if (transform.tag == "Player")
            {
                RespawnMG = transform.GetComponent<FollowNodes>().RespawnMG;
            }
            else
            {
                RespawnMG = transform.GetComponent<FollowNodesGhost>().RespawnMG;
            }

            if (atStart == true)
            {
                transform.position = RespawnMG.savedCheck;
                transform.localRotation = RespawnMG.resetRot;
                atStart = false;
            }
            if (OutOfBounds == true)
            {
                Debug.Log("reseting");
                transform.position = RespawnMG.savedCheck;
                transform.eulerAngles = RespawnMG.resetRot.eulerAngles;
                OutOfBounds = false;
            }
            //if (transform.position.y <= -2)
            //{

            //    transform.position = RespawnMG.savedCheck;
            //    transform.eulerAngles = RespawnMG.resetRot.eulerAngles;
            //    //this.GetComponent<KartController>().currentbrakeForce = 2000f;
            //    //kartControl.acceleration = 0;

            //    //this.GetComponent<KartController>().currentbrakeForce = 0f;
            //    //kartControl.frontLeftWheelCollider.brakeTorque = kartControl.currentbrakeForce;
            //    //kartControl.frontRightWheelCollider.brakeTorque = kartControl.currentbrakeForce;
            //    //kartControl.rearLeftWheelCollider.brakeTorque = kartControl.currentbrakeForce;
            //    //kartControl.rearRightWheelCollider.brakeTorque = kartControl.currentbrakeForce;


            //}

            //resetPosition
            if (transform.tag == "Player")
            {
                if (Input.GetKey("f"))
                {
                    transform.position = RespawnMG.savedCheck;
                    transform.eulerAngles = RespawnMG.resetRot.eulerAngles;

                    //old reset that used to be in cart controller
                    //Reset.eulerAngles = new Vector3(0, transform.rotation.eulerAngles.y, 0);
                    //GetComponent<Transform>().eulerAngles = Reset.eulerAngles;

                }
            }

            if (transform.tag == "Ghost")
            {
                if (Input.GetKey("g"))
                {
                    Debug.LogError("G");
                    transform.position = RespawnMG.savedCheck;
                    transform.eulerAngles = RespawnMG.resetRot.eulerAngles;

                    //old reset that used to be in cart controller
                    //Reset.eulerAngles = new Vector3(0, transform.rotation.eulerAngles.y, 0);
                    //GetComponent<Transform>().eulerAngles = Reset.eulerAngles;

                }
            }
        }
    }
}