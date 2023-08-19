using UnityEngine;

public class TitleScene : MonoBehaviour
{
    [SerializeField] private ItemSpriteBinder spriteBinder;

    public void LoadCheckScene()
    {
        GameSceneManager.Instance.LoadScene(GameSceneManager.SceneType.Check);
        ItemManager.Instance.Init();
        SubmitManager.Instance.Init();
        spriteBinder.Bind(ItemManager.Instance.ItemTabeDataDic);
    }
}