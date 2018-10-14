using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Canvas gameOverScreen;
    bool gameOver;

    public float maxSpeed;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * maxSpeed;

        if (transform.position.x > mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x - (sr.bounds.size.x * 0.5f))
            transform.position = new Vector2(mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x - (sr.bounds.size.x * 0.5f), transform.position.y);
        //if (transform.position.x > Screen.width)
        //transform.position = new Vector2(Screen.width, transform.position.y);

        if (transform.position.y > 2.5f)
            transform.position = new Vector2(transform.position.x, 2.5f);
        if (transform.position.y < -4f)
            transform.position = new Vector2(transform.position.x, -4f);

        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Michael", LoadSceneMode.Single);
                Time.timeScale = 1;
            }
        }

        sr.sortingOrder = (int)-transform.position.y;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Death Entity"))
        {
            gameOver = true;
            Instantiate(gameOverScreen);
            Time.timeScale = 0;
        }
    }
}
