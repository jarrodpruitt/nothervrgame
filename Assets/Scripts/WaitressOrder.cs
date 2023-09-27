using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitressOrder : MonoBehaviour
{


        public GameObject openMenu;

    public AudioSource mom_talking3;
      public AudioSource mom_talking;
    private Animator myAnimator;
    public GameObject waitress;
    Animator waitressAnimation;



    // Start is called before the first frame update
     // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        // myAnimator.SetTrigger("talking");
    }

    // Update is called once per frame
    void Update()
    {
        Talk();
    }
     private void Talk(){
    Invoke("youTalking", 2f);
    Invoke("momTalking", 6f);

    

    }
 
        private void waitTalking(){
        waitressAnimation = waitressAnimation.GetComponent<Animator>();
        waitressAnimation.SetTrigger("talking1");
        mom_talking3.Play();

    }


     private void youTalking(){
        
      mom_talking.Play();
        
        
    }

}
