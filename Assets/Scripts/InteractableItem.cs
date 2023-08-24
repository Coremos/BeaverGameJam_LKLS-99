using UnityEngine;

public class InteractableItem : MonoBehaviour, IInteractableObject
{
    public string Name => item.Name;
    public ItemData Item 
    {
        get => item;
        set
        {
            item = value;
            if (spriteRenderer == null)
            {
                TryGetComponent(out spriteRenderer);
            }
            spriteRenderer.sprite = item.Sprite;
        }
    }

    private ItemData item;
    private SpriteRenderer spriteRenderer;

    public void Interact()
    {
        if (!GameDataManager.Instance.PlayerInventory.TryAddItem(Item)) return;
        Destroy(gameObject);
    }
}

public interface IInteractableObject
{
    string Name { get; }
    void Interact();
}