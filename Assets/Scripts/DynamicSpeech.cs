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

        SpeechBubble = (GameObject)Instantiate(SpeechPrefab, transform.position, transform.rotation);
        SpeechBubble.transform.position += new Vector3(0.25f, 0, 0);
        SpeechBubble.GetComponentInChildren<Text>().text = currentstring;
        Speech(enemyTalk.dialogue);

    }

    public void Speech(string[] inQueueText)
    {
        StartCoroutine(OneCharectorAtATime(inQueueText));
    }

    IEnumerator OneCharectorAtATime(string[] inQueueText)
    {
        for (int i = 0; i < inQueueText.Length; i++)
        {
            currentstring = " ";
            for (int j = 0; j <= inQueueText[i].Length; j++)
            {
                currentstring = inQueueText[i].Substring(0, j);
                //print(currentstring);
                SpeechBubble.GetComponentInChildren<Text>().text = currentstring;
                yield return new WaitForSeconds(speech_delay);
            }
            //wait for a second before starting over
            yield return new WaitForSeconds(3f);
        }
        Destroy(SpeechBubble);
    }

}

[System.Serializable]
public class SpeechBox
{
    [TextArea(3,13)]
    public string[] dialogue;
}
