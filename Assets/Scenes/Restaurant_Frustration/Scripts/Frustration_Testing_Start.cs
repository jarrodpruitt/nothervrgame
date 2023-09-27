using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Frustration_Testing_Start : MonoBehaviour
{
    public GameObject Mom;
    public GameObject Brother;

    public GameObject WhatShouldYouDoSelection;
    private Animator animBrother;
    private Animator animMom;
    public AudioSource audioSource;
    public AudioClip ambientsound;
    public AudioClip start1;
    public AudioClip waitinline;
    public AudioClip waitingtime;
    bool designatedLocation = false;
    bool gotoline = false;
    void Start()
    {
        WhatShouldYouDoSelection.SetActive(false);
        audioSource.clip = ambientsound;
        audioSource.loop = true;
        audioSource.Play();
        audioSource.volume = 0.5f;
        // Grab the animation controller and respective animations for each character
        animBrother = Brother.GetComponent<Animator>();
        animMom = Mom.GetComponent<Animator>();
        StartCoroutine(waitBeforeStart());
    }

    public void Update(){
        if(designatedLocation){
            Mom.transform.position += transform.right * (0.5f) * Time.deltaTime;
            Brother.transform.position += transform.right * (0.5f) * Time.deltaTime;
            animBrother.Play("Male_walk");
            animMom.Play("Female_walk");
            if(Mom.transform.position.x >= -26.5){
                    designatedLocation = false;
            }
        }else if(gotoline){
            Mom.transform.position += transform.forward * (0.5f) * Time.deltaTime;
            Brother.transform.position += transform.forward * (0.5f) * Time.deltaTime;
            animBrother.Play("Male_walk");
            animMom.Play("Female_walk");
            if(Mom.transform.position.z >= 67){
                    gotoline = false;
            }
        }
        else{                   // Otherwise, all characters are on idle animation
            animBrother.Play("Male_idle");
            animMom.Play("Female_idle");
        }
    }

    IEnumerator waitBeforeStart(){
        yield return new WaitForSeconds(2);
        Mom.transform.Rotate(0f, 90f, 0f, Space.Self);
        Brother.transform.Rotate(0f, 90f, 0f, Space.Self);
        designatedLocation = true;


        yield return new WaitForSeconds(5);
        Mom.transform.Rotate(0f, -45f, 0f, Space.Self);
        Brother.transform.Rotate(0f, -45f, 0f, Space.Self);
        audioSource.PlayOneShot(start1, 5f);

        yield return new WaitForSeconds(5);
        audioSource.PlayOneShot(waitinline, 5f);

        yield return new WaitForSeconds(4);
        Mom.transform.Rotate(0f, -45f, 0f, Space.Self);
        Brother.transform.Rotate(0f, -45f, 0f, Space.Self);
        gotoline = true;

        yield return new WaitForSeconds(5);
        Mom.transform.Rotate(0f, 90f, 0f, Space.Self);
        Brother.transform.Rotate(0f, 90f, 0f, Space.Self);

        yield return new WaitForSeconds(5);
        audioSource.PlayOneShot(waitingtime, 5f);
        yield return new WaitForSeconds(5);
        WhatShouldYouDoSelection.SetActive(true);
    }
}
