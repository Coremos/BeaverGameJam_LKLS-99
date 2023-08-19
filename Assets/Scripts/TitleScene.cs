using UnityEngine;

public class TitleScene : MonoBehaviour
{
    public void LoadCheckScene()
    {
        GameSceneManager.Instance.LoadScene(GameSceneManager.SceneType.Check);
        ItemManager.Instance.Init();
    }
}