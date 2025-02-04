using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField] Image panel;

    public void EndGame()
    {
        Invoke("BlackenScreen", 1);
        Invoke("Restart", 2.5f);
    }

    void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Space");
    }

    void BlackenScreen()
    {
        StartCoroutine(ScreenDarkens());
    }

    IEnumerator ScreenDarkens()
    {
        while (panel.color.a < 1)
        {
            panel.color = new Color(0, 0, 0, panel.color.a + 0.02f);
            yield return new WaitForEndOfFrame();
        }
    }
}
