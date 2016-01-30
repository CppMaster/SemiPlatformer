using UnityEngine;
using System.Collections;

public class SimpleMovementPlayer : SimpleMovement {

    Player player;

    protected override void Start()
    {
        base.Start();
        player = GetComponent<Player>();
    }

    public override Vector2 GetSpeed()
    {
        return base.GetSpeed() * player.GetSpeedMultiplier();
    }
}
