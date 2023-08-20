using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image front;
    [SerializeField] private Image back;
    private float setupTime;
    private float currentTime;
    private float divider;

    public void SetTimer(float time)
    {
        setupTime = time;
        divider = 1.0f / setupTime;
        currentTime = time;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        front.fillAmount = currentTime * divider;
        back.color = Color.Lerp(Color.red, Color.green, front.fillAmount);
        if (currentTime > 0.0f) return;
        OnEndTimer();
    }

    private void OnEndTimer()
    {
        GameSceneManager.Instance.LoadScene(GameSceneManager.SceneType.Ending01);
    }
}