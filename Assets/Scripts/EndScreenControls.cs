using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreenControls : MonoBehaviour
{
    [SerializeField] AudioClip beep;
    [SerializeField] AudioClip backBeep;
    [SerializeField] TMP_Text highscore;
    [SerializeField] TMP_Text score;

    AudioSource audSource;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", 0);
        }
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");

        if (!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetInt("Score", 0);
        }
        score.text = "Score: " + PlayerPrefs.GetInt("Score");

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

    void OnBack()
    {
        Invoke("Menu", 0.8f);
        audSource.PlayOneShot(backBeep);
    }

    void Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
