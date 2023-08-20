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

    public bool IsConverted { get; set; } = false;
    public string ConverterName = "";

    public Sprite DustSprite;
    public Sprite[] JewlySprties;

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

    public Sprite GetConvertSprite()
    {
        if (ItemData.IsAnswer && ItemData.NeedConvert && string.Compare(ConverterName, ItemData.Answer) != 0 )
        {
            return JewlySprties[0];
        }
        else
        {
            return DustSprite;
        }
    }

}
