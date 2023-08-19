using UnityEngine;

public enum KeyType
{
    Up = 0,
    Down,
    Left,
    Right,
    Dash,
    Interaction,
    Count
}

public class InputCommand
{
    public IMovementController MovementController;

    public InputCommand(IMovementController controller)
    {
        MovementController = controller;
    }
}

public class InputCommand_MoveUp : InputCommand, IInputCommand
{
    public InputCommand_MoveUp(IMovementController controller) : base(controller)
    {
    }

    public void Execute(float value)
    {
        MovementController.Move(Vector3.up * value);
    }
}

public class InputCommand_MoveDown : InputCommand, IInputCommand
{
    public InputCommand_MoveDown(IMovementController controller) : base(controller)
    {
    }

    public void Execute(float value)
    {
        MovementController.Move(Vector3.down * value);
    }
}

public class InputCommand_MoveLeft : InputCommand, IInputCommand
{
    public InputCommand_MoveLeft(IMovementController controller) : base(controller)
    {
    }

    public void Execute(float value)
    {
        MovementController.Move(Vector3.left * value);
    }
}

public class InputCommand_MoveRight : InputCommand, IInputCommand
{
    public InputCommand_MoveRight(IMovementController controller) : base(controller)
    {
    }

    public void Execute(float value)
    {
        MovementController.Move(Vector3.right * value);
    }
}

public class InputCommand_Dash : InputCommand, IInputCommand
{
    public InputCommand_Dash(IMovementController controller) : base(controller)
    {
    }

    public void Execute(float value)
    {
        MovementController.Dash();
    }
}

public class InputCommand_Interaction : InputCommand, IInputCommand
{
    public InputCommand_Interaction(IMovementController controller) : base(controller)
    {
    }

    public void Execute(float value)
    {
        MovementController.Interact();
    }
}