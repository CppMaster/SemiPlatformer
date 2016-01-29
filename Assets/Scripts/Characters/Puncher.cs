using UnityEngine;
using System.Collections.Generic;

public class Puncher : Character
{

    public bool isPunching = false;
    public LayerMask punchLayer;
    public BoxCollider punchCollider;
    public float punchFrequency = 1f;
    public float punchPower = 0.5f;
    public float punchDamage = 20f;

    protected float punchTimeLeft = 0f;
    protected HashSet<Destroyable> punchables;

    protected override void Start()
    {
        base.Start();
        punchables = new HashSet<Destroyable>();
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
        return IsPunchRefreshed() && IsGrounded() && !movement.IsMoving();
    }

    public virtual bool IsGrounded()
    {
        return movement.IsGrounded();
    }

    public bool IsPunchRefreshed()
    {
        return punchTimeLeft <= 0f;
    }

    public virtual void Punch()
    {

        DetectPunchCollisions();
        PunchWithoutDetection();
    }

    public virtual void PunchWithoutDetection()
    {
        ExecutePunch();
        punchables.Clear();

        punchTimeLeft = 1f;
    }

    public bool DetectPunchCollisions()
    {
        punchables.Clear();

        if (punchCollider == null) return false;

        Collider[] punchedColliders = Physics.OverlapBox(GlobalPunchPos(), punchCollider.size * 0.5f, Quaternion.identity, punchLayer);

        foreach (Collider punchedCollider in punchedColliders)
        {
            Destroyable punchable = punchedCollider.GetComponent<Destroyable>();
            if (punchable == null) continue;
            punchables.Add(punchable);
        }

        return HasPunchCollisions();
    }

    public bool HasPunchCollisions()
    {
        return punchables.Count > 0;
    }

    public Vector3 GlobalPunchPos()
    {
        return transform.position + Vector3.Scale(transform.localScale, punchCollider.center * (IsFacingRight() ? 1f : -1f));
    }

    protected virtual void ExecutePunch()
    {
        foreach (Destroyable punchable in punchables)
        {
            punchable.Damage(this);
        }
    }
}
