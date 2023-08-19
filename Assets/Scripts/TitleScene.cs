using UnityEngine;

public class TitleScene : MonoBehaviour
{
    [SerializeField] private ItemSpriteBinder spriteBinder;

    public void LoadCheckScene()
    {
        GameSceneManager.Instance.LoadScene(GameSceneManager.SceneType.Check);
        GameDataManager.Instance.GlobalInventory.ClearItems();
        GameDataManager.Instance.PlayerInventory.ClearItems();
        ItemManager.Instance.Init();
        SubmitManager.Instance.Init();
        spriteBinder.Bind(ItemManager.Instance.ItemTabeDataDic);
    }
}