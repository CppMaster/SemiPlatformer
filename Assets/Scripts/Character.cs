using UnityEngine;

public class Character : MonoBehaviour
{
    SimpleMovement movement;
    Animator animator;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        movement = GetComponent<SimpleMovement>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (animator != null)
        {
            animator.SetBool("IsMoving", movement.inputDirection.magnitude > 0.0f);
        }
        if (spriteRenderer != null)
        {
            if (movement.inputDirection.x < 0)
                spriteRenderer.flipX = true;
            if (movement.inputDirection.x > 0)
                spriteRenderer.flipX = false;
        }
    }

}
