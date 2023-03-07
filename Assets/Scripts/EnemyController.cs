using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private GameObject ball;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        if (!GameplayManager.Instance.isGameOver && !GameplayManager.Instance.isGamePaused && ball.transform.position.y > 0)
        {
            float xDir = ball.transform.position.x - transform.position.x;
            Vector2 dir = new Vector2(xDir, transform.position.y);
            rb.velocity = dir * speed;
        }
    }
}
