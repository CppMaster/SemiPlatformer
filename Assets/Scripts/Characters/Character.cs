using UnityEngine;

public class Character : Punchable
{
    protected SimpleMovement movement;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;

    protected virtual void Start()
    {
        movement = GetComponent<SimpleMovement>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    protected virtual void Update()
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

    public override void Punch(Puncher puncher)
    {
        base.Punch(puncher);
        GetComponent<CharacterController>().Move(Vector3.right * puncher.punchPower * (puncher.IsFacingRight() ? 1f : -1f));
    }

    public bool IsFacingRight()
    {
        return !spriteRenderer.flipX;
    }

}
