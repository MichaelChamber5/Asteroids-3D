using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuControls : MonoBehaviour
{
    [SerializeField] AudioClip beep;
    [SerializeField] TMP_Text highscore;

    AudioSource audSource;

    private void Start()
    {

        if (!PlayerPrefs.HasKey("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", 0);
        }
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");

        audSource = GetComponent<AudioSource>();
    }

    void OnStart()
    {
        Invoke("Play", 0.8f);
        audSource.PlayOneShot(beep);
    }

    void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Space");
    }

    void GoToControls()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Information");
    }

    void OnBack()
    {
        Application.Quit();
    }

    void OnControls()
    {
        Invoke("GoToControls", 0.8f);
        audSource.PlayOneShot(beep);
    }

    void OnReset()
    {
        PlayerPrefs.SetInt("Highscore", 0);
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
    }
}
