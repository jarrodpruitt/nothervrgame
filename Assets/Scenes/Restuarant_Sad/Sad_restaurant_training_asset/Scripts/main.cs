using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    // name tags
    public GameObject main_nameTag;
    public GameObject mother_nameTag;
    public GameObject brother_nameTag;
    public GameObject Waitress_nameTag;


    // universal stuff
    public AudioSource source;
    public AudioClip waitress_dialogue_1;
    public AudioClip main_dialogue_2;
    public AudioClip mother_dialogue_3;
    public AudioClip waitress_dialogue_4;
    public AudioClip waitress_dialogue_5;
    public AudioClip main_dialogue_6;
    public AudioClip main_dialogue_6_2;
    public AudioClip main_dialogue_7;
    public AudioClip mom_dialogue_8;
    public AudioClip brother_dialogue_9;

    // main char stuff
    public GameObject main_char;
    private Animator main_charAnim;

    // mother stuff
    public GameObject mother;
    private Animator motherAnim;


    // brother stuff
    public GameObject brother;
    private Animator brotherAnim;
    public GameObject brotherCar;


    // waitress stuff
    public waitress waitressScript;
    public GameObject waitress;
    private Animator waitressAnim;
    private float walkSpeed = 0.03f;

    // menu stuff
    public GameObject menu;


    // other stuff
    public GameObject redTray;
    public GameObject blueTray;
    public GameObject purpleTray;

    public GameObject redCar;
    public GameObject blueCar;
    public GameObject purpleCar;


    public localStorage storage;

    public SceneLoad sceneController;
    public GameObject fade;

    private bool hasStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        waitressAnim = waitress.GetComponent<Animator>();
        main_charAnim = main_char.GetComponent<Animator>();
        motherAnim = mother.GetComponent<Animator>();
        brotherAnim = brother.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted){
            StartCoroutine(startEvent());
            hasStarted = true;
        }
    }

    private IEnumerator startEvent(){
        // waiter walks forward (already playing walking animation)
        // move the waitress to the table
        waitressScript.shouldMoveToTable = true;
        yield return new WaitUntil(() => waitressScript.finishedMoveToTable);

        // stops walking animation
        waitressAnim.SetBool("Walk", false);

        // waits 2 seconds before talking
        yield return new WaitForSeconds(1.5f);

        // start talking animation and dialogue
        Waitress_nameTag.SetActive(true);
        waitressAnim.SetTrigger("welcoming");
        source.PlayOneShot(waitress_dialogue_1,1);            //main character
        yield return new WaitForSeconds(5f);
        Waitress_nameTag.SetActive(false);

        // menu appears
        menu.SetActive(true);
        // wait for menu option
        yield return new WaitUntil(() => storage.getChoice() != -1);

        //main character talks + animation
        main_nameTag.SetActive(true);
        main_charAnim.SetTrigger("shortTalk");
        yield return new WaitForSeconds(0.5f);
        source.PlayOneShot(main_dialogue_2,1);            //main character
        yield return new WaitForSeconds(4f);
        main_nameTag.SetActive(false);

        //mom talks + animation
        mother_nameTag.SetActive(true);
        source.PlayOneShot(mother_dialogue_3, 1);
        motherAnim.SetTrigger("talking");
        yield return new WaitForSeconds(5f);
        mother_nameTag.SetActive(false);

        // waiter then talks + animation
        Waitress_nameTag.SetActive(true);
        source.PlayOneShot(waitress_dialogue_4, 1);
        waitressAnim.SetTrigger("talking");
        yield return new WaitForSeconds(5f);
        Waitress_nameTag.SetActive(false);

        // waiter then moves back to the restauarant to grab food and comes back
        waitressScript.shouldBackToKitchen = true;
        waitressAnim.SetBool("Walk", true);
        yield return new WaitUntil(() => waitressScript.finishedBackToKitchenAndBack);
        waitressAnim.SetBool("Walk", false);
        yield return new WaitForSeconds(1f);

        // once the waitress is back, make the meal appear with toy (should play animation) + waitress talking
        Waitress_nameTag.SetActive(true);
        waitressAnim.SetTrigger("talking");
        source.PlayOneShot(waitress_dialogue_5, 1);
        moveTray(storage.getChoice());
        yield return new WaitForSeconds(5f);
        Waitress_nameTag.SetActive(false);

        // character will interact with the toy and the toy will break
        yield return new WaitUntil(() => storage.interactedWithToy);
        main_nameTag.SetActive(true);
        source.PlayOneShot(main_dialogue_6,1);            //main character
        yield return new WaitForSeconds(5f);
        source.PlayOneShot(main_dialogue_6_2,1);            //main character
        yield return new WaitForSeconds(2f);

        // play crying animation
        source.PlayOneShot(main_dialogue_7,1);            //main character
        main_charAnim.SetTrigger("crying");
        yield return new WaitForSeconds(5f);
        main_nameTag.SetActive(false);


        // mother comforts
        main_nameTag.SetActive(true);
        motherAnim.SetTrigger("talking");
        source.PlayOneShot(mom_dialogue_8,1);            //main character
        yield return new WaitForSeconds(7f);
        main_nameTag.SetActive(false);


        // brother also comforts
        brother_nameTag.SetActive(true);
        brotherAnim.SetTrigger("talking");
        source.PlayOneShot(brother_dialogue_9,1);            //main character
        yield return new WaitForSeconds(6f);
        brother_nameTag.SetActive(false);

        // brother gives toy
        brotherCar.SetActive(true);

        yield return new WaitForSeconds(5f);
        fade.SetActive(true);
        yield return new WaitForSeconds(3f);
        sceneController.Randomize();
    }

    private void moveTray(int choice){
        if(choice == 1)
            redTray.SetActive(true);
        else if(choice == 2)
            blueTray.SetActive(true);
        else
            purpleTray.SetActive(true);
    }

    private void playToyCrash(int choice){
        if(choice == 1)
            redCar.SetActive(true);
        else if(choice == 2)
            blueCar.SetActive(true);
        else
            purpleCar.SetActive(true);
    }
}
