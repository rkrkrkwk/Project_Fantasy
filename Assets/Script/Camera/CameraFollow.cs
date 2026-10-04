using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // 카메라가 따라갈 타겟
    [SerializeField] private Transform target;
    // 카메라가 따라가는 속도
    [SerializeField] private float cameraSpeed = 1f;
    // 기본 카메라 높이 -10f
    private const float cameraDepth = -10f;
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position;
        desiredPosition.z = cameraDepth;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, cameraSpeed*Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
