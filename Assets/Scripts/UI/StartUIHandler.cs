using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartUIHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateScoreText(StartManager.Instance.score);
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }
}
