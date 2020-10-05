using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    public Transform shipModel;

    public float minSpeed = 2f;
    public float maxSpeed = 10f;
    float currentSpeed = 2f;

    public float maxAngle = 30f;
    float currentAngle = 0;
           
    void Update()
    {
        // target velocity
        var targetSpeed = Input.GetKey(KeyCode.W)? maxSpeed : minSpeed;
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime);

        // target angle
        var targetAngle = 0f;
        if (Input.GetKey(KeyCode.A))
            targetAngle = -maxAngle;
        if (Input.GetKey(KeyCode.D))
            targetAngle = maxAngle;

        currentAngle = Mathf.Lerp(currentAngle, targetAngle, Time.deltaTime);
       
        // movement
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.rotation *= Quaternion.Euler(0, currentAngle * Time.deltaTime, 0);
        rigidbody.velocity = rigidbody.rotation * Vector3.forward * currentSpeed;

        // model's rotation
        var rotationX = Mathf.Sin(Time.timeSinceLevelLoad * 1.5f) * 2f;
        var rotationZ = -currentAngle / 2;



        shipModel.localRotation = Quaternion.Euler(rotationX, 0, rotationZ);
    }
}
