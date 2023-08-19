using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class SubmitComponent : ItemBox
{
    public void OnClickSubmitButton()
    {
        StringBuilder stringBuilder = new StringBuilder();

        var result = SubmitManager.Instance.GetSubmitResult(GetItemComponentList());
        for (int i = 0; i < result.Count; i++)
        {
            stringBuilder.Append($"[{i}] {result[i]} / ");
        }

        Debug.Log(stringBuilder.ToString());

        GameSceneManager.Instance.LoadScene(GameSceneManager.SceneType.Ending);
    }
}
