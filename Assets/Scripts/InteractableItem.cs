using UnityEngine;

public class InteractableItem : MonoBehaviour, IInteractableObject
{
    public IItem Item;

    public void Interact()
    {
        Debug.Log(transform.name + "Interact!");
    }
}

public interface IInteractableObject
{
    void Interact();
}