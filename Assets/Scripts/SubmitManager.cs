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

    private List<int> _answerItemIndexList = new List<int>() { 11, 8, 15, 19, 2, 5, 8, 11, 17 };

    private readonly int _maxItemCount = 9;
    private readonly int _maxSubmitCount = 3;
    public Dictionary<int, List<int>> PrevSubmit = new Dictionary<int, List<int>>();
    public Dictionary<int, string> PrevResult = new Dictionary<int, string>();
    private int _nowSubmitCount = 0;
    public bool IsClear = false;

    public void Init()
    {
        PrevSubmit.Clear();
        PrevResult.Clear();
        IsClear = false;
    }

    public bool CanSubmit()
    {
        return (PrevSubmit.Count < _maxSubmitCount);
    }

    public List<SubmitResultType> GetSubmitResult(List<ItemComponent> inputComponentList)
    {
        var count = PrevSubmit.Count;
        PrevSubmit.Add(count, new List<int>());
        var result = new List<SubmitResultType>();
        for (int i = 0; i < _answerItemIndexList.Count; i++)
        {
            if (i >= inputComponentList.Count)
            {
                result.Add(SubmitResultType.Fail);
                continue;
            }

            PrevSubmit[count].Add(inputComponentList[i].ItemData.Index);
            var submitItemIndex = inputComponentList[i].ItemData.Index;
            if (ItemManager.Instance.ItemTabeDataDic.ContainsKey(submitItemIndex) == false)
            {
                result.Add(SubmitResultType.Fail);
                continue;
            }

            var tableData = ItemManager.Instance.ItemTabeDataDic[submitItemIndex];
            if (tableData.NeedConvert)
            {
                if (inputComponentList[i].IsConverted == false)
                {
                    result.Add(SubmitResultType.Fail);
                    continue;
                }

                if (string.Compare(inputComponentList[i].ConverterName, tableData.Answer) != 0)
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

        SetScore(count, result);
        //_inputItemDataList.Clear();
        return result;
    }

    private void SetScore(int key, List<SubmitResultType> resultTypeList)
    {
        int strike = 0;
        int ball = 0;
        int fail = 0;

        foreach (var result in resultTypeList)
        {
            switch (result)
            {
                case SubmitResultType.Strike:
                    strike++;
                    break;
                case SubmitResultType.Ball:
                    ball++;
                    break;
                case SubmitResultType.Fail:
                    fail++;
                    break;
            }
        }

        if (strike >= 9)
        {
            IsClear = true;
        }

        PrevResult.Add(key, $"{strike} / {ball} / {fail}");
    }

}
