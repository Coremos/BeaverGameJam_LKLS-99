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
                images[index].color = Color.clear;
                continue;
            }
            var item = inventory.Items[index];
            images[index].sprite = item.Sprite;
            images[index].color = Color.white;
        }
    }
}