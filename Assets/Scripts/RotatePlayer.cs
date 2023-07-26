using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MLAPI.NetworkVariable
{
    public class RotatePlayer : MonoBehaviour
    {
        bool moveLeft;
        bool moveRight;
        public GameObject model;
        float ceiling = 90f;
        float floor = -90f;
        private float rotationSpeed = 30;
        private float driftBuffer = 0.1f;
        public float turnDiff;
        [Range(-1, 1)] public float uiButtonInput = 0;
        int way = 0;
        bool check = true;
        // Start is called before the first frame update
        void Start()
        {
            moveLeft = false;
            moveRight = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.parent.GetComponent<FollowNodes>().locked == false)
            {
                if (uiButtonInput != 0)
                {
                    Movement();
                }
                else
                {
                    //Debug.LogError(Input.GetAxisRaw("Horizontal"));

                    turnDiff = Mathf.Abs(model.transform.localRotation.eulerAngles.z - 180f);
                    if (Input.GetAxisRaw("Horizontal") < 0)
                    {
                        //Debug.LogError(transform.name);
                        transform.RotateAround(transform.parent.position, transform.parent.forward, ((-1f * rotationSpeed) * (Mathf.Pow((turnDiff * driftBuffer), 2))) * Time.deltaTime);

                    }
                    else if (Input.GetAxisRaw("Horizontal") > 0)
                    {

                        transform.RotateAround(transform.parent.position, transform.parent.forward, ((rotationSpeed) * (Mathf.Pow((turnDiff * driftBuffer), 2))) * Time.deltaTime);

                    }

                    float turnInput = Input.GetAxis("Horizontal");

                    //Debug.Log(Input.GetAxis("Horizontal"));
                    //Vector3 newRot = new Vector3(180f,0,Mathf.Clamp(model.transform.localRotation.eulerAngles.z + (turnInput * 1f * Time.deltaTime),ceiling,floor));
                    Vector3 newRot = new Vector3(180f, 0, transform.localRotation.z + (turnInput * 30f));
                    //Quaternion newAngle = Quaternion.Euler(model.transform.localRotation.eulerAngles + new Vector3(0f, 0f,turnInput * 180f * Time.deltaTime));

                    //model.transform.rotation = Quaternion.Euler(newAngle.x, newAngle.y, Mathf.Clamp(newAngle.z, floor, ceiling));
                    //model.transform.rotation = newAngle;
                    //Debug.LogError(turnInput);
                    model.transform.localRotation = Quaternion.Euler(newRot);
                }
            }
        }

        public void MoveLeftPressed()
        {
            moveLeft = true;
            uiButtonInput = uiButtonInput + .1f;
        }

        public void MoveRightPressed()
        {
            moveRight = true;
            uiButtonInput = uiButtonInput - .1f;
        }

        public void MoveLeftUp()
        {
            moveLeft = false;
            uiButtonInput = 0;
        }

        public void MoveRightUp()
        {
            moveRight = false;
            uiButtonInput = 0;
        }

        public void Movement()
        {
            way = 0;
            if (moveLeft)
            {
                way = -1;
                //Debug.LogError("BruhLeft");
                //transform.RotateAround(transform.parent.position, transform.parent.forward, -30 * Time.deltaTime);
                //Debug.LogError(transform.name);
                turnDiff = Mathf.Abs(model.transform.localRotation.eulerAngles.z - 180f);
                transform.RotateAround(transform.parent.position, transform.parent.forward, ((-1f * rotationSpeed) * (Mathf.Pow((turnDiff * driftBuffer), 2))) * Time.deltaTime);
                //Debug.LogError(uiButtonInput);
                //Vector3 newRot = new Vector3(180f, 0, transform.localRotation.z + (uiButtonInput * 30f));



            }
            else if (moveRight)
            {
                way = 1;
                //Debug.LogError("Bruhright");
                turnDiff = Mathf.Abs(model.transform.localRotation.eulerAngles.z - 180f);
                transform.RotateAround(transform.parent.position, transform.parent.forward, ((rotationSpeed) * (Mathf.Pow((turnDiff * driftBuffer), 2))) * Time.deltaTime);
                //Vector3 newRot = new Vector3(180f, 0, transform.localRotation.z + (uiButtonInput * 30f));
                //Vector3 newRot = new Vector3(180f, 0, transform.localRotation.z + (1 * 30f));

                //model.transform.localRotation = Quaternion.Euler(newRot);
                //Debug.LogError(newRot);

                //transform.RotateAround(transform.parent.position, transform.parent.forward, 30 * Time.deltaTime);
            }
            if (moveRight && moveLeft)
            {
                way = 0;
            }
            else
            {
                check = false;
            }

            if (check)
            {
                // lerping force into zero if the force is greater than a threshold (0.01)
                if (Mathf.Abs(uiButtonInput) >= 0.01f)
                {
                    int opositeDir = (uiButtonInput > 0) ? -1 : 1;
                    uiButtonInput += Time.deltaTime * driftBuffer * opositeDir;
                }
                else
                    uiButtonInput = 0;
            }
            else
            {
                // increase force towards desired direction
                uiButtonInput += Time.deltaTime * way * rotationSpeed;
                uiButtonInput = Mathf.Clamp(uiButtonInput, -1, 1);
            }

            if (moveLeft)
            {
                Vector3 newRot = new Vector3(180f, 0, transform.localRotation.z + (uiButtonInput * 30f));

                model.transform.localRotation = Quaternion.Euler(newRot);
                //Debug.LogError(newRot);
            }

            if (moveRight)
            {
                Vector3 newRot = new Vector3(180f, 0, transform.localRotation.z + (uiButtonInput * 30f));

                model.transform.localRotation = Quaternion.Euler(newRot);
                //Debug.LogError(newRot);

            }
        }
    }
}