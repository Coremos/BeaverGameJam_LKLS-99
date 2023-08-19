using System.Collections;
using System.Collections.Generic;
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
            Debug.LogError("CSV Result is Null");
            return;
        }

        foreach (var data in readResult)
        {
            Debug.Log($"Index: {data["Index"]}");
        }
    }
}
