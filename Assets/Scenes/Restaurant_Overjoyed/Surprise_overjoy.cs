using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Surprise_overjoy : MonoBehaviour
{

    [SerializeField]
    SceneLoad sceneController;
    public Cake_overjoy Cake;
    public GameObject tray_obj;
    public AudioSource main_char_talking;
    public AudioSource main_char_talking2;

    public AudioSource mom_talking3;
    public AudioSource waitress_talking4;
    public GameObject menu;
    public GameObject mother;
    public GameObject waitress;
public WaitressMoveTo_overjoy myWaitress;
    Animator momAnimation;
    Animator waitressAnimation;
    Animator youAnimation;
        public GameObject You;
    public GameObject fade;
    private Animator FadeAnimator;



    public void ButtonClicked(){
        waitressAnimation = waitress.GetComponent<Animator>();
        main_char_talking.Play();
        Invoke("removeMenu", 2.5f);
        Invoke("waitressTalking4", 6f);

        // move the waitress back into the restauarant
        Invoke("moveBackToRestaurant", 4f);

        // the waitress comes back


        // the tray then appears 
        Invoke("moveTray", 6f);
        Invoke("Talking2", 7f);
        Invoke("momTalking2", 10f);
     

        Invoke("fadeOut", 15);
        Invoke("Randomize", 17);
    }

    private void moveBackToRestaurant(){


        youAnimation = You.GetComponent<Animator>();
        youAnimation.SetTrigger("jump");
        waitressAnimation.SetBool("Walk", true);
        myWaitress.shouldDoFirstMovement = false;
        myWaitress.shouldWalkToBackRestauarant = true;
    }

    private void removeMenu(){
        menu.SetActive(false);
    }

    private void moveTray(){
        tray_obj.SetActive(true);
        Cake.shouldMove = true;
    }

    private void momTalking(){
        momAnimation = mother.GetComponent<Animator>();
        momAnimation.SetTrigger("talking");
        // mom_talking3.PlayDelayed(3f);
        mom_talking3.Play();
    }

    private void waitressTalking4(){
        waitressAnimation.SetTrigger("talking1");
        // waitress_talking4.PlayDelayed(3f);
        waitress_talking4.Play();
    }




     private void momTalking2(){
        momAnimation = mother.GetComponent<Animator>();
        momAnimation.SetTrigger("talking");
        // mom_talking3.PlayDelayed(3f);
        mom_talking3.Play();
    }


    private void Talking2(){
      
        main_char_talking2.Play();
    }

            
     void fadeOut(){
        fade.SetActive(true);
    }
    void Randomize()
    {
        sceneController.Randomize();
    }




}
