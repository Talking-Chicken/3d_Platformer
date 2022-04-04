using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* this class hadles floors that will be set visible/invisible based on their colors (red and blue)*/
public class SwitchFloor : MonoBehaviour
{
    [SerializeField] bool isRed;
    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;

    private CharacterController controller;

    private bool switched = false;
    void Start()
    {
        controller = FindObjectOfType<CharacterController>();
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        if (isRed) {
            switchFloor();
        }
    }

    void Update() {
        if (!controller.isGrounded && !switched) {
            switchFloor();
            switched = true;
        }

        if (controller.isGrounded)
            switched = false;
    }

    public void switchFloor() {
        meshRenderer.enabled = !meshRenderer.enabled;
        boxCollider.enabled = !boxCollider.enabled;
    }
}
