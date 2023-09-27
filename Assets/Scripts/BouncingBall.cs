using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    float time;
    float velocity;
    AudioSource boing;
    bool playing;

    void Start()
    {
        playing = false;
        time = 0;
        velocity = 0;
        boing = GetComponent<AudioSource>();
        boing.volume = .05f;
        InvokeRepeating("PlaySound", .5f, .75f);
    }
    void Update()
    {
        velocity = Mathf.Sin(time);
        this.transform.position += new Vector3(0, velocity * 5f, 0) * Time.deltaTime;
        this.transform.position += this.transform.forward * .75f * Time.deltaTime;
        time += .075f;
        playing = false;
    }
    void PlaySound()
    {
        if(!playing)
            boing.Play();
        if (boing.volume < 1)
            boing.volume += .15f;
        playing = true;
    }
}
