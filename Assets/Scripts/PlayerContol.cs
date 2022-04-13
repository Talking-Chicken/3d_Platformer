using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContol : MonoBehaviour
{
    CharacterController controller;
    Animator animator;
    Vector2 moveVect;
    [SerializeField] private float speed, gravity, jumpForce, maxJumpTime, airTimeInitial;
    private float jumpTime = 0, airTime; //jump time is the time player hold the jump button, air time is time that player not on ground

    //isJumping detect whether player hit space, jumpPressed detect whether player is holding space, isJumped detect whether player released space
    private bool isJumping = false, jumpPressed = false, isJumped = false;

    private bool isAlive = true;
    [SerializeField] private GameObject deathEffect;

    //getter & setter
    public bool JumpPressed {get => jumpPressed;}
    public bool IsAlive {get => isAlive; private set => isAlive = value;}
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        if (PlayerPrefs.HasKey("spawnX"))
            controller.Move(new Vector3(PlayerPrefs.GetFloat("spawnX"),
                                        PlayerPrefs.GetFloat("spawnY"),
                                        PlayerPrefs.GetFloat("spawnZ")));
    }

    void Update()
    {
        animator.SetFloat("Distance To Floor", detectFloor());
    }

    void FixedUpdate() {
        if (IsAlive)
            movementHandle();
    }

    void movementHandle() {
        Vector3 moveDir = Vector3.zero;

        
        if (controller.isGrounded) {
            if (isJumping && !isJumped) {
                jumpPressed = true;
                isJumped = true;
                animator.SetBool("Is Jumped", isJumped);
            }
            if (!isJumping) {
                isJumped = false;
                animator.SetBool("Is Jumped", isJumped);
            }
            airTime = airTimeInitial;
        } else {
            airTime += Time.fixedDeltaTime;
        }

        animator.SetBool("Jumping", !controller.isGrounded);
        animator.SetBool("Jump Pressed", jumpPressed);
        moveDir = new Vector3(moveVect.x, 0, moveVect.y);
        moveDir *= speed;

        animator.SetFloat("Speed", moveDir.magnitude);

        if (moveDir.magnitude > float.Epsilon) {
            transform.rotation = Quaternion.LookRotation(moveDir);
        }

        if (jumpPressed) {
            if (jumpTime > 0) {
                moveDir.y += jumpForce * (maxJumpTime / (jumpTime+0.1f));
            }

            if (isJumping && jumpTime <= maxJumpTime)
                jumpTime += Time.fixedDeltaTime;
            else {
                jumpTime = 0;
                jumpPressed = false;
            }
        }

        moveDir.y -= gravity * Time.fixedDeltaTime * Mathf.Pow(airTime,4);
        controller.Move(moveDir * Time.fixedDeltaTime);
    }

    public void OnMove(InputAction.CallbackContext context) => moveVect = context.ReadValue<Vector2>();
    public void OnJump(InputAction.CallbackContext context) => isJumping = context.ReadValueAsButton();

    /* return distance from player to floor
       it will return -1 when there's no floor beneath*/
    public float detectFloor() {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hitData;
        Physics.Raycast(ray, out hitData);
        if (hitData.transform != null) {
            if (hitData.transform.tag.Equals("Floor"))
                return transform.position.y - hitData.transform.position.y;  
        }
        return -1;
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.tag.Equals("Enemy")) {
            if (IsAlive) {
                IsAlive = false;
                Instantiate(deathEffect, collider.transform.position, collider.transform.rotation);
                StartCoroutine(waitToRespawn());
            }
        }
    }

    IEnumerator waitToRespawn() {
        yield return new WaitForSeconds(1.5f);
        CheckPointManager.respawn();
    }
}
