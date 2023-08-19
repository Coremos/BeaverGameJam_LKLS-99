using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemComponent : MonoBehaviour
{
    public enum ItemType
    {
        None = 0,
        Inventory,
        ConverterInput,
        ConverterOutput
    }

    public Image ItemImage;
    public Text ItemCountText;
    public ItemData ItemData { get; set; }
    public ItemType NowItemType { get; set; }

    public bool isMoveableType()
    {
        if (NowItemType == ItemType.Inventory || NowItemType == ItemType.ConverterOutput)
        {
            return true;
        }

        return false;
    }
}
