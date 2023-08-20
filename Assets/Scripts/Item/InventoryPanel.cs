using System;
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
        SetInventoryPanel(GameDataManager.Instance.GlobalInventory.Items);
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

            var isItem = (itemDataList[i].Type == ItemData.ItemType.Item);
            _inventoryItemComponentList[i].ItemCountText.text = itemDataList[i].Count.ToString();
            _inventoryItemComponentList[i].ItemData = itemDataList[i];
            _inventoryItemComponentList[i].NowItemType = ItemComponent.ItemType.Inventory;
            _inventoryItemComponentList[i].gameObject.SetActive(isItem);
            _inventoryItemComponentList[i].ItemImage.sprite = itemDataList[i].Sprite;
        }
    }

    public void OnClickTestButton()
    {
        GameSceneManager.Instance.LoadScene(GameSceneManager.SceneType.Happy);
    }
}
