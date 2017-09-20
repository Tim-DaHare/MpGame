using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    bool isControlled;
    public GameObject[] passengers = new GameObject[4];

    WheelCollider[] wheels;
    Rigidbody rigidbody;

    float enginePower = 150;

    float power = 0;
    float steer = 0;
    float brake = 0;

    float maxSteer = 25;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        wheels = GetComponentsInChildren<WheelCollider>();
    }

    private void Update()
    {
        if (!isControlled)
        {
            return;
        }

        power = Input.GetAxis("Vertical") * enginePower * Time.deltaTime * 250.0f;
        steer = Input.GetAxis("Horizontal") * maxSteer;
        brake = Input.GetKey("space") ? rigidbody.mass * 0.1f : 0.0f;

        GetCollider(0).steerAngle = steer;
        GetCollider(1).steerAngle = steer;

        if (brake > 0.0)
        {
            GetCollider(0).brakeTorque = brake;
            GetCollider(1).brakeTorque = brake;
            GetCollider(2).brakeTorque = brake;
            GetCollider(3).brakeTorque = brake;
            GetCollider(2).motorTorque = 0.0f;
            GetCollider(3).motorTorque = 0.0f;
        }
        else
        {
            GetCollider(0).brakeTorque = 0;
            GetCollider(1).brakeTorque = 0;
            GetCollider(2).brakeTorque = 0;
            GetCollider(3).brakeTorque = 0;
            GetCollider(2).motorTorque = power;
            GetCollider(3).motorTorque = power;
        }
    }

    WheelCollider GetCollider(int index)
    {
        return wheels[index];
    }

}
