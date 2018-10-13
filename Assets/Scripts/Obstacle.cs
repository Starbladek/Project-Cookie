using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        Vector3 spawnPos = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 2));
        transform.position = new Vector3(spawnPos.x, spawnPos.y);
    }

    void Update()
    {
        //rb.AddForce(Vector2.left * speed);
        rb.velocity = Vector2.left * speed;
    }
}
