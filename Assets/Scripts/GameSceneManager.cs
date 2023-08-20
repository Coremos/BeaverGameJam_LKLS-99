public class GameSceneManager : Singleton<GameSceneManager>
{
    public enum SceneType
    {
        Title,
        Check,
        Making,
        Ending,
        Ending01,
        Happy,
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
            case SceneType.Ending01:
                UnityEngine.SceneManagement.SceneManager.LoadScene("EndingScene01");
                break;
            case SceneType.Happy:
                UnityEngine.SceneManagement.SceneManager.LoadScene("HappyEnding");
                break;
        }
    }
}