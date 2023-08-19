using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryUI : MonoBehaviour
{
    [SerializeField] private Image[] images;

    private void FixedUpdate()
    {
        var inventory = GameDataManager.Instance.PlayerInventory;
        for (int index = 0; index < 4; index++)
        {
            if (index >= inventory.Items.Count)
            {
                images[index].sprite = null;
                continue;
            }
            var item = inventory.Items[index];
            images[index].sprite = item.Sprite;
        }
    }
}