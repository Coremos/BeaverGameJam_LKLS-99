using UnityEngine;

public class WarpPortal : MonoBehaviour, IInteractableObject
{
    public void Interact()
    {
        var playerInventory = GameDataManager.Instance.PlayerInventory;
        if (playerInventory.Items.Count == 0)
        {
            GameSceneManager.Instance.LoadScene(GameSceneManager.SceneType.Making);
        }
        else
        {
            GameDataManager.Instance.GlobalInventory.WriteInventory(playerInventory);
        }
    }
}