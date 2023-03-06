using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        if (!GameplayManager.isGameOver && !GameplayManager.isGamePaused && ball.transform.position.y > 0)
        {
            float distance = ball.transform.position.x - transform.position.x;
            transform.position += Vector3.right * distance * speed * Time.deltaTime;
        }
    }
}
