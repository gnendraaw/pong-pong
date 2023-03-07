using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;

    public bool isGameOver {get; private set;}
    public bool isGamePaused {get; private set;}

    public int playerScore {get; private set;}
    public int enemyScore {get; private set;}
    public float countdown;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(ResetGameplay());
    }

    public void AddPlayerScore(int scoreToAdd) 
    {
        playerScore += scoreToAdd;
    }

    public void AddEnemyScore(int scoreToAdd)
    {
        enemyScore += scoreToAdd;
    }

    public IEnumerator ResetGameplay()
    {
        // reset ball behaviour
        GameObject ball = GameObject.Find("Ball");
        if (ball != null) 
        {
            ball.transform.position = Vector2.zero;
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        isGameOver = false;
        isGamePaused = false;
        countdown = 3f;

        StartCoroutine(GameplayUIHandler.instance.ToggleCountdownPanel());

        // give the ball velocity after countdown value reach 0
        yield return new WaitForSeconds(countdown);
        ball.GetComponent<BallController>().LaunchBall();
    }
}
