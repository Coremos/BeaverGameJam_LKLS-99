using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableObjectIndicator : MonoBehaviour, IPointerClickHandler
{
    public IInteractableObject InteractableObject;

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        InteractableObject?.Interact();
    }
}