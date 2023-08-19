using UnityEngine;

public class PlayerController : MonoBehaviour, IMovementController
{
    private Vector3 direction;
    private PlayerInteractor interactor;
    private Rigidbody2D rigid;
    private Animator animator;
    private float cooldownTimer;
    private bool isMoving;
    private bool isCurrentMoving;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float dashPower;
    [SerializeField] private float speed;
    [SerializeField] private float dashCooldown;
    //[SerializeField] private 

    private void Awake()
    {
        TryGetComponent(out interactor);
        TryGetComponent(out rigid);
        TryGetComponent(out animator);
        transform.GetChild(0).TryGetComponent(out spriteRenderer);
    }

    public void Move(Vector3 movement)
    {
        direction = movement;
        transform.position += movement * speed * Time.deltaTime;
        isCurrentMoving = true;

        float cross = Vector3.Cross(direction, Vector3.up).z;
        if (cross != 0.0f) spriteRenderer.flipX = cross < 0.0f;
    }

    public void Dash()
    {
        if (cooldownTimer > 0) return;
        Debug.Log("Dash!");
        cooldownTimer = dashCooldown;
        rigid.AddForce(direction * dashPower, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (cooldownTimer <= 0.0f) return;
        cooldownTimer -= Time.deltaTime;
    }

    private void LateUpdate()
    {
        if (isCurrentMoving)
        {
            if (!isMoving)
            {
                isMoving = true;
                animator.Play("Run");
            }
        }
        else
        {
            if (isMoving)
            {
                isMoving = false;
                animator.Play("Idle");
            }
        }
        isCurrentMoving = false;
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