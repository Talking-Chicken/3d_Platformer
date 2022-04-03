using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetObject;
    [SerializeField] private float smoothFactor;
    private Vector3 cameraOffset;
    void Start()
    {
        cameraOffset = transform.position - targetObject.transform.position;
    }

    void LateUpdate() {
        Vector3 movePos = targetObject.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, movePos, smoothFactor);
    }
}
