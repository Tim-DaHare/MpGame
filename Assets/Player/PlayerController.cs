using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    CharacterController controller;
    Animator animator;
    public Camera playerCamera;

    public float cameraDistance = 3.0F;
    float mouseCurrentX;
    float mouseCurrentY;

    public float speed = 6.0F;
    public float jumpHeigth = 8.0F;
    public float gravity = 20.0F;
    public bool canJump;
    public float groundCheckDistance = 1.2f;
    public Vector3 moveDirection;
	Quaternion lookRotation;

    Vector3 lookAt;

	void Start ()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        transform.name = "Player_" + GetComponent<NetworkIdentity>().netId;

        if (isLocalPlayer)
        {
            playerCamera.gameObject.SetActive(true);
        }
        else
        {
            this.enabled = false;
        }
    }

	void Update ()
    {
        MouseLook();

        RaycastHit hitInfo;
        canJump = Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hitInfo, groundCheckDistance) ? true : false;

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (moveDirection != Vector3.zero)
            {
				animator.SetBool ("Idle", false);
            }
            else
            {
				animator.SetBool ("Idle", true);
			}

            if (canJump)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpHeigth;
                }
            }
            
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        //Turn player with camera
        if (new Vector2(moveDirection.x, moveDirection.z) != Vector2.zero)
        {
            lookRotation = Quaternion.Euler(0, playerCamera.transform.rotation.eulerAngles.y, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.2f);
        }

	}

    void MouseLook()
    {
        mouseCurrentX += Input.GetAxis("Mouse X");
        mouseCurrentY -= Input.GetAxis("Mouse Y");

        lookAt = transform.position + (Vector3.up * 1.7f);

        Vector3 cameraDirection = new Vector3(0, 0, -cameraDistance);
        Quaternion cameraRotation = Quaternion.Euler(mouseCurrentY, mouseCurrentX, 0);
        playerCamera.transform.position = lookAt + cameraRotation * cameraDirection;

        playerCamera.transform.LookAt(lookAt);
    }
}
