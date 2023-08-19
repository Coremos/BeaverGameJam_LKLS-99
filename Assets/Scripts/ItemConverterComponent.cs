using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemConverterComponent : ItemBox
{
    public ItemComponent ItemComponent;
    public ScrollRect OutputScrollRect;
    public Button ConvertButton;

    [SerializeField]
    private ItemConverterData _itemConverterData;

    private void Awake()
    {
        SetItemConverterData();
    }

    public void SetItemConverterData()
    {
        CanConvert();
    }

    public void OnClickConvertButton()
    {
        if (_itemConverterData == null)
        {
            return;
        }

        if (CanConvert() == false)
        {
            return;
        }

        ConvertAll();
    }

    private bool CanConvert()
    {
        var canConvert = GetItemComponentList().Count > 0;
        if (canConvert == false)
        {
            return false;
        }

        return true;
    }

    public void ConvertAll()
    {
        foreach (var compo in GetItemComponentList())
        {
            if (compo == null)
            {
                continue;
            }

            if (compo.ItemData.IsConverted)
            {
                continue;
            }

            compo.ItemData.IsConverted = true;
            compo.ItemData.ConverterName = _itemConverterData.ConverterName;
            compo.NowItemType = ItemComponent.ItemType.ConverterOutput;

            compo.transform.parent = OutputScrollRect.content;
        }
    }

}
