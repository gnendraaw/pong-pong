using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Invoke("LaunchBall", 1f);
    }

    void LaunchBall()
    {
        Vector2 direction = new Vector2(GenerateRandomPos(), GenerateRandomPos());
        rb.velocity = direction * speed;
    }

    float GenerateRandomPos()
    {
        return Random.Range(0, 2) == 1 ? 1f : -1f;
    }
}
