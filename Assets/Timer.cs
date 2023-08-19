using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image image;
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
        image.fillAmount = currentTime * divider;
        if (currentTime > 0.0f) return;
        OnEndTimer();
    }

    private void OnEndTimer()
    {

    }
}