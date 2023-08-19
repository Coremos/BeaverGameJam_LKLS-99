using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitManager : Singleton<SubmitManager>
{
    public enum SubmitResultType
    {
        None = 0,
        Strike,
        Ball,
        Fail
    }

    private List<int> _answerItemIndexList = new List<int>() { 12, 8, 16, 20, 2, 5, 8, 12, 24 };

    private readonly int _maxItemCount = 9;
    private readonly int _maxSubmitCount = 3;
    private int _nowSubmitCount = 0;

    public void Init()
    {
        _nowSubmitCount = 0;
    }

    public bool CanSubmit()
    {
        return (_nowSubmitCount < _maxSubmitCount);
    }

    public List<SubmitResultType> Submit(List<ItemComponent> inputComponentList)
    {
        _nowSubmitCount++;
        var result = new List<SubmitResultType>();
        for (int i = 0; i < _answerItemIndexList.Count; i++)
        {
            if (i >= inputComponentList.Count)
            {
                result.Add(SubmitResultType.Fail);
                continue;
            }

            var submitItemIndex = inputComponentList[i].ItemData.Index;
            if (ItemManager.Instance.ItemTabeDataDic.ContainsKey(submitItemIndex) == false)
            {
                result.Add(SubmitResultType.Fail);
                continue;
            }

            var tableData = ItemManager.Instance.ItemTabeDataDic[submitItemIndex];
            if (tableData.NeedConvert)
            {
                if (inputComponentList[i].ItemData.IsConverted == false)
                {
                    result.Add(SubmitResultType.Fail);
                    continue;
                }

                if (string.Compare(inputComponentList[i].ItemData.ConverterName, tableData.Answer) != 0)
                {
                    result.Add(SubmitResultType.Fail);
                    continue;
                }
            }

            if (submitItemIndex == _answerItemIndexList[i])
            {
                result.Add(SubmitResultType.Strike);
            }
            else
            {
                if (_answerItemIndexList.Contains(submitItemIndex))
                {
                    result.Add(SubmitResultType.Ball);
                }
                else
                {
                    result.Add(SubmitResultType.Fail);
                }
            }
        }

        //_inputItemDataList.Clear();
        return result;
    }
}
