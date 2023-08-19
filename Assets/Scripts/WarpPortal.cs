using UnityEngine;

public class WarpPortal : MonoBehaviour, IInteractableObject
{
    public void Interact()
    {
        GameSceneManager.Instance.LoadScene(GameSceneManager.SceneType.Making);
    }
}