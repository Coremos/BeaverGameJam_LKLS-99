using UnityEngine;

public class InteractableObjectIndicator : MonoBehaviour
{
    public IInteractableObject InteractableObject;

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }

    public void OnClick()
    {
        InteractableObject?.Interact();
        InteractableObject = null;
    }
}