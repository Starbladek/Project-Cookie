using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicSpeech : MonoBehaviour
{
    private float speech_delay = 0.1f;
    public SpeechBox enemyTalk;
    public GameObject SpeechPrefab;

    private GameObject SpeechBubble;

    private string inQueueText;
    private string currentstring;


    public void Start()
    {
        Speech(enemyTalk.dialogue);
    }

    public void Speech(string[] inQueueText)
    {
        int randomMessage = Random.Range(0, inQueueText.Length);
        StartCoroutine(OneCharectorAtATime(inQueueText));
    }

    IEnumerator OneCharectorAtATime(string[] inQueueText)
    {
        while (true)
        {
            int randomnumber = Random.Range(0, inQueueText.Length);
            float randomTime = Random.Range(5f, 15f);
            SpeechBubble = (GameObject)Instantiate(SpeechPrefab, transform.position, transform.rotation);
            SpeechBubble.GetComponentInChildren<Text>().text = " ";
            for (int j = 0; j <= inQueueText[randomnumber].Length; j++)
            {
                currentstring = inQueueText[randomnumber].Substring(0, j);
                SpeechBubble.GetComponentInChildren<Text>().text = currentstring;
                yield return new WaitForSeconds(speech_delay);
            }
            //wait for a second before starting over
            yield return new WaitForSeconds(3f);
            Destroy(SpeechBubble);
            currentstring = " ";
            yield return new WaitForSeconds(randomTime);
        }
    }
}

[System.Serializable]
public class SpeechBox
{
    [TextArea(3,13)]
    public string[] dialogue;
}
