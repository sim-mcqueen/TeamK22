using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotateCameraEvent : MonoBehaviour
{
    public event EventHandler OnRotateCamera;
    public GameObject cameraObject;
    public float zoomDistance;
    public float moveTime;

    private RotateCameraEvent rotateCameraEvent;
    private bool isCameraRotated = false;
    private float startZoom;
    private Camera cam;

    private void Awake()
    {
        cam = cameraObject.GetComponent<Camera>();
        rotateCameraEvent = FindObjectOfType<RotateCameraEvent>();
    }

    private void Start()
    {
        startZoom = cam.orthographicSize;
        rotateCameraEvent.OnRotateCamera += RotateCameraEvent_OnRotateCamera;
    }

    private void RotateCameraEvent_OnRotateCamera(object sender, EventArgs e)
    {

        if(isCameraRotated)
        {
            StartCoroutine(CameraZoomIn(0));
            isCameraRotated = !isCameraRotated;
            return;
        }
        StartCoroutine(CameraZoomIn(180));
        isCameraRotated = !isCameraRotated;
    }

    public void RotateCamera()
    {
        OnRotateCamera?.Invoke(this, EventArgs.Empty);
    }

    IEnumerator CameraZoomIn(float rotValue)
    {
        float elapsedTime = 0;

        while (elapsedTime < (moveTime))
        {
            cam.orthographicSize = Mathf.Lerp(startZoom, zoomDistance, elapsedTime / moveTime);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        cam.orthographicSize = zoomDistance;

        cameraObject.transform.localRotation = Quaternion.Euler(0, 0, rotValue);
        
        StartCoroutine(CameraZoomOut());
    }


    IEnumerator CameraZoomOut()
    {
        float elapsedTime = 0;

        while (elapsedTime < (moveTime))
        {
            cam.orthographicSize = Mathf.Lerp(zoomDistance, startZoom, elapsedTime / moveTime);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        cam.orthographicSize = startZoom;
    }
}
