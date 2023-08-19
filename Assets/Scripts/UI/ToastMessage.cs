using UnityEngine;
using UnityEngine.UI;

public class ToastMessage : Singleton<ToastMessage>
{
    [SerializeField] private ToastMessageObject prefab;

}

public class ToastMessageObject : MonoBehaviour
{
    [SerializeField] private Text text;
    public void Toast()
    {

    }
}