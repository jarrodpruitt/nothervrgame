using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudio : MonoBehaviour
{
    public AudioSource audioSource;
    void Start()
    {
        StartCoroutine(waitBeforeStart());
    }

    IEnumerator waitBeforeStart(){
        yield return new WaitForSeconds(2);
        audioSource.Play();
    }
}

