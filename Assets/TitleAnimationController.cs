using TMPro;
using UnityEngine;

public class TitleAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshPro text;

    public void Play(string value)
    {
        text.text = value;
        animator.Play("Showing");
    }
}