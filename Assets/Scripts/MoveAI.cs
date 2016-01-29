using UnityEngine;

public class MoveAI : EnemyAI {

    public float heightDifferenceToJump = 0.5f;
    public float distanceToAttackPlayer = 5f;

    protected MapObject mapObject;
    protected SimpleMovement movement;

    protected override void Start()
    {
        base.Start();

        mapObject = GetComponent<MapObject>();
        movement = GetComponent<SimpleMovement>();
    }

    protected virtual void Move()
    {
        Vector3 posDiff = GetPosDiff();

        movement.inputDirection.x = Mathf.Sign(posDiff.x);
        movement.inputDirection.y = Mathf.Sign(posDiff.z);

        if (posDiff.y > heightDifferenceToJump)
        {
            movement.inputJump = true;
        }
    }

    protected virtual Vector3 GetPosDiff()
    {
        return target.GetPosition() - mapObject.GetPosition();
    }
}
