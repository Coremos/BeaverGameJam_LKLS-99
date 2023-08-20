using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyEndingScene : MonoBehaviour
{

    public void OnClickEnd()
    {
        GameSceneManager.Instance.LoadScene(GameSceneManager.SceneType.Title);
    }
}
