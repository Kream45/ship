using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraLookDirection { FORWARD, RIGHT, BACKWARD, LEFT}

public class CameraScript : MonoBehaviour
{
    public Transform objectToTrack;
    public Vector3 delta;

    float cameraAngle = 0f;

    void Update()
    {

        cameraAngle += Input.GetAxis("Mouse X");

        var quaternion = Quaternion.Euler(0, cameraAngle, 0);

        var position = objectToTrack.position 
            + objectToTrack.rotation * quaternion * delta;
        transform.position = position;

        transform.LookAt(objectToTrack);
        transform.rotation *= Quaternion.Euler(-10f, 0, 0);
    }

    public CameraLookDirection GetCameraLookDirection()
    {
        var angle = Mathf.DeltaAngle(0, cameraAngle);


        if (-45 < angle && angle < 45)
            return CameraLookDirection.FORWARD;

        if (45 < angle && angle < 135)
            return CameraLookDirection.RIGHT;

        if (-135 < angle && angle < -45)
            return CameraLookDirection.LEFT;

        return CameraLookDirection.BACKWARD;
    }
}
