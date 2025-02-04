using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    int score;

    private void Start()
    {
        score = 0;
        UpdateText();
    }

    private void UpdateText()
    {
        scoreText.text = "Score: " + score;
    }

    public void IncreaseScore(int incAmount)
    {
        score += incAmount;
        UpdateText();
    }
}
