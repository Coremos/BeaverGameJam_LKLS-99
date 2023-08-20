using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class ConverterPanel : MonoBehaviour
{
    public List<ItemConverterComponent> ConverterComponentList = new List<ItemConverterComponent>();
    private void Awake()
    {
        SetConverter(GameDataManager.Instance.GlobalInventory.Items);

        foreach (var converterComponent in ConverterComponentList)
        {
            if (ItemManager.Instance.ConverterDic.ContainsKey(converterComponent.ItemConverterData.ConverterName))
            {
                var hasItem = ItemManager.Instance.ConverterDic[converterComponent.ItemConverterData.ConverterName];
                converterComponent.gameObject.SetActive(hasItem);
            }
            else
            {
                converterComponent.gameObject.SetActive(false);
            }
        }
    }

    private void SetConverter(List<ItemData> itemDataList)
    {
        foreach (ItemData item in itemDataList)
        {
            if (item.Type == ItemData.ItemType.Converter)
            {
                if (ItemManager.Instance.ConverterDic.ContainsKey(item.Name))
                {
                    ItemManager.Instance.ConverterDic[item.Name] = true;
                    SetInfoPane(item.Name, item.Description);
                }
            }
        }

    }

    private void SetInfoPane(string converterName, string discription)
    {
        foreach (var compo in  ConverterComponentList)
        {
            if (string.Compare(compo.ItemConverterData.ConverterName, converterName) != 0)
            {
                continue;
            }

            //compo.InfoPanel.gameObject.SetActive(true);
            compo.NameText.text = converterName;
            compo.DiscriptionText.text = discription;
            break;
        }
    }
}
