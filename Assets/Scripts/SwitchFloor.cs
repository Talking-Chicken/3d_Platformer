using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* this class hadles floors that will be set visible/invisible based on their colors (red and blue)*/
public class SwitchFloor : MonoBehaviour
{
    [SerializeField] bool isRed;
    private Renderer renderer;
    [SerializeField] Material origianlMat, transparentMat;
    Material[] changedMaterials = new Material[3];
    private BoxCollider boxCollider;

    private CharacterController controller;

    private bool switched = false;
    void Start()
    {
        controller = FindObjectOfType<CharacterController>();
        renderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        for (int i = 0; i < renderer.materials.Length; i++) 
        changedMaterials[i] = renderer.materials[i];
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
        if (!boxCollider.enabled) {
            changedMaterials[0] = origianlMat; 
            renderer.materials = changedMaterials;
        }
        else {
            changedMaterials[0] = transparentMat;
            renderer.materials = changedMaterials; 
        }
        //meshRenderer.enabled = !meshRenderer.enabled;
        boxCollider.enabled = !boxCollider.enabled;
    }
}
