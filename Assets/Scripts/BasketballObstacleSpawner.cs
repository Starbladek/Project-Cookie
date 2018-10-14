using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballObstacleSpawner : MonoBehaviour
{
    public BasketballObstacle basketball;
    public float spawnTimerLengthMin;
    public float spawnTimerLengthMax;
    float spawnTimerLength;
    float spawnTimer;
    Camera mainCamera;

    void Start()
    {
        spawnTimerLength = Random.Range(spawnTimerLengthMin, spawnTimerLengthMax);
        spawnTimer = spawnTimerLength;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimerLength = Random.Range(spawnTimerLengthMin, spawnTimerLengthMax);
            spawnTimer = spawnTimerLength;
            float yPos = (Random.Range(0, 2) == 1) ? 2f : -4f;
            Vector3 spawnPos = new Vector2(mainCamera.ScreenToWorldPoint(new Vector2(Screen.width + 10f, 0)).x, yPos);
            spawnPos.z = 0;
            Instantiate(basketball.gameObject, spawnPos, Quaternion.identity);
        }
    }
}