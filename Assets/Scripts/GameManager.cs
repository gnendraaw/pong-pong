using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float spaceBetweenSquare = 0.6f;
    private float minXValue = -1.5f;
    private float minYValue = 0.3f;
    private int maxXIndex = 6;
    private int maxYIndex = 4;

    private int score = 0;

    public GameObject targetBox;

    private void Start()
    {
        spawnTargetBox();
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
        UIHandler.instance.UpdateScoreText(score);
    }
}
