using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float deltaX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && !GameplayManager.Instance.isGameOver && !GameplayManager.Instance.isGamePaused)
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        Touch touch = Input.GetTouch(0);
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

        if (touch.phase == TouchPhase.Began)
        {
            deltaX = touchPos.x - transform.position.x;
        }
        if (touch.phase == TouchPhase.Moved) 
        {
            rb.MovePosition(Vector2.right * (touchPos.x - deltaX));
        }
        if (touch.phase == TouchPhase.Ended)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
