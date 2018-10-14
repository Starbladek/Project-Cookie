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
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * maxSpeed;

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
