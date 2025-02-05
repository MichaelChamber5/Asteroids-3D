using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoScreenScript : MonoBehaviour
{
    [SerializeField] AudioClip backBeep;

    AudioSource audSource;

    private void Start()
    {
        audSource = GetComponent<AudioSource>();
    }

    void OnBack()
    {
        audSource.PlayOneShot(backBeep);
        Invoke("Return", 0.8f);
    }

    void Return()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
