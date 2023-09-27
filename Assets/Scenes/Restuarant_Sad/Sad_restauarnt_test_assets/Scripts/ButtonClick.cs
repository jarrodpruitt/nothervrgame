using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{  
    public GameObject screen1;
    public AudioSource source;
    public AudioClip dialogue5_1;
    public AudioClip dialogue5_2;
    public AudioClip dialogue5_3;
    public AudioClip dialogue5_4;

    public mainScript main;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HappyClick(){
        source.PlayOneShot(dialogue5_1,1);

        //make the screen reappear
        Invoke("waitForScreen", 7);
    }

    public void ScaredClick(){
        source.PlayOneShot(dialogue5_2,1);
        Invoke("waitForScreen", 7);
    }

    public void AngryClick(){
        source.PlayOneShot(dialogue5_3,1);
        Invoke("waitForScreen", 7);
    }

    public void DisappointedClick(){    // correct option
        source.PlayOneShot(dialogue5_4,1);
        Invoke("showNextScreen", 12);
    }

    void waitForScreen(){
        screen1.SetActive(true);
    }

    void showNextScreen(){
        main.setChosenEmotion(true);
    }
}
