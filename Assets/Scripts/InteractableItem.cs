using UnityEngine;

public class InteractableItem : MonoBehaviour, IInteractableObject
{
    public ItemData Item;

    public void Interact()
    {
        if (!GameDataManager.Instance.PlayerInventory.TryAddItem(Item)) return;
        Destroy(gameObject);
    }
}

public interface IInteractableObject
{
    void Interact();
}