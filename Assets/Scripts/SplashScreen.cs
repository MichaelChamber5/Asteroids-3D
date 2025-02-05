using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] RawImage splashText;

    [SerializeField] AudioClip beep;

    AudioSource audSource;

    private void Start()
    {
        audSource = GetComponent<AudioSource>();
        StartCoroutine(Pulse());
    }

    IEnumerator Pulse()
    {
        while (true)
        {
            while (splashText.color.a < 1)
            {
                splashText.color = new Color(1, 1, 1, splashText.color.a + 0.02f);
                yield return new WaitForSeconds(0.01f);
            }
            while (splashText.color.a > 0)
            {
                splashText.color = new Color(1, 1, 1, splashText.color.a - 0.02f);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }

    void OnStart()
    {
        audSource.PlayOneShot(beep);
        Invoke("MenuSceneLoad", 0.8f);
    }

    void MenuSceneLoad()
    {
        //throws error for the time being
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
