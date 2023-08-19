public class GameSceneManager : Singleton<GameSceneManager>
{
    public enum SceneType
    {
        Title,
        Check,
        Making,
        Ending
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void LoadScene(SceneType sceneType)
    {
        switch (sceneType)
        {
            case SceneType.Title:
                UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
                break;
            case SceneType.Check:
                UnityEngine.SceneManagement.SceneManager.LoadScene("CheckScene");
                break;
            case SceneType.Making:
                UnityEngine.SceneManagement.SceneManager.LoadScene("MakingScene");
                break;
            case SceneType.Ending:
                UnityEngine.SceneManagement.SceneManager.LoadScene("EndingScene");
                break;
        }
    }
}