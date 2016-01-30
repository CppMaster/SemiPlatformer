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
        player.punchIndex = -1;
        player.isBlocking = false;
        movement.inputDirection = Vector2.zero;
        movement.inputJump = false;

        if (Input.GetButtonDown("Fire1"))
            player.punchIndex = 0;
        else if(Input.GetButtonDown("Fire2"))
            player.punchIndex = 1;

        if (player.punchIndex == -1)
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
