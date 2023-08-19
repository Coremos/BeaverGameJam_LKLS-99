using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public Dictionary <int, ItemData> ItemTabeDataDic =  new Dictionary <int, ItemData> ();
    public Dictionary <string, bool> ConverterDic = new Dictionary <string, bool> ();

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Init()
    {
        ReadTableData();
        SetConverter();
    }

    private void ReadTableData()
    {
        var readResult = CSVReader.Read("CSV/ItemTable");

        if (readResult == null)
        {
            UnityEngine.Debug.LogError("CSV Result is Null");
            return;
        }

        try
        {
            foreach (var data in readResult)
            {
                var newItemData = new ItemData();
                newItemData.Index = (int)data["Index"];
                newItemData.Location = ((string)data["Location"]).ToLocationType();
                if (Enum.TryParse((string)data["Type"], out newItemData.Type) == false)
                {
                    newItemData.Type = ItemData.ItemType.None;
                }
                newItemData.Name = (string)data["Name"];
                if (Boolean.TryParse((string)data["IsAnswer"], out newItemData.IsAnswer) == false)
                {
                    newItemData.IsAnswer = false;
                }
                if (Boolean.TryParse((string)data["NeedConvert"], out newItemData.NeedConvert) == false)
                {
                    newItemData.NeedConvert = false;
                }
                newItemData.Answer = (string)data["Answer"];
                newItemData.Description = (string)data["Description"];

                if (ItemTabeDataDic.ContainsKey(newItemData.Index) == false)
                {
                    ItemTabeDataDic.Add(newItemData.Index, newItemData);
                }
            }
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.LogError(e.Message);
        }

    }

    private void SetConverter()
    {
        foreach (var data in ItemTabeDataDic)
        {
            if (data.Value.Type == ItemData.ItemType.Converter)
            {
                if (ConverterDic.ContainsKey(data.Value.Name))
                {
                    continue;
                }

                ConverterDic.Add(data.Value.Name, false);
            }
        }
    }
}
