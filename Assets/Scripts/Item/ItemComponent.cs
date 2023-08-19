using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemComponent : MonoBehaviour
{
    public enum ItemType
    {
        None = 0,
        Inventory,
        ConverterInput,
        ConverterOutput,
        Submit
    }

    public Image ItemImage;
    public Text ItemCountText;
    public ItemData ItemData { get; set; }
    public ItemType NowItemType { get; set; }

    public bool isMoveableType()
    {
        switch (NowItemType)
        {
            case ItemType.Inventory:
            case ItemType.ConverterOutput:
            //case ItemType.Submit:
                return true;
            default:
                return false;
        }
    }

}
