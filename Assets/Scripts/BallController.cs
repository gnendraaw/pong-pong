using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    public float xPos;
    public float yPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Invoke("LaunchBall", 2f);
    }

    void LaunchBall()
    {
        xPos = GenerateRandomPos();
        yPos = GenerateRandomPos();
        Vector2 direction = new Vector2(xPos, yPos);
        rb.velocity = direction * speed * Time.deltaTime;
    }

    float GenerateRandomPos()
    {
        int rand = Random.Range(0,2);
        return rand == 1 ? 1f : -1f;
    }
}
