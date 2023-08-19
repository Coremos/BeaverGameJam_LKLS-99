using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private InteractableObjectIndicator interactableObjectIndicator;
    private RaycastHit2D[] hitBuffer = new RaycastHit2D[10];

    public void Interact(Vector3 direction)
    {
        interactableObjectIndicator?.OnClick();
    }

    [System.Obsolete]
    public void Interact_Direction(Vector3 direction)
    {
        int count = Physics2D.LinecastNonAlloc(transform.position, transform.position + direction * range, hitBuffer);
        for (int index = 0; index < count; index++)
        {
            if (hitBuffer[index].transform == transform) continue;
            if (!hitBuffer[index].collider.TryGetComponent<IInteractableObject>(out var interactable)) continue;
            interactable.Interact();
        }
    }
}