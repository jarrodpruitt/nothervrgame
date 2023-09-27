using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject voice;
    [SerializeField] MomSpeaker momSpeaker;
    AudioSource line;
    AudioSource momLine;
    Animator myAnimator;
    private IEnumerator coroutine;

    void Start()
    {
        line = voice.GetComponent<AudioSource>();
    }

    public void VoiceFlag(float speakTime)
    {
        coroutine = Speak(speakTime);
        StartCoroutine(coroutine);
    }
    private IEnumerator Speak(float speakTime)
    {
        line.Play();
        while (true)
        {
            yield return new WaitForSeconds(speakTime);
            momSpeaker.Play();
        }
    }
}
