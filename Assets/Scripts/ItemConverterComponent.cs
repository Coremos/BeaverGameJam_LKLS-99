using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemConverterComponent : ItemBox
{
    public ItemComponent ItemComponent;
    public ScrollRect OutputScrollRect;
    public Button ConvertButton;

    public GameObject InfoPanel;
    public Text NameText;
    public Text DiscriptionText;

    [SerializeField]
    public ItemConverterData ItemConverterData;

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
        if (ItemConverterData == null)
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

            if (compo.IsConverted)
            {
                continue;
            }

            compo.IsConverted = true;
            compo.ConverterName = ItemConverterData.ConverterName;
            compo.NowItemType = ItemComponent.ItemType.ConverterOutput;

            compo.transform.parent = OutputScrollRect.content;
        }
    }

}
