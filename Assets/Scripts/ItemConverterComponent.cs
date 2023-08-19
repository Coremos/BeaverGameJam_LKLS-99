using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemConverterComponent : MonoBehaviour
{
    public ItemComponent ItemComponent;
    public ScrollRect InputScrollRect;
    public ScrollRect OutputScrollRect;
    public Button ConvertButton;

    private List<ItemComponent> _inputItemComponentList =new List<ItemComponent>();
    private List<ItemComponent> _outputItemComponentList = new List<ItemComponent>();

    private ItemConverterData _itemConverterData;

    private void Awake()
    {
        _itemConverterData = new ItemConverterData();
        _itemConverterData.Index = 0;
        _itemConverterData.ConverterName = "tempConverter_0";

        SetItemConverterData(_itemConverterData);
    }

    public void SetItemConverterData(ItemConverterData itemConverterData)
    {
        _itemConverterData = itemConverterData;
        ConvertButton.interactable = _itemConverterData.GetInputItemDataList().Count > 0;
        SetInputItemComponent();
    }

    private void SetInputItemComponent()
    {
        if (_itemConverterData == null)
        {
            return;
        }

        var itemDataList = _itemConverterData.GetInputItemDataList();
        if (itemDataList == null)
        {
            return;
        }

        for (int i = 0; i < itemDataList.Count; i++)
        {
            if (itemDataList[i] == null)
            {
                continue;
            }

            if (i >= _inputItemComponentList.Count)
            {
                var compo = Instantiate(ItemComponent, InputScrollRect.content);
                if (compo == null)
                {
                    return;
                }

                _inputItemComponentList.Add(compo);
            }

            _inputItemComponentList[i].ItemCountText.text = itemDataList[i].Count.ToString();
            _inputItemComponentList[i].ItemData = itemDataList[i];
            _inputItemComponentList[i].NowItemType = ItemComponent.ItemType.ConverterInput;
            _inputItemComponentList[i].gameObject.SetActive(true);
        }
    }

    public void AddItem(ItemData itemData)
    {
        if (_itemConverterData == null)
        {
            Debug.LogWarning("Item converter data is Null");
            return;
        }

        if (itemData == null)
        {
            Debug.LogWarning("Item data is Null");
            return;
        }

        _itemConverterData.AddItem(itemData);
        ConvertButton.interactable = _itemConverterData.GetInputItemDataList().Count > 0;

        SetInputItemComponent();
    }

    public void OnClickConvertButton()
    {
        GameSceneManager.Instance.LoadScene(GameSceneManager.SceneType.Title);
    }

}
