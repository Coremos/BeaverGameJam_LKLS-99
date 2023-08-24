using TMPro;
using UnityEngine;

public class InteractableObjectIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;

    public IInteractableObject InteractableObject
    {
        get => interactableObject;
        set
        {
            interactableObject = value;
            if (interactableObject == null)
            {
                nameText.text = "";
            }
            else
            {
            nameText.text = interactableObject.Name;
            }
        }
    }

    private IInteractableObject interactableObject;

    private void OnDisable()
    {
        nameText.text = "";
    }

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