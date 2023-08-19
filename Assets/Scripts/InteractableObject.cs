using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractableObject
{
    public void Interact()
    {

    }
}

public interface IInteractableObject
{
    void Interact();
}