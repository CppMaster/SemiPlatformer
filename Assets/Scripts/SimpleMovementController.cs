using UnityEngine;

public class SimpleMovementController : MonoBehaviour
{
    SimpleMovement movement;

    void Start()
    {
        movement = GetComponent<SimpleMovement>();
    }

    void Update()
    {
        movement.inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movement.inputJump = Input.GetButton("Jump");
    }
}
