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

        Invoke("LaunchBall", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        Vector2 direction = new Vector2(GenerateRandomPos(), GenerateRandomPos());
        rb.velocity = direction * speed;
    }

    float GenerateRandomPos()
    {
        return Random.Range(-1.0f, 1.0f);
    }
}
