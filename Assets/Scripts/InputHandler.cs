using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Joystick joystick;

    private void Update()
    {
        var movement = Vector3.up * joystick.Vertical + Vector3.right * joystick.Horizontal;
        movement = movement.normalized;
        if (joystick.Vertical == 0.0f && joystick.Horizontal == 0.0f)
        {
            movement = GetMovement();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerController.Dash();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerController.Interact();
        }
        if (movement.x != 0.0f || movement.y != 0.0f)
        {
            playerController.Move(movement);
        }
    }

    private Vector3 GetMovement()
    {
        var movement = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement.y = 1.0f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            movement.y = -1.0f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x = -1.0f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            movement.x = 1.0f;
        }
        return movement;
    }
}