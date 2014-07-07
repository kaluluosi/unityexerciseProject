using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 3.0f;
    public float gravity = 2.0f;
    public int hp = 5;

    private CharacterController controller;
    private Vector3 moveDirection;
    public float jumpSpeed = 10;
    private float jumpSpeedBak;
    private bool isJumping;

    // Use this for initialization
    void Start() {
        controller = gameObject.GetComponent<CharacterController>();
        jumpSpeedBak = jumpSpeed;
    }

    // Update is called once per frame
    void Update() {
        if (hp <= 0) {
            return;
        }
        Control();
    }

    void Control() {
        moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) {
            moveDirection.z += speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S)) {
            moveDirection.z -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A)) {
            moveDirection.x -= speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D)) {
            moveDirection.x += speed * Time.deltaTime;
        }

        if (controller.isGrounded) {
            if (Input.GetKey(KeyCode.Space)) {
                isJumping = true;
            }
        }

        ApplyJump();

        ApplyGravity();

        //Move
        controller.Move(transform.TransformDirection(moveDirection));

        Debug.Log(moveDirection);
    }

    private void ApplyJump() {
        //Apply Jump
        if (jumpSpeed <= 0) {
            isJumping = false;
            jumpSpeed = jumpSpeedBak;
        }

        if (isJumping) {
            jumpSpeed += Physics.gravity.y * Time.deltaTime;
            moveDirection.y += jumpSpeed * Time.deltaTime;
        }
    }

    private void ApplyGravity() {
        if (controller.isGrounded == false) {
            //Apply Gravity 
            moveDirection += Physics.gravity * Time.deltaTime;
        }
    }
}
