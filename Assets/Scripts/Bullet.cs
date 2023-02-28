using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float xDir = 5f;
    public float yDir = 5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GoBall();
    }

    void GoBall()
    {
        Vector2 vel = new Vector2 (xDir, yDir);
        rb.velocity = vel;
    }
}
