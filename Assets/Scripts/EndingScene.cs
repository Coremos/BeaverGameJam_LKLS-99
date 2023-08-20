using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScene : MonoBehaviour
{
    public void OnClickRetry()
    {
        if (SubmitManager.Instance.IsClear)
        {
            GameSceneManager.Instance.LoadScene(GameSceneManager.SceneType.Title);
            return;
        }

        if (SubmitManager.Instance.CanSubmit())
        {
            GameSceneManager.Instance.LoadScene(GameSceneManager.SceneType.Making);
        }
        else
        {
            GameSceneManager.Instance.LoadScene(GameSceneManager.SceneType.Ending01);
        }

    }
}
