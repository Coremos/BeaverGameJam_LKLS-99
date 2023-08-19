using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour
{
    public Transform content;
    public ItemComponent.ItemType ChangedType;

    public bool AddItem(ItemComponent itemComponent)
    {
        if (ChangeItemType(itemComponent) == false)
        {
            return false;
        }

        return true;
    }

    public bool ChangeItemType(ItemComponent itemComponent)
    {
        if (ChangedType == ItemComponent.ItemType.ConverterInput && itemComponent.NowItemType == ItemComponent.ItemType.ConverterOutput)
        {
            return false;
        }

        itemComponent.NowItemType = ChangedType;
        return true;
    }

    public List<ItemComponent> GetItemComponentList()
    {
        var result = new List<ItemComponent>();
        var chileCount = content.childCount;

        for (int i = 0; i < chileCount; i++)
        {
            var child = content.GetChild(i);
            if (child == null)
            {
                continue;
            }

            var component = child.GetComponent<ItemComponent>();
            if (component == null)
            {
                continue;
            }

            result.Add(component);
        }

        return result;
    }
}
