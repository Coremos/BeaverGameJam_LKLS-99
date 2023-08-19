using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private float range;

    public void Interact(Vector3 direction)
    {
        var hit = Physics2D.Linecast(transform.position, transform.position + direction * range);
        if (hit.collider == null) return;
        if (!hit.transform.TryGetComponent<IInteractableObject>(out var interactableObject)) return;
        interactableObject.Interact();
    }
}