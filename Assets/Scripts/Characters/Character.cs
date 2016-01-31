using UnityEngine;

public class Character : Lootable
{
    protected SimpleMovement movement;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;

    protected override void Start()
    {
        base.Start();

        movement = GetComponent<SimpleMovement>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    protected override void Update()
    {
        base.Update();

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

    public override void Damage(Puncher puncher)
    {
        base.Damage(puncher);
        GetComponent<CharacterController>().Move(Vector3.right * puncher.punchPower * (puncher.IsFacingRight() ? 1f : -1f));
    }

    public bool IsFacingRight()
    {
        return !spriteRenderer.flipX;
    }

    public override void Die()
    {

        if (animator != null)
        {
            animator.SetTrigger("Dead");
        }
        else
        {
            Destroy();
        }

		if(lootItems.Length > 0)
			Instantiate(lootItems[Random.Range(0, lootItems.Length)], transform.position, Quaternion.identity);


		if(soulCount != null)
			soulCount.AddSouls (soulNumber);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
