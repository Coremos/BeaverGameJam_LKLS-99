using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public Dictionary <int, ItemData> ItemDatadic =  new Dictionary <int, ItemData> ();
    
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Init()
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
                newItemData.Location = (string)data["Location"];
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

                if (ItemDatadic.ContainsKey(newItemData.Index) == false)
                {
                    ItemDatadic.Add(newItemData.Index, newItemData);
                }
            }
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.LogError(e.Message);
        }
    }
}
