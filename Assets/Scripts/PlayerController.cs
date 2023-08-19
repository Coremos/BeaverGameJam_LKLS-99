using UnityEngine;

public class PlayerController : MonoBehaviour, IMovementController
{
    private Vector3 direction;
    private PlayerInteractor interactor;
    private Rigidbody2D rigid;
    private float cooldownTimer;
    private Vector3 dashValue;

    [SerializeField] private float dashPower;
    [SerializeField] private float speed;
    [SerializeField] private float dashCooldown;

    private void Awake()
    {
        TryGetComponent(out interactor);
        TryGetComponent(out rigid);
    }

    public void Move(Vector3 movement)
    {
        direction = movement;
        transform.position += movement * speed * Time.deltaTime;
    }

    public void Dash()
    {
        if (cooldownTimer > 0) return;
        Debug.Log("Dash!");
        cooldownTimer = dashCooldown;
        dashValue = direction * dashPower;
    }

    private void Update()
    {
        transform.position += dashValue;
        dashValue *= 0.5f;
        cooldownTimer -= Time.deltaTime;
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