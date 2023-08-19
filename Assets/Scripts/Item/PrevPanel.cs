using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PrevPanel : MonoBehaviour
{
    public Transform content;
    public PrevPanelComponent PrevPanelComponent;

    private void Awake()
    {
        var prevSubmit = SubmitManager.Instance.PrevSubmit;
        var prevResult = SubmitManager.Instance.PrevResult;

        if (prevSubmit.Count == 0)
        {
            this.gameObject.SetActive(false);
            return;
        }

        this.gameObject.SetActive(true);
        for (int i = 0; i < prevSubmit.Count; i++)
        {
            var compo = Instantiate(PrevPanelComponent, content);
            if (compo == null)
            {
                continue;
            }

            compo.SetPrevPanel(prevSubmit[i], prevResult[i]);
        }

    }
}
