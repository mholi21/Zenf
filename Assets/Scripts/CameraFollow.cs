using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Vector3 offsetRotation;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;


    private void LateUpdate()
    {
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
            gameObject.transform.eulerAngles = offsetRotation;
        }
        else
        {
            transform.position = target.position + offsetPosition;
            gameObject.transform.eulerAngles = offsetRotation;
        }
    }
}
