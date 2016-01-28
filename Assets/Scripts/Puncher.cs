using UnityEngine;
using System.Collections.Generic;

public class Puncher : Character
{

    public bool isPunching = false;
    public LayerMask punchLayer;
    public BoxCollider punchCollider;
    public float punchFrequency = 1f;
    public float punchPower = 0.5f;

    protected float punchTimeLeft = 0f;
    protected HashSet<Punchable> punchables;

    protected override void Start()
    {
        base.Start();
        punchables = new HashSet<Punchable>();
    }

    protected override void Update()
    {
        base.Update();

        punchTimeLeft -= Time.deltaTime * punchFrequency;

        isPunching &= CanPunch();

        if (animator != null)
            animator.SetBool("IsPunching", isPunching);

        if (isPunching)
            Punch();
    }

    public virtual bool CanPunch()
    {
        return punchTimeLeft <= 0f && movement.IsGrounded() && !movement.IsMoving();
    }

    public virtual void Punch()
    {

        if (punchCollider != null)
        {
            Vector3 worldPos = transform.position + Vector3.Scale(transform.localScale, punchCollider.center * (IsFacingRight() ? 1f : -1f));
            Collider[] punchedColliders = Physics.OverlapBox(worldPos, punchCollider.size * 0.5f, Quaternion.identity, punchLayer);

            punchables.Clear();

            foreach (Collider punchedCollider in punchedColliders)
            {
                Punchable punchable = punchedCollider.GetComponent<Punchable>();
                if (punchable == null) continue;
                punchables.Add(punchable);
            }

            ExecutePunch();
        }

        punchTimeLeft = 1f;
    }

    protected virtual void ExecutePunch()
    {
        foreach (Punchable punchable in punchables)
        {
            punchable.Punch(this);
        }
    }
}
