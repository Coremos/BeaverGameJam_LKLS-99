using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    public ScrollRect ScrollRect;
    public ItemComponent ItemComponent;

    private List<ItemComponent> _inventoryItemComponentList = new List<ItemComponent>();

    private void Awake()
    {
        var tempDataList = new List<ItemData>();
        for (int i = 0; i < 4; i++)
        {
            var tempItemData = new ItemData();
            tempItemData.Index = i;
            tempItemData.Name = $"temp_{i}";
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

        for (int i = 0; i < itemDataList.Count; i++)
        {
            if (itemDataList[i] == null)
            {
                continue;
            }

            if (i >= _inventoryItemComponentList.Count)
            {
                var compo = Instantiate(ItemComponent, ScrollRect.content);
                if (compo == null)
                {
                    return;
                }

                _inventoryItemComponentList.Add(compo);
            }

            _inventoryItemComponentList[i].ItemCountText.text = itemDataList[i].Count.ToString();
            _inventoryItemComponentList[i].ItemData = itemDataList[i];
            _inventoryItemComponentList[i].NowItemType = ItemComponent.ItemType.Inventory;
            _inventoryItemComponentList[i].gameObject.SetActive(true);


        }
    }
}
