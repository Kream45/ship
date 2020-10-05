using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallShoot : MonoBehaviour
{

    public GameObject cannonBallPrefab;

    public Vector3 LeftSpawnPosition;
    public Vector3 LeftShootDirection;

    public Vector3 RightSpawnPosition;
    public Vector3 RightShootDirection;


    public float shootPeriod = 1f;
    float lastShootTime = 0;
   
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;

        if (Time.timeSinceLevelLoad - lastShootTime < shootPeriod) return;

        lastShootTime = Time.timeSinceLevelLoad;

        //var camera = FindObjectOfType<Camera>();
        //var direction = camera.GetCameraLookingDirection();

        var direction = Camera.main.GetComponent<CameraScript>().GetCameraLookDirection();

        if (direction == CameraLookDirection.FORWARD ||
            direction == CameraLookDirection.BACKWARD) return;

        var lookLeft = direction == CameraLookDirection.LEFT;

        var SpawnPosition = lookLeft ? LeftSpawnPosition : RightSpawnPosition;
        var ShootDirection = lookLeft ? LeftShootDirection : RightShootDirection;


        var ball = Instantiate(cannonBallPrefab);
        ball.transform.position = transform.position + transform.rotation * SpawnPosition;

        var rigidbody = ball.GetComponent<Rigidbody>();
        rigidbody.velocity = transform.rotation * ShootDirection;
       
    }
}
