using UnityEngine;

public class PlayerController : MonoBehaviour, IMovementController
{
    private Vector3 direction;
    private float dashPower;
    private PlayerInteractor interactor;

    private void Awake()
    {
        TryGetComponent(out interactor);
    }

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
        interactor.Interact(direction);
    }
}

public interface IMovementController
{
    void Move(Vector3 movement);
    void Dash();
    void Interact();
}