using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MLAPI.NetworkVariable
{
    public class PlayerCharge : MonoBehaviour
    {
        FollowNodes followNodes;
        enum PlayerChargeState { ionization, notCharged, charged, decaying };
        [SerializeField]
        private PlayerChargeState state;

        [Header("Player Default State")]
        public float zoomDefault = 5;
        public float zoomDefaultCap = 25;
        public float zoomDefaultDecay = 1;
        public float zoomDefaultDecayRate = 1;

        [Header("Player Charge State")]
        public float chargedZoomDefualt = 15;
        public float chargedZoomCap = 50;
        public float chargedZoomDecayRate = 1;
        public float chargeDecayRate = 1;
        public float chargeDecayCD = 3;
        public float chargeIncreaseRate = 10;
        public float chargeCap = 100;
        public bool isCharged = false;

        [Header("Player Ionization Phase")]
        public float chargeIonizationIncreaseRate = 20;
        [SerializeField]
        private float currentCharge = 0;
        private float chargeDecayCDTimer = 0;

        private Slider chargeSlider;


        // Start is called before the first frame update
        void Start()
        {
            state = PlayerChargeState.ionization;
            followNodes = GetComponent<FollowNodes>();
            //chargeSlider = GameObject.FindGameObjectWithTag("ChargeSlider").GetComponent<Slider>();
            //chargeSlider.maxValue = 100;

        }

        // Update is called once per frame
        void FixedUpdate()
        {

            //chargeSlider.value = currentCharge;

            if (state == PlayerChargeState.charged || state == PlayerChargeState.notCharged)
            {
                if (chargeDecayCDTimer < chargeDecayCD)
                {
                    chargeDecayCDTimer += Time.deltaTime;

                }
                else
                {
                    if (state == PlayerChargeState.charged)
                    {
                        SetDefaulZoom();
                    }
                    chargeDecayCDTimer = 0;
                    state = PlayerChargeState.decaying;

                }

            }

            if (state == PlayerChargeState.decaying)
            {

                if (currentCharge > 0)
                {
                    currentCharge -= chargeDecayRate;
                }
                else
                {
                    currentCharge = 0;
                    state = PlayerChargeState.notCharged;

                }
            }

        }

        public void Ionize()
        {
            currentCharge += chargeIonizationIncreaseRate;
        }


        public void EndIonization()
        {

            state = PlayerChargeState.notCharged;
            if (currentCharge >= 100)
            {
                currentCharge = 100;
                state = PlayerChargeState.charged;
            }

        }

        void SetDefaulZoom()
        {

            followNodes.zoomDefault = zoomDefault;
            followNodes.zoomCap = zoomDefaultCap;
            //      followNodes.zoomDecayRate = zoomDefaultDecayRate;
        }

        void SetChargedZoom()
        {
            followNodes.zoomDefault = chargedZoomDefualt;
            followNodes.zoomCap = chargedZoomCap;
            //       followNodes.zoomDecayRate = chargedZoomDecayRate;

        }
        public void IncreasePlayerCharge()
        {

            chargeDecayCDTimer = 0;

            if (state == PlayerChargeState.decaying)
            {
                state = PlayerChargeState.notCharged;
            }

            if (state == PlayerChargeState.ionization)
            {

                currentCharge += chargeIonizationIncreaseRate;
            }
            else
            {

                currentCharge += chargeIncreaseRate;

            }

            if (currentCharge >= chargeCap)
            {

                currentCharge = chargeCap;

                if (state != PlayerChargeState.charged)
                {

                    state = PlayerChargeState.charged;

                }
            }

        }
    }

}