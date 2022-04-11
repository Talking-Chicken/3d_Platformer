using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetObject;
    [SerializeField] private float smoothFactor;
    private Vector3 cameraOffset;
    [SerializeField] private float cameraOffsetY, cameraOffsetZ;
    void Start()
    {
        transform.position = targetObject.transform.position + new Vector3(0, cameraOffsetY, cameraOffsetZ);
        cameraOffset = transform.position - targetObject.transform.position;
    }

    void LateUpdate() {
        Vector3 movePos = targetObject.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, movePos, smoothFactor);
    }
}
