using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharMovement : MonoBehaviour
{
    public bool shouldMoveToGumball = false;
    public bool finishedMoveToGumball = false;
    private Vector3 position;
    private float speed = 0.03f;
    
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // print(transform.rotation);
        if(shouldMoveToGumball){
            moveToGumball();
        }
    }

    private void moveToGumball(){   //if y > 0
        if(transform.rotation.y > 0){
            transform.Rotate(new Vector3(0, -3f, 0));
            return;
        }
        if(position.z < 2.6f){
            position.z += speed;
            transform.position = position;
            return;
        }
        shouldMoveToGumball = false;
        finishedMoveToGumball = true;
    }
}


        // if(position.z > 9.5f){
        //     position.z -= speed;
        //     transform.position = position;
        //     return;
        // }

        // // rotating to face table
        // if(transform.rotation.y < -0.71){
        //     transform.Rotate(new Vector3(0,-2.5f,0));
        //     return;
        // }