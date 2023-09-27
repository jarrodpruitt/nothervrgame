using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonClick : MonoBehaviour
{
    public GameObject screen2;
    public AudioSource source;
    public AudioClip dialogue6_1;
    public AudioClip dialogue6_2;
    public AudioClip dialogue6_3;
    public AudioClip dialogue6_4;

    public mainScript main;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stealOption(){
        source.PlayOneShot(dialogue6_1,1);
        //make the screen reappear
        Invoke("waitForScreen", 8);
    }

    public void breakOption(){
        source.PlayOneShot(dialogue6_2,1);
        //make the screen reappear
        Invoke("waitForScreen", 8);
    }

    public void forgetOption(){
        source.PlayOneShot(dialogue6_3,1);
        //make the screen reappear
        Invoke("waitForScreen", 7);
    }

    public void askOption(){
        source.PlayOneShot(dialogue6_4,1);

        //correct option so we move to the next event
        Invoke("showNextEvent",6);
    }

    void waitForScreen(){
        screen2.SetActive(true);
    }

    void showNextEvent(){
        main.setChosenAction(true);
    }
}
