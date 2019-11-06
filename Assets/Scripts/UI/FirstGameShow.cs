using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstGameShow : MonoBehaviour
{
    public CanvasGroup canvas;
    void Awake()
    {
        var test = PlayerPrefs.GetString(Tags.beginAll);

        if (test == "true")
        {
            canvas.alpha = 0;
            canvas.blocksRaycasts = false;
        }
        else if (test == "false" || test == null)
        {
            canvas.alpha = 1;
            canvas.blocksRaycasts = true;
        }

        Debug.Log(test);
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey(Tags.beginAll);
    }
}
