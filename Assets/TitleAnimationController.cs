using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshProUGUI text;
    private Queue<string> queue = new Queue<string>();

    public void Add(string value)
    {
        queue.Enqueue(value);
    }

    public void Play()
    {
        if (queue.Count <= 0) animator.Play("TitleHide"); 
        text.text = queue.Dequeue();
        animator.Play("TitleShow");
    }
}