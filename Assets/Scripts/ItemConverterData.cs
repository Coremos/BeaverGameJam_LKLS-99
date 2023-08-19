using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemConverterData : MonoBehaviour
{
    public int Index;
    public string ConverterName;
    private List<ItemData> _outputItemDataList = new List<ItemData>();


    public List<ItemData> GetOutputItemDataList()
    {
        return _outputItemDataList;
    }

}
