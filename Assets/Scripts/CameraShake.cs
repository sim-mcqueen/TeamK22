using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public float hitMag;
    public float hitDuration;
    public float rotMag;
    public float rotDuration;
    private float timeElapsed;
    private float xOffset;
    private float yOffset;
    private Vector3 startPos;
    private ObstacleHitEvent obstacleHitEvent;
    private RotateCameraEvent rotateCameraEvent;

    private void Awake()
    {
        rotateCameraEvent = FindObjectOfType<RotateCameraEvent>();
        obstacleHitEvent = FindObjectOfType<ObstacleHitEvent>();
    }

    private void Start()
    {
        startPos = transform.position;
        rotateCameraEvent.OnRotateCamera += RotateCameraEvent_OnRotateCamera;
        obstacleHitEvent.OnHitObstacle += ObstacleHitEvent_OnHitObstacle;
    }

    private void RotateCameraEvent_OnRotateCamera(object sender, System.EventArgs e)
    {
        StartCoroutine(ShakeScreen(rotDuration, rotMag));
    }

    private void ObstacleHitEvent_OnHitObstacle(object sender, System.EventArgs e)
    {
        StartCoroutine(ShakeScreen(hitDuration, hitMag));
    }

    IEnumerator ShakeScreen(float duration, float mag)
    {
        timeElapsed = 0f;

        while(timeElapsed < duration)
        {
            xOffset = Random.Range(-0.5f, 0.5f) * mag;
            yOffset = Random.Range(-0.5f, 0.5f) * mag;

            transform.position = new Vector3(xOffset, yOffset, startPos.z);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = startPos;
    }
}
