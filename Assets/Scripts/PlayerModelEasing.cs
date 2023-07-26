using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MLAPI.NetworkVariable
{

    public class PlayerModelEasing : MonoBehaviour
    {
        GameObject playerModel;
        RotatePlayer rt;

        public float maxLean;
        public float leanRate;

        // Start is called before the first frame update
        void Start()
        {
           rt = GetComponent<RotatePlayer>();
        }

        // Update is called once per frame
        void Update()
        {
            //if (rt.moveRight)
            //{

            //    float test = Mathf.Lerp(transform.rotation.eulerAngles.z, maxLean, leanRate);
            //    playerModel.transform.rotation = Quaternion.Euler(new Vector3(playerModel.transform.eulerAngles.x, playerModel.transform.eulerAngles.y, test));

            //}else if (rt.moveLeft)
            //{

            //    float test = Mathf.Lerp(transform.rotation.eulerAngles.z, -1 * maxLean, leanRate);
            //    playerModel.transform.rotation = Quaternion.Euler(new Vector3(playerModel.transform.eulerAngles.x, playerModel.transform.eulerAngles.y, test));
            //}
            //else
            //{
                
                
            //}
        }



    }
}