﻿using UnityEngine;

public class SimpleMovement : MonoBehaviour
{

    public Vector2 speed = Vector2.one;
    CharacterController controller;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    [Header("Input")]
    public Vector2 inputDirection;
    public bool inputJump = false;

    protected virtual void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        moveDirection = new Vector3(inputDirection.x * GetSpeed().x, moveDirection.y, inputDirection.y * GetSpeed().y);
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

    public bool IsGrounded()
    {
        return Mathf.Abs(moveDirection.y) < 0.5f;
    }

    public bool IsMoving()
    {
        return Mathf.Abs(moveDirection.x) > 0f;
    }

    public virtual Vector2 GetSpeed()
    {
        return speed;
    }

    public int GetVerticalDirection()
    {
        if (IsGrounded())
            return 0;
        if (moveDirection.y > 0f)
            return 1;
        return -1;
    }

}
