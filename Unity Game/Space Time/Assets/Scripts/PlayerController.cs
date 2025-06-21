using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] float turnSpeed = 90;
    [SerializeField] float playerSpeed = 2.0f;
    [SerializeField] float sprintSpeed = 20f;
    [SerializeField] float jumpHeight = 1.0f;
    [SerializeField] Animator animator;
    [SerializeField] Transform camera;
    [SerializeField] Transform camera2;
    [SerializeField] Transform camLookObj;

    private bool hasJumpedAgain = false;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        SoundManager.instance.SoundTrackswitch(SoundManager.GameMusic.playerEnter);
        PlatformController.singleton.Init("COM5", 115200);
    }

    void Update()
    {
        //groundedPlayer = controller.isGrounded;
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 2))
        {
            groundedPlayer = true;
            hasJumpedAgain = false;
        }
        else
        {
            groundedPlayer = false;
        }

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        
        if(Input.GetAxis("Vertical") > 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    
        controller.Move(transform.forward * Time.deltaTime * (playerSpeed + Input.GetAxis("Sprint") * sprintSpeed) * Input.GetAxis("Vertical"));
        transform.Rotate(0, turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0);


        // Player looks around
        camera.RotateAround(transform.position, Vector3.up, turnSpeed * Time.deltaTime * Input.GetAxis("LookHorizontal"));
        Vector3 camHeight = camera.localPosition;
        camHeight.y = Mathf.Clamp(camHeight.y + Input.GetAxis("LookVertical") * Time.deltaTime * 10, -1, 5);
        camera.localPosition = camHeight;
        //camera.RotateAround(transform.position, Vector3.right, turnSpeed * Time.deltaTime * Input.GetAxis("LookVertical"));
        camera.LookAt(camLookObj.position);
        PlatformController.singleton.Yaw = Input.GetAxis("Horizontal") * 12.0f;
        PlatformController.singleton.Pitch = Input.GetAxis("LookVertical") * 8.0f;

        // Makes the player jump
        if (Input.GetButtonDown("Jump"))
        {
            if(groundedPlayer)
            {
                animator.SetTrigger("Jump");
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
            }
            else if(!hasJumpedAgain)
            {
                hasJumpedAgain = true;
                animator.SetTrigger("Jump");
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
            }
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

     private void OnTriggerEnter(Collider other) {
        if(other.tag == "StationEnter")
        {
            camera.gameObject.SetActive(false);
            camera2.gameObject.SetActive(true);
        }
        else if(other.tag == "StationExit")
        {
            camera.gameObject.SetActive(true);
            camera2.gameObject.SetActive(false);
        }
    }
}