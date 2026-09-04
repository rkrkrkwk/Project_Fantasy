using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float cameraSpeed = 1f;
    private const float cameraDepth = -10f;
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position;
        desiredPosition.z = cameraDepth;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, cameraSpeed*Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
