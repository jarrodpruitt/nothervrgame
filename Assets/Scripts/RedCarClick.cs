using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedCarClick : MonoBehaviour
{


    public AudioSource main_char_talking;
    public AudioSource mom_talking3;
    public AudioSource waitress_talking4;

    public GameObject menu;
    public GameObject mother;
    public GameObject waitress;

    

    Animator momAnimation;
    Animator waitressAnimation;

    public WaitressMove myWaitress;




    public void ButtonClicked(){
        main_char_talking.Play();
        Invoke("removeMenu", 2.5f);
        Invoke("momTalking", 3.5f);
        Invoke("waitressTalking4", 8f);

        // move the waitress back into the restauarant
        Invoke("moveBackToRestaurant", 14.5f);
    }

    private void moveBackToRestaurant(){
        waitressAnimation.SetBool("Walk", true);
        myWaitress.shouldDoFirstMovement = false;
        myWaitress.shouldWalkToBackRestauarant = true;

    }

    private void removeMenu(){
        menu.SetActive(false);
    }


    private void momTalking(){
        momAnimation = mother.GetComponent<Animator>();
        momAnimation.SetTrigger("talking");
        // mom_talking3.PlayDelayed(3f);
        mom_talking3.Play();
    }

    private void waitressTalking4(){
        waitressAnimation = waitress.GetComponent<Animator>();
        waitressAnimation.SetTrigger("talking1");
        // waitress_talking4.PlayDelayed(3f);
        waitress_talking4.Play();
    }




}
