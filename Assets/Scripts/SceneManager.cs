using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField] Image panel;
    [SerializeField] GameObject scoreManager;

    public void EndGame()
    {
        if (!PlayerPrefs.HasKey("Highscore") || (PlayerPrefs.HasKey("Highscore") && PlayerPrefs.GetInt("Highscore") < scoreManager.GetComponent<ScoreManager>().GetScore()))
        {
            PlayerPrefs.SetInt("Highscore", scoreManager.GetComponent<ScoreManager>().GetScore());
        }
        PlayerPrefs.SetInt("Score", scoreManager.GetComponent<ScoreManager>().GetScore());
        Invoke("BlackenScreen", 1);
        Invoke("Restart", 2.5f);
    }

    void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndScreen");
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
