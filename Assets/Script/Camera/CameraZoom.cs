using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float zoomMax;
    [SerializeField] private float zoomMin;
    private void Update()
    {
        mainCamera.orthographicSize -= Input.mouseScrollDelta.y;
        if (mainCamera.orthographicSize > zoomMax) mainCamera.orthographicSize = zoomMax;
        if (mainCamera.orthographicSize < zoomMin) mainCamera.orthographicSize = zoomMin;
    }
}
