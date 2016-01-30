using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    SimpleMovement movement;
    Player player;

    void Start()
    {
        movement = GetComponent<SimpleMovement>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        player.isPunching = false;
        player.isBlocking = false;
        movement.inputDirection = Vector2.zero;
        movement.inputJump = false;

        player.isPunching = Input.GetButton("Fire1");
        if (!player.isPunching)
        {
            player.isBlocking = Input.GetButton("Block");
            if (!player.isBlocking)
            {
                movement.inputJump = Input.GetButton("Jump");
                movement.inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            }
        }
    }

}
