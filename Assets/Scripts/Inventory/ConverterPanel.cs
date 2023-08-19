using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class ConverterPanel : MonoBehaviour
{
    public List<ItemConverterData> ConverterDataList = new List<ItemConverterData>();
    private void Awake()
    {
        SetConverter(GameDataManager.Instance.GlobalInventory.Items);

        foreach (var converterData in ConverterDataList)
        {
            if (ItemManager.Instance.ConverterDic.ContainsKey(converterData.ConverterName))
            {
                var hasItem = ItemManager.Instance.ConverterDic[converterData.ConverterName];
                converterData.gameObject.SetActive(hasItem);
            }
            else
            {
                converterData.gameObject.SetActive(false);
            }
        }
    }

    private void SetConverter(List<ItemData> itemDataList)
    {
        var isNew = false;
        foreach (ItemData item in itemDataList)
        {
            if (item.Type == ItemData.ItemType.Converter)
            {
                if (ItemManager.Instance.ConverterDic.ContainsKey(item.Name))
                {
                    ItemManager.Instance.ConverterDic[item.Name] = true;
                    isNew = true;
                }
            }
        }

        if (isNew)
        {
            // 팝업창
        }
    }
}
