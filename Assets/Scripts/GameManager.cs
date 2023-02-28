using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float spaceBetweenSquare = 0.6f;
    private float minXValue = -1.5f;
    private float minYValue = 0.3f;
    private int maxXIndex = 6;
    private int maxYIndex = 4;
    private int targetCount;
    private int currentTargetCount;

    private int score = 0;

    public GameObject gameOverPanel;
    public GameObject targetBox;
    public GameObject bullet;

    private void Start()
    {
        SetupGame();

        spawnTargetBox();

        Instantiate(bullet, Vector3.up * -2f, bullet.transform.rotation);
    }

    void Update()
    {
        if (Input.touchCount > 0 && !StartManager.Instance.isGameActive)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }
    }

    void SetupGame()
    {
        score = StartManager.Instance.score;
        UIHandler.instance.UpdateScoreText(score);

        targetCount = maxXIndex * maxYIndex;
        currentTargetCount = targetCount;
    }

    void spawnTargetBox()
    {
        for (int i = 0; i < maxYIndex; i++)
        {
            for (int j = 0; j < maxXIndex; j++)
            {
                float xSpawnPos = GenerateSpawnPos(j, minXValue);
                float ySpawnPpos = GenerateSpawnPos(i, minYValue);
                Vector2 spawnPos = new Vector2(xSpawnPos, ySpawnPpos);

                Instantiate(targetBox, spawnPos, Quaternion.identity);
            }
        }
    }

    float GenerateSpawnPos(int index, float minValue)
    {
        return (index * spaceBetweenSquare) + minValue;
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        currentTargetCount--;

        if (targetCount <= 0) {
            ResetTargetCount();

            spawnTargetBox();
        }

        UIHandler.instance.UpdateScoreText(score);
    }

    void ResetTargetCount()
    {
        currentTargetCount = targetCount;
    }

    public void GameOver()
    {
        StartManager.Instance.SaveScore(score);
        StartManager.Instance.isGameActive = false;
        gameOverPanel.SetActive(true);

        // pause game time
        Time.timeScale = 0;
    }
}
