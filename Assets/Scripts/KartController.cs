using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KartController : MonoBehaviour
{

    public Rigidbody rb;
    public Transform kart;
    public float steerSpeed = 10f;
    public float acceleration = 5f;
    public float beamAccMulti = 2f;
    public float brakingForce = 10f;
    private bool isBraking;
    public float currentbrakeForce;
    public float steerangleMax;
    public float steerangleCurrent;
    public float mass = -0.9f;
    public float speed;
    public bool keyboardAcceleration;
    public bool atStart = true;
    Quaternion Reset;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;

    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    private bool inBeam = false;

    // Start is called before the first frame update
    void Start()
    {
        rb.centerOfMass = new Vector3(0f, mass, 0f);
    }

    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        kart = this.gameObject.GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {

        HandleMove();
        Steering();
        UpdateWheels();
        //speed = rb.magnitude;

    }


    private void HandleMove()
    {
        if(keyboardAcceleration == true)
        {
            if (inBeam)
            {

                frontLeftWheelCollider.motorTorque = Input.GetAxis("Vertical") * acceleration * beamAccMulti;
                frontRightWheelCollider.motorTorque = Input.GetAxis("Vertical") * acceleration * beamAccMulti;

            }
            else
            {

                frontLeftWheelCollider.motorTorque = Input.GetAxis("Vertical") * acceleration;
                frontRightWheelCollider.motorTorque = Input.GetAxis("Vertical") * acceleration;

            }
        }
        else
        {

            if (inBeam)
            {

                frontLeftWheelCollider.motorTorque = acceleration * beamAccMulti;
                frontRightWheelCollider.motorTorque = acceleration * beamAccMulti;

            }
            else
            {

                frontLeftWheelCollider.motorTorque = acceleration;
                frontRightWheelCollider.motorTorque = acceleration;

            }
        }
    }

    public void Brake()
    {
        currentbrakeForce = brakingForce;
        frontLeftWheelCollider.brakeTorque = currentbrakeForce;
        frontRightWheelCollider.brakeTorque = currentbrakeForce;
        rearLeftWheelCollider.brakeTorque = currentbrakeForce;
        rearRightWheelCollider.brakeTorque = currentbrakeForce;
    }

    public void BrakeRelease()
    {
        currentbrakeForce = 0f;
        frontLeftWheelCollider.brakeTorque = currentbrakeForce;
        frontRightWheelCollider.brakeTorque = currentbrakeForce;
        rearLeftWheelCollider.brakeTorque = currentbrakeForce;
        rearRightWheelCollider.brakeTorque = currentbrakeForce;
    }


    private void Steering()
    {
        steerangleCurrent = steerangleMax * Input.GetAxis("Horizontal");
        frontLeftWheelCollider.steerAngle = steerangleCurrent;
        frontRightWheelCollider.steerAngle = steerangleCurrent;
    }

    private void UpdateWheels()
    {
        UpdateOneWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateOneWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateOneWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateOneWheel(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateOneWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }


    private void OnTriggerEnter(Collider other)
    {

        if(other.GetComponent<ParticleBeam>() != null)
        {
            Debug.Log("Im in it");

            inBeam = true;

        }

    }


    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<ParticleBeam>() != null)
        {
            Debug.Log("Im in it");

            inBeam = false;

        }

    }
}
