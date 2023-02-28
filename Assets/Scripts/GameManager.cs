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
    public bool isGameOver = false;

    public GameObject targetBox;
    public GameObject bullet;

    public UIHandler uiHandler;

    private void Start()
    {
        SetupGame();

        spawnTargetBox();
    }

    void Update()
    {
        if (Input.touchCount > 0 && isGameOver) {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended) {
                RestartGame();
            }
        }
    }

    void SetupGame()
    {
        isGameOver = false;

        score = DataManager.Instance.score;
        uiHandler.UpdateScoreText(score);

        targetCount = maxXIndex * maxYIndex;
        currentTargetCount = targetCount;

        Instantiate(bullet, Vector3.up * -2f, bullet.transform.rotation);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(1);
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

        // reset and spawn target when all of the targets are destroyed
        if (currentTargetCount <= 0) {
            currentTargetCount = targetCount;
            spawnTargetBox();
        }

        uiHandler.UpdateScoreText(score);
    }

    public void GameOver()
    {
        // show game over panel
        isGameOver = true;
        uiHandler.ShowGameOverPanel();

        // save player score
        DataManager.Instance.SaveScore(score);
    }
}
