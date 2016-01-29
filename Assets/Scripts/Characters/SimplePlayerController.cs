using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    SimpleMovement movement;
    Puncher character;

    void Start()
    {
        movement = GetComponent<SimpleMovement>();
        character = GetComponent<Puncher>();
    }

    void Update()
    {
        character.isPunching = Input.GetButton("Fire1");
        if (character.isPunching)
        {
            movement.inputDirection = Vector2.zero;
            movement.inputJump = false;
        }
        movement.inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movement.inputJump = Input.GetButton("Jump");
    }

}
