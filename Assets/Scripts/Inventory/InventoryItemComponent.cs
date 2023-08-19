using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemComponent : MonoBehaviour
{
    public Image ItemImage;
    public Text ItemCountText;
    public Button ClickButton;
    public ItemData ItemData { get; set; }

}
