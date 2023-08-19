using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IMovementController
{
    private Vector3 direction;
    private float dashPower;
    
    public void Move(Vector3 movement)
    {
        direction = movement;
        transform.position += movement * Time.deltaTime;
    }

    public void Dash()
    {
        transform.position = direction * dashPower;
    }

    public void Interact()
    {

    }
}

public class PCInput : MonoBehaviour
{
    private PlayerController controller;

    private void Update()
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

        if (Input.GetKey(KeyCode.Z))
        {
            controller.Interact();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Dash();
        }
        if (movement.x != 0.0f || movement.y != 0.0f)
        {
            controller.Move(movement);
        }
    }
}

public interface IMovementController
{
    void Move(Vector3 movement);
    void Dash();
    void Interact();
}

public interface IInputHandler
{
    void Update();
    void ExecuteCommand(KeyType keyType);
}

public class PCInputHandler : IInputHandler
{
    public IMovementController movementController;
    public KeySetting keySetting;
    public Dictionary<KeyType, IInputCommand> commandPairs;

    public PCInputHandler()
    {
        InitializeCommandPairs();
    }

    private void InitializeCommandPairs()
    {
        commandPairs = new Dictionary<KeyType, IInputCommand>();
        
        commandPairs.Add(KeyType.Up, new InputCommand_MoveUp(movementController));
        commandPairs.Add(KeyType.Down, new InputCommand_MoveDown(movementController));
        commandPairs.Add(KeyType.Left, new InputCommand_MoveLeft(movementController));
        commandPairs.Add(KeyType.Right, new InputCommand_MoveRight(movementController));

        commandPairs.Add(KeyType.Dash, new InputCommand_Dash(movementController));
        commandPairs.Add(KeyType.Interaction, new InputCommand_Interaction(movementController));
    }

    public void Update()
    {

    }

    public void ExecuteCommand(KeyType keyType)
    {
        if (commandPairs.TryGetValue(keyType, out var command))
        {
            command.Execute(1.0f);
        }
    }
}

public class MobileInputHandler : IInputHandler
{
    public IMovementController movementController;

    public void Update()
    {

    }

    public void ExecuteCommand(KeyType keyType)
    {
    }
}

public class InputHandlerController : MonoBehaviour
{
    private IInputHandler inputHandler;

    private void Update()
    {
        
    }
}