using UnityEngine;
using System.Collections;

public class Camera1st : MonoBehaviour {

    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Vector3 offsetRotation;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    private float startTime;
    private float journeyLength;

    private void LateUpdate()
    {
        
        journeyLength = Vector3.Distance(transform.position, offsetPosition);
            float distCovered = (Time.time - startTime) * 0.5f;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, offsetPosition, fracJourney);
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, offsetRotation, fracJourney / 4);
        StartCoroutine(DelayDestroy());
    }

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(3.0f);
        Camera.main.GetComponent<CameraFollow>().enabled = true;
        Camera.main.GetComponent<Camera1st>().enabled = false;
    }
}
