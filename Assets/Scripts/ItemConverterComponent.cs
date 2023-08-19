using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemConverterComponent : MonoBehaviour
{
    private ItemConverterData _itemConverterData;

    private void Awake()
    {
        _itemConverterData = new ItemConverterData();
        _itemConverterData.Index = 0;
        _itemConverterData.ConverterName = "tempConverter_0";

        SetItemConverterData(_itemConverterData);
    }

    public void SetItemConverterData(ItemConverterData itemConverterData)
    {
        _itemConverterData = itemConverterData;
    }

    public void AddItem(ItemData itemData)
    {
        if (_itemConverterData == null)
        {
            Debug.LogWarning("Item converter data is Null");
            return;
        }

        if (itemData == null)
        {
            Debug.LogWarning("Item data is Null");
            return;
        }

        _itemConverterData.AddItem(itemData);
    }
}
