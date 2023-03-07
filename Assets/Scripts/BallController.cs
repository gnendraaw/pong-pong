using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy Wall"))
        {
            GameplayManager.Instance.AddPlayerScore(1);
            GameplayUIHandler.instance.UpdatePlayerScore(GameplayManager.Instance.playerScore);

            StartCoroutine(GameplayManager.Instance.ResetGameplay());
        }
        else if (collider.gameObject.CompareTag("Player Wall"))
        {
            GameplayManager.Instance.AddEnemyScore(1);
            GameplayUIHandler.instance.UpdateEnemyScore(GameplayManager.Instance.enemyScore);

            StartCoroutine(GameplayManager.Instance.ResetGameplay());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void LaunchBall()
    {
        Vector2 direction = new Vector2(GenerateRandomPos(), GenerateRandomPos());
        rb.velocity = direction * speed;
    }

    float GenerateRandomPos()
    {
        return Random.Range(0, 2) == 1 ? 1f : -1f;
    }
}
