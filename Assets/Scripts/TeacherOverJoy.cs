using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherOverjoy : MonoBehaviour
{


        public GameObject openMenu;

    //public AudioSource talking3;
     // public AudioSource talking;
    private Animator myAnimator;
    public GameObject teacher;
    Animator teacherAnimation;



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
  
    

    }
 
        private void TeacherTalking(){
        teacherAnimation = teacherAnimation.GetComponent<Animator>();
        teacherAnimation.SetTrigger("talking1");
        

    }


     private void youTalking(){
        
     
        
        
    }

}
