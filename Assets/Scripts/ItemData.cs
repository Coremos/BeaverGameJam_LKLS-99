using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    public enum ItemType
    {
        None = 0,
        Item,
        Converter
    }

    public int Index;
    public string Name;
    public ItemType Type; 
    public string Location;
    public string Description;
    public string Answer;
    public bool IsAnswer;
    public bool NeedConvert;
    public int Count;
}
