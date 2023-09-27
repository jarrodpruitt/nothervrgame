using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mother : MonoBehaviour
{
    Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        // myAnimator.SetTrigger("talking");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
