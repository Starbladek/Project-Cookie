using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Canvas gameOverScreen;
    bool gameOver;

    public float acceleration;
    public float maxSpeed;
    public float basketballKnockbackAmount;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Camera mainCamera;
    AudioSource audioSource;
    public AudioClip oof;
    public AudioClip aah;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce(movement * acceleration);

        if (transform.position.x > mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x - (sr.bounds.size.x * 0.5f))
            transform.position = new Vector2(mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x - (sr.bounds.size.x * 0.5f), transform.position.y);

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
        audioSource.clip = oof;

        if (other.gameObject.CompareTag("Death Entity"))
        {
            audioSource.clip = aah;
            gameOver = true;
            Instantiate(gameOverScreen);
            Time.timeScale = 0;
        }

        audioSource.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Basketball"))
        {
            rb.AddForce(new Vector2(-basketballKnockbackAmount, 0));
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-other.gameObject.GetComponent<Rigidbody2D>().velocity.x, 10f);
        }
    }
}