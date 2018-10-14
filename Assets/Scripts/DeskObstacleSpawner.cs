using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskObstacleSpawner : MonoBehaviour
{
    public DeskObstacle[] obstacles;
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
            Vector3 spawnPos = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width + 10f, Random.Range(Screen.height * 0.25f, Screen.height * 0.6f)));
            spawnPos.z = 0;
            Instantiate(obstacles[0].gameObject, spawnPos, Quaternion.identity);
        }
    }
}