using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitressMove : MonoBehaviour
{
    private bool walk = false;
    private float speed = 0.03f;

    public GameObject openMenu;

    public AudioSource firstDialogue;

    private Animator myAnimator;
    Vector3 pos;

    public StorageScript storageScript;
    // public Tray tray;
    public GameObject red_tray_obj;
    public GameObject blue_tray_obj;
    public GameObject purple_tray_obj;


    void Start()
    {   
        myAnimator = this.GetComponent<Animator>();
        walk = true;
        pos = transform.position;
    }

    void Update()
    {
        // print(Time.time);
        
        if(walk == false)
            return;
        
        mainMovement();
        walkToBackRestauarant();


    }
    public bool shouldDoFirstMovement = true;
    public bool shouldWalkToBackRestauarant = false;




    private bool doneRotate1 = false;
    private bool doneMovement1 = false;
    private bool doneRotate2 = false;
    private bool doneMovement2 = false;
    private bool doneRotate3 = false;


    public AudioSource waitress_talking5;

    public Animation fade;



    void walkToBackRestauarant(){
        if(shouldWalkToBackRestauarant == true){ // only when this is done, do we change boolean to false
            // rotate
            if (doneRotate1 == false){
                if(transform.rotation.y < 0f){
                    transform.Rotate(new Vector3(0,-3,0));
                }else{
                    doneRotate1 = true;
                }
            }

            // move
            if (doneMovement1 == false && doneRotate1 == true){
                if(pos.z < 14.5f){
                    pos.z += speed;
                    transform.position = pos;
                }else{
                    doneMovement1 = true;
                }
            }
            // rotate back

            if (!doneRotate2 && doneMovement1){
                if(transform.rotation.y < 0.999f){
                    transform.Rotate(new Vector3(0,-3,0));
                }else{
                    doneRotate2 = true;
                }
            }

            // move back
            if (!doneMovement2 && doneRotate2){
                if (pos.z > 9.5f){
                    pos.z -= speed;
                    transform.position = pos;
                }else{
                    doneMovement2 = true;
                }
            }

            if (!doneRotate3 && doneMovement2){                    
                if(transform.rotation.y > 0.75f){
                    transform.Rotate(new Vector3(0,-3,0));
                }else{
                    doneRotate3 = true;
                    //Then we're finally done
                    myAnimator.SetBool("Walk", false);

                    //Then the waitress hands them the tray
                    moveTray(storageScript.getChoice());

                    // Play dialogue audio
                    waitress_talking5.Play();
                }
            }

        }
    }


    private void moveTray(int choice){
        if(choice == 1)
            red_tray_obj.SetActive(true);
        else if(choice == 2)
            blue_tray_obj.SetActive(true);
        else
            purple_tray_obj.SetActive(true);
    }
























    // main movement will always call the last movement.
    void mainMovement(){
        if(shouldDoFirstMovement == true)
            secondMovement();
    }
 
    bool rotateMovement(){
        if(firstMovement() == false)
            return false;
        if(transform.rotation.y < -0.7f){
            transform.Rotate(new Vector3(0,-3,0));
            return false;
        }
        return true;
    }

    bool firstMovement(){
        if(pos.z > 9.5f){
            pos.z -= speed;
            transform.position = pos;
            return false;
        }
        return true;
    }


    private bool hasRan = false;
    private bool hasTalked1 = false;

    bool secondMovement(){
        // checks if previous movement is complete
        if(rotateMovement() == false){
            return false;
        }
        //checks if it has reached its destination
        if(pos.x < 3f){
            pos.x += speed;
            transform.position = pos;
            return false;
        }


        //otherwise this is complete, so return true
        if(hasRan == false){
            myAnimator.SetBool("Walk", false);
            Invoke("delayedMenu", 7f);
            hasRan = true;
        }
        
        if(hasTalked1 == false){

            Invoke("talk1", 2f);
            Invoke("stopTalkingAnimationPlay", 2.1f);
            hasTalked1 = true;
        }

        // Then, the menu should appear.
        return true;
    }

    void stopTalkingAnimationPlay(){
        myAnimator.SetBool("Talking", false);
    }

    void end(){
        walk = false;
    }

    void talk1(){
        myAnimator.SetBool("Talking", true);
        firstDialogue.Play();
    }


    void delayedMenu(){
        openMenu.SetActive(true);
    }
}



/*
* waitress is initally at -22.5, x, 0
* waitress will move to -22.5, x, -5.0
* then rotate
* then waitress will move to -20.5, x, -5.0
* stop
*/


