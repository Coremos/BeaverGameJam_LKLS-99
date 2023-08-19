using UnityEngine;

public class CheckSceneManager : MonoBehaviour
{
    [SerializeField] private Timer timer;

    private void Start()
    {
        timer.SetTimer(60.0f);
    }
}
