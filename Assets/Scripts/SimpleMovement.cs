﻿using UnityEngine;

public class SimpleMovement : MonoBehaviour
{

    public Vector2 speed = Vector2.one;
    CharacterController controller;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    Animator animator;
    SpriteRenderer spriteRenderer;

    [Header("Input")]
    public Vector2 inputDirection;
    public bool inputJump = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        moveDirection = new Vector3(inputDirection.x * speed.x, moveDirection.y, inputDirection.y * speed.y);
        if (controller.isGrounded)
        {

            if (inputJump)
            {
                moveDirection.y = jumpSpeed;
                inputJump = false;
            }
            else
            {
                moveDirection.y = 0f;
            }

        }
        else
            moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);
    }
}
