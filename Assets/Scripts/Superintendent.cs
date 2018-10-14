using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superintendent : MonoBehaviour
{
    public AudioClip[] yells;
    public float nextTalkTimerMin;
    public float nextTalkTimerMax;
    float nextTalkTimer;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        nextTalkTimer = Random.Range(nextTalkTimerMin, nextTalkTimerMax);
    }

    void Update()
    {
        nextTalkTimer -= Time.deltaTime;
        if (nextTalkTimer <= 0)
        {
            nextTalkTimer = Random.Range(nextTalkTimerMin, nextTalkTimerMax);
            audioSource.clip = yells[Random.Range(0, yells.Length)];
            audioSource.Play();
        }
    }
}