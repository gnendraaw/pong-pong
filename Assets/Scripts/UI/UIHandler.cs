using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static UIHandler instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        UpdateScoreText(0);
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = "SCORE: " + score.ToString();
    }
}
