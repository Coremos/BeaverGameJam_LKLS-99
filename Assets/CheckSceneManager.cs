using UnityEngine;

public class CheckSceneManager : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private TitleAnimationController titleAnimationController;

    private void Start()
    {
        titleAnimationController.Add("기자들이 다가온다…!");
        titleAnimationController.Add("아직 초전도체는 미완성이야!");
        titleAnimationController.Add("재료를 모아 초전도체 지하연구실로 이동하자!");
        titleAnimationController.Play();

        timer.SetTimer(60.0f);
    }
}
