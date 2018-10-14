using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskObstacle : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.velocity = Vector2.left * speed;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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