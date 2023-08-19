using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScene : MonoBehaviour
{
    public void OnClickRetry()
    {
        var sceneType = GameSceneManager.SceneType.Title;

        if (SubmitManager.Instance.CanSubmit())
        {
            sceneType = GameSceneManager.SceneType.Making;
        }

        GameSceneManager.Instance.LoadScene(sceneType);

    }
}
