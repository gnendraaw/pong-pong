using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartUIHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinsText;

    void Start()
    {
        UpdateScoreText(DataManager.Instance.score);
        UpdateCoinsText(DataManager.Instance.coins);
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateCoinsText(int coins)
    {
        coinsText.text = coins.ToString();
    }
}
