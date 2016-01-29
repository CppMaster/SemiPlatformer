using UnityEngine;
using System.Collections;

public class PuncherAI : MoveAI {

    Puncher puncher;

    public Destroyable player;
    public Destroyable shaman;

    protected override void Start()
    {
        base.Start();
        puncher = GetComponent<Puncher>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Destroyable>();
        shaman = GameObject.FindGameObjectWithTag("Shaman").GetComponent<Destroyable>();
    }

    protected override void Update()
    {
        base.Update();

        target = IsAttackingPlayer() && player != null ? player : shaman;

        if (target == null)
            return;

        bool shouldPunch = puncher.DetectPunchCollisions() && puncher.IsPunchRefreshed() && puncher.IsGrounded();
        if (shouldPunch)
        {
            puncher.isPunching = true;
        }
        else if(!puncher.HasPunchCollisions())
        {
            Move();
        }

    }

    public bool IsAttackingPlayer()
    {
        if (player == null) return false;
        Vector3 posDiff = player.GetPosition() - puncher.GetPosition();
        return new Vector2(posDiff.x, posDiff.z).magnitude < distanceToAttackPlayer;
    }

    protected override Vector3 GetPosDiff()
    {
        return target.GetPosition() - puncher.GlobalPunchPos();
    }
}
