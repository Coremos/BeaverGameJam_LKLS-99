using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemConverterData
{
    public int Index;
    public string ConverterName;
    private List<ItemData> _inputItemDataList = new List<ItemData>();
    private List<ItemData> _outputItemDataList = new List<ItemData>();

    public void AddItem(ItemData itemData)
    {
        _inputItemDataList.Add(itemData);
    }

    public List<ItemData> GetInputItemDataList()
    {
        return _inputItemDataList;
    }

    public List<ItemData> GetOutputItemDataList()
    {
        return _outputItemDataList;
    }
}
