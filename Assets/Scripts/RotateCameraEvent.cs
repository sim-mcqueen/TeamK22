using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotateCameraEvent : MonoBehaviour
{
    public event EventHandler OnRotateCamera;
    public GameObject cameraObject;
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
        rotateCameraEvent.OnRotateCamera += RotateCameraEvent_OnRotateCamera;
    }

    private void RotateCameraEvent_OnRotateCamera(object sender, EventArgs e)
    {
        
    }

    public void RotateCamera()
    {
        OnRotateCamera?.Invoke(this, EventArgs.Empty);
    }

    IEnumerator CameraZoom()
    {
        float elapsedTime = 0;

        while (elapsedTime < moveTime)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector2(newPos, 0), (elapsedTime / moveTime));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        transform.position = new Vector2(newPos, 0);
    }
}
