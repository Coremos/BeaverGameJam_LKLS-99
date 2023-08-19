using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractableObject
{
    public void Interact()
    {
        Debug.Log(transform.name + "Interact!");
    }
}

public interface IInteractableObject
{
    void Interact();
}