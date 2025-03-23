using UnityEngine;
using System.Collections;

public class StartMenuFade : MonoBehaviour
{
    public CanvasGroup startPanel;

    public void ClosePanel()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        while (startPanel.alpha > 0)
        {
            startPanel.alpha -= Time.deltaTime;
            yield return null;
        }
        startPanel.gameObject.SetActive(false);
    }
}
