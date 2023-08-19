using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScene : MonoBehaviour
{
    public void OnClickRetry()
    {
        GameSceneManager.Instance.LoadScene(GameSceneManager.SceneType.Making);
    }
}
