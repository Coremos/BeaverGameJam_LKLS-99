using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrevPanelComponent : MonoBehaviour
{
    public Transform content;
    public PrevItemComponent PrevItemComponent;

    public Text ScoreText;

    private List<PrevItemComponent> _prevItemComponentList = new List<PrevItemComponent>();

    public void SetPrevPanel(List<int> prevIndexList, string result)
    {
        InitComponent(prevIndexList);
        ScoreText.text = result;
    }

    private void InitComponent(List<int> prevIndexList)
    {
        var activeCount = 0;
        for (int i = 0; i < prevIndexList.Count; i++)
        {
            if (i >= _prevItemComponentList.Count)
            {
                var compo = Instantiate(PrevItemComponent, content);
                if (compo == null)
                {
                    continue;
                }

                _prevItemComponentList.Add(compo);
            }

            //_prevItemComponentList[i].ItemImage = 
            _prevItemComponentList[i].gameObject.SetActive(true);

            activeCount++;
        }
    }

}
