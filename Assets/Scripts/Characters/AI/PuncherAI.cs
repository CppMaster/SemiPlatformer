using UnityEngine;
using System.Collections;

public class PuncherAI : EnemyAI {

    Puncher puncher;
    SimpleMovement movement;

    public Destroyable player;
    public Destroyable shaman;

    public float heightDifferenceToJump = 0.5f;
    public float distanceToAttackPlayer = 5f; 

    protected override void Start()
    {
        base.Start();
        puncher = GetComponent<Puncher>();
        movement = GetComponent<SimpleMovement>();
        player = Player.instance;
        shaman = Shaman.instance;
    }

    protected override void Update()
    {
        base.Update();
        movement.inputDirection = Vector2.zero;

        target = IsAttackingPlayer() && player != null ? player : shaman;

        if (target == null)
            return;

        bool shouldPunch = puncher.DetectPunchCollisions() && puncher.IsPunchRefreshed() && puncher.IsGrounded();
        if (shouldPunch)
        {
            puncher.punchIndex = 0;
        }
        else if(!puncher.HasPunchCollisions())
        {
            Vector3 posDiff = target.GetPosition() - puncher.GlobalPunchPos();

            movement.inputDirection.x = Mathf.Sign(posDiff.x);
            movement.inputDirection.y = Mathf.Sign(posDiff.z);

            if(posDiff.y > heightDifferenceToJump)
            {
                movement.inputJump = true;
            }

        }

    }

    public bool IsAttackingPlayer()
    {
        if (player == null) return false;
        Vector3 posDiff = player.GetPosition() - puncher.GetPosition();
        return new Vector2(posDiff.x, posDiff.z).magnitude < distanceToAttackPlayer;
    }
}
