using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainScript : MonoBehaviour
{
    private bool spoken = false;
    private bool chosenEmotion = false;
    private bool chosenAction = false;
    public AudioSource source;
    public AudioClip dialogue1;
    public AudioClip dialogue2;
    public AudioClip dialogue3;
    public AudioClip dialogue4;
    public AudioClip dialogue7;
    public AudioClip dialogue8;
    public AudioClip dialogue9;
    public AudioClip dialogue9_1;
    public AudioClip dialogue10;
    public AudioClip gameBallDropNoise;

    public SceneLoad sceneController;
    public GameObject firstScreen;
    public GameObject secondScreen;
    public GameObject mom;
    public GameObject main_char;
    public GameObject quarter;
    public GameObject fade;
    public GameObject gumball;
    Animator momAnim;
    Animator mainAnim;


    public mainCharMovement mainMove;

    public GameObject quarterWithAnimation;


    // name tags
    public GameObject mainNameTag;
    public GameObject motherNameTag;

    // Start is called before the first frame update
    void Start()
    {
        momAnim = mom.GetComponent<Animator>();
        mainAnim = main_char.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!spoken){
            StartCoroutine(speech());
            spoken = true;
        }
    }

    IEnumerator speech(){
        source.PlayOneShot(dialogue1,1);            //narrator
        yield return new WaitForSeconds(4f);

        mainNameTag.SetActive(true);
        source.PlayOneShot(dialogue2,1);            //main character
        mainAnim.SetTrigger("longTalk");
        yield return new WaitForSeconds(4f);
        source.PlayOneShot(dialogue3,1);            //main character
        yield return new WaitForSeconds(4f);
        mainNameTag.SetActive(false);

        source.PlayOneShot(dialogue4,1);            //narrator
        yield return new WaitForSeconds(4f);

        // prompt input (make it appear)
        firstScreen.SetActive(true);

        // wait for user to press the correct emotional option
        yield return new WaitUntil(() => chosenEmotion);

        //reveals the next screen
        secondScreen.SetActive(true);

        // wait for the user to press the correct action option
        yield return new WaitUntil(() => chosenAction);

        // plays the remaining dialogue
        mainNameTag.SetActive(true);
        mainAnim.SetTrigger("talking");
        source.PlayOneShot(dialogue7,1);            //main character
        yield return new WaitForSeconds(6f);
        mainNameTag.SetActive(false);

        // talking mom animation + dialogue
        motherNameTag.SetActive(true);
        momAnim.SetTrigger("talking");
        source.PlayOneShot(dialogue8,1);            //mom
        yield return new WaitForSeconds(4f);
        motherNameTag.SetActive(false);

        //mom gives you a quarter animation
        quarter.SetActive(true);

        // character saying thanks
        mainNameTag.SetActive(true);
        source.PlayOneShot(dialogue9,1);
        mainAnim.SetTrigger("shortTalk");
        yield return new WaitForSeconds(5f);
        mainNameTag.SetActive(false);

        //you bring the quarter to the coin slot (rotate + movement)
        mainMove.shouldMoveToGumball = true;
        mainAnim.SetBool("Walk", true);
        yield return new WaitUntil(() => mainMove.finishedMoveToGumball);
        mainAnim.SetBool("Walk", false);

        // quarter appears and moves to the coin slot
        yield return new WaitForSeconds(1f);
        quarter.SetActive(false);
        quarterWithAnimation.SetActive(true);
        yield return new WaitForSeconds(3f);

        //gumball drop animation plays
        gumball.SetActive(true);
        Invoke("playGumBallNoise", 0.5f);
        yield return new WaitForSeconds(7f);

        //you get a gumball (main character dialogue)
        source.PlayOneShot(dialogue9_1,1);
        gumball.SetActive(false);
        yield return new WaitForSeconds(5f);

        //summary of what happened
        source.PlayOneShot(dialogue10,1);
        yield return new WaitForSeconds(19f);

        //end (fade)
        fade.SetActive(true);
        yield return new WaitForSeconds(3f);
        sceneController.Randomize();

    }

    public void setChosenEmotion(bool option){
        chosenEmotion = option;
    }

    public void setChosenAction(bool option){
        chosenAction = option;
    }
    public void playGumBallNoise(){
        source.PlayOneShot(gameBallDropNoise,1);            
    }
}


