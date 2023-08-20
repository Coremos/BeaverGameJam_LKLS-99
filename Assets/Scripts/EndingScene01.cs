using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScene01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("MoveTitle", 7f);
    }

    private void MoveTitle()
    {
        GameSceneManager.Instance.LoadScene(GameSceneManager.SceneType.Title);
    }
}
