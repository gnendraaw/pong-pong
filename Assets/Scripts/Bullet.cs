using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float xDir = 5f;
    public float yDir = 5f;
    private Rigidbody2D rb;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        rb = GetComponent<Rigidbody2D>();

        GoBall();
    }

    void GoBall()
    {
        Vector2 vel = new Vector2 (xDir, yDir);
        rb.velocity = vel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bottom Wall" && !gameManager.isGameOver) {
            gameManager.GameOver();
        }
    }
}
