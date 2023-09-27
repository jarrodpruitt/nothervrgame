using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractOnPress : MonoBehaviour
{
    public TMP_Text dialogue;
    public GameObject dialogueShade;
    public GameObject clock;
    public GameObject button;
    public GameObject HowDoYouFeel;
    public GameObject sliderCanvas;
    public Slider slider;
    public GameObject Mom;
    public GameObject Brother;
    
    private Animator animBrother;

    private Animator animMom;
    public AudioSource audioSource;
    public AudioClip ambientsound;
    public AudioClip letswait;
    public AudioClip tantrum;
    public AudioClip hostess1;
    public AudioClip hostess2;
    public AudioClip hostess3;
    public AudioClip hostess4;
    public AudioClip hostess5;
    public AudioClip console1;
    public AudioClip console2;
    public AudioClip console3;
    public AudioClip scale;
    public AudioClip finale1;
    public AudioClip finale2;
    public AudioClip finale3;

    float moveSpeed;
    bool buttonPressed = false;
    bool brotherfall = false;
    bool brotherwalk = false;
    // Start is called before the first frame update
    void Start(){
        // Play background audio and make it loop
        audioSource.clip = ambientsound;
        audioSource.loop = true;
        audioSource.Play();
        audioSource.volume = 0.2f;
        // Grab the animation controller and respective animations for each character
        animBrother = Brother.GetComponent<Animator>();
        animMom = Mom.GetComponent<Animator>();
        // Set prefabs to be active/inactive
        clock.SetActive(false);
        dialogueShade.SetActive(false);
        HowDoYouFeel.SetActive(false);
        button.SetActive(true);
        sliderCanvas.SetActive(false);
        // Set default value of dialogue to "" so that it shows nothing
        dialogue.text = "";
        // Movement/walking/running speed of characters
        moveSpeed = 1f;
    }
    // When interact button is pressed, start time based code
    public void ButtonPress(){
        StartCoroutine(speech());
        buttonPressed = true;
    }

    public void Update(){
        // If interact button has been pressed, have both little brother and mother move towards waiter
        if (buttonPressed){
            Mom.transform.position += transform.forward * moveSpeed * Time.deltaTime;
            Brother.transform.position += transform.forward * (moveSpeed + .05f) * Time.deltaTime;
            animBrother.Play("Male_run");
            animMom.Play("Female_walk");
            if(Mom.transform.position.x >= -20.5){
                buttonPressed = false;
            }
        }else if(brotherwalk){
            Brother.transform.position += transform.right * (.5f) * Time.deltaTime;
            animBrother.Play("Male_walk");
        }else if(brotherfall){  // Play "tantrum" animation
                animBrother.Play("roll");
        }
        else{                   // Otherwise, all characters are on idle animation
            animBrother.Play("Male_idle");
            animMom.Play("Female_idle");
        }
    }

    IEnumerator speech(){
        // When button is pressed, move button off screen so that it cannot be pressed again
        Vector3 pos = button.transform.position;
        pos.y += 1000f;
        button.transform.position = pos;
        // Rotate little brother and mother to face towards direction of waiter
        Brother.transform.Rotate(0f, -90f, 0f, Space.Self);
        Mom.transform.Rotate(0f, 90f, 0f, Space.Self);
        // Display dialogue text
        dialogueShade.SetActive(true);
        dialogue.text = "Hello! Welcome! May I have the name to your reservation?";
        audioSource.PlayOneShot(hostess1, 5f);
        yield return new WaitForSeconds(7);

        dialogue.text = "I do not see your name on the list of reservations...";
        audioSource.PlayOneShot(hostess2, 5f);
        yield return new WaitForSeconds(3);

        dialogue.text = "You will need to sign up for another time slot";
        audioSource.PlayOneShot(hostess3, 5f);
        yield return new WaitForSeconds(3);

        dialogue.text = "The next available time will be in 30 minutes";
        audioSource.PlayOneShot(hostess4, 5f);
        yield return new WaitForSeconds(3);

        dialogue.text = "Please wait until then";
        audioSource.PlayOneShot(hostess5, 5f);
        yield return new WaitForSeconds(3);

        // Hide dialogue text
        dialogue.text = "";
        // Begin mom comfort mode
        Mom.transform.Rotate(0f, -45f, 0f, Space.Self);
        clock.SetActive(true);
        dialogueShade.SetActive(false);
        audioSource.PlayOneShot(letswait, 5f);

        yield return new WaitForSeconds(4);
        // Brother tantrum
        brotherfall = true;
        Brother.transform.position += transform.up * (.2f);
        Brother.transform.Rotate(-90f, 0f, 0f, Space.Self);
        yield return new WaitForSeconds(1);

        audioSource.PlayOneShot(tantrum, 5f);

        yield return new WaitForSeconds(3);
        // Mother comfort dalogue
        Brother.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        Brother.transform.position += transform.up * (-.2f);
        brotherfall = false;
        audioSource.PlayOneShot(console1, 5f);

        yield return new WaitForSeconds(4);

        audioSource.PlayOneShot(console2, 5f);
        yield return new WaitForSeconds(2);

        audioSource.PlayOneShot(console3, 5f);

        yield return new WaitForSeconds(4);

        audioSource.PlayOneShot(scale, 5f);
        // Slider for feels
        sliderCanvas.SetActive(true);
        yield return new WaitForSeconds(10);
        float frusLevel = slider.value;
        sliderCanvas.SetActive(false);
        if(frusLevel > 5){  // Big Frustration
            audioSource.PlayOneShot(finale1, 5f);
            yield return new WaitForSeconds(8);
            brotherwalk = true;
        }else{              // Low Frustration
            audioSource.PlayOneShot(finale2, 5f);
            yield return new WaitForSeconds(4);
            audioSource.PlayOneShot(finale3, 5f);
            yield return new WaitForSeconds(4);
            brotherwalk = true;
        }
        yield return new WaitForSeconds(10);
        brotherwalk = false;
        HowDoYouFeel.SetActive(true);
        
    }

}
