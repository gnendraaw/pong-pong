using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScoreText;
    public GameObject gameOverPanel;

    public void UpdateScoreText(int score)
    {
        scoreText.text = "SCORE: " + score.ToString();
        gameOverScoreText.text = score.ToString();
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
}
