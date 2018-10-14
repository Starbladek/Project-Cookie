using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballObstacle : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Camera mainCamera;

    public float launchSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        transform.position = new Vector2(mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height/2)).x, 0);
        rb.velocity = new Vector2(-launchSpeed, 5f);
    }

    void Update()
    {
        if (transform.position.x < mainCamera.ScreenToWorldPoint(new Vector2(0, Screen.height)).x - sr.sprite.bounds.size.x)
        {
            Destroy(gameObject);
        }

        sr.sortingOrder = (int)-transform.position.y;
    }
}