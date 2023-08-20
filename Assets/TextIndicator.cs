using System.Collections;
using TMPro;
using UnityEngine;

public class TextIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string value;

    private WaitForSeconds wait = new WaitForSeconds(0.2f);

    public IEnumerator Type()
    {
        for (int index = 0; index <= value.Length; index++)
        {
            text.text = value.Substring(0, index);
            yield return wait;
        }
        yield return null;
    }

    public void GoBack()
    {
        GameSceneManager.Instance.LoadScene(GameSceneManager.SceneType.Title);
    }
}