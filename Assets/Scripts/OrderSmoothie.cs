using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderSmoothie : MonoBehaviour
{

    public AudioSource main_char_talking;
    public AudioSource main_char_talking2;

    public AudioSource mom_talking3;
    public AudioSource waitress_talking4;
    public GameObject menu;
    public SceneLoad sceneController;
  //  public GameObject RedB;
    //public GameObject GreenB;
    public GameObject mother;
    public GameObject waitress;
    Animator momAnimation;
    Animator waitressAnimation;
    Animator youAnimation;
    public GameObject You;






    public void ButtonClicked(){
        waitressAnimation = waitress.GetComponent<Animator>();
         waitressAnimation.SetTrigger("talking1");
        // waitress_talking4.PlayDelayed(3f);
        waitress_talking4.Play();
     
        Invoke("removeMenu", 2.5f);
        Invoke("waitressTalking4", 6f);



        // the tray then appears 
        Invoke("Talking2", 12f);
        // Invoke("momTalking2", 10f);
        Invoke("LoadNext", 15f);
     

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
          main_char_talking.Play();
    }




     private void momTalking2(){
        momAnimation = mother.GetComponent<Animator>();
        momAnimation.SetTrigger("talking");
        // mom_talking3.PlayDelayed(3f);
        mom_talking3.Play();
    }


    private void Talking2(){
      waitressAnimation.SetTrigger("talking1");
        main_char_talking2.Play();
    }




    private void LoadNext()
    {
        sceneController.LoadNextScene();
    }



}
