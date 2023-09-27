using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenButtonPressed : MonoBehaviour
{

    public AudioSource main_char_talking;
    public AudioSource main_char_talking2;

    public AudioSource waitress_talking4;
    public GameObject menu;
    public GameObject menu1;

  //  public GameObject RedB;
    //public GameObject GreenB;
    public GameObject mother;
    public GameObject waitress;
    Animator momAnimation;
    Animator waitressAnimation;
    Animator youAnimation;
    public GameObject You;






    public void ButtonClicked(){
        
        
        
        waitress_talking4.Play();
     
        Invoke("removeMenu", 0f);
        Invoke("waitressTalking4", 8f);



        // the tray then appears 
        Invoke("Talking2", 2f);
       // Invoke("momTalking2", 10f);
     

    }



    private void removeMenu(){
        menu.SetActive(false);
        menu1.SetActive(false);
    }


/*
    private void momTalking(){
        momAnimation = mother.GetComponent<Animator>();
        momAnimation.SetTrigger("talking");
        // mom_talking3.PlayDelayed(3f);
        mom_talking3.Play();
    }
*/
    private void waitressTalking4(){
    //waitressAnimation.SetTrigger("talking1");

        main_char_talking.Play();
    }



/*
     private void momTalking2(){
        momAnimation = mother.GetComponent<Animator>();
        momAnimation.SetTrigger("talking");
        // mom_talking3.PlayDelayed(3f);
        mom_talking3.Play();
    }
*/

    private void Talking2(){
        main_char_talking2.Play();
    }

            





}
