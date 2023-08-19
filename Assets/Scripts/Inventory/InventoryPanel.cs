using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    public ScrollRect ScrollRect;
    public InventoryItemComponent InventoryItemComponent;

    private List<InventoryItemComponent> _inventoryItemComponentList = new List<InventoryItemComponent>();

    private void Awake()
    {
        var tempDataList = new List<ItemData>();
        for (int i = 0; i < 4; i++)
        {
            var tempItemData = new ItemData();
            tempItemData.Index = i;
            tempItemData.ItemName = $"temp_{i}";
            tempItemData.Count = 1;

            tempDataList.Add(tempItemData);
        }

        SetInventoryPanel(tempDataList);
    }

    public void SetInventoryPanel(List<ItemData> itemDataList)
    {
        InitItemComponent(itemDataList);
    }

    private void InitItemComponent(List<ItemData> itemDataList)
    {
        if (itemDataList == null)
        {
            return;
        }

        foreach (var itemData in itemDataList)
        {
            if (itemData == null)
            {
                continue;
            }

            var compo = Instantiate(InventoryItemComponent, ScrollRect.content);
            if (compo == null)
            {
                return;
            }

            compo.ItemCountText.text = itemData.Count.ToString();
            compo.ItemData = itemData;
        }
    }
}
