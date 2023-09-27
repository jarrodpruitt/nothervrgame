using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitress : MonoBehaviour
{
    public bool shouldMoveToTable = false;
    public bool finishedMoveToTable = false;

    public bool shouldBackToKitchen = false;
    public bool shouldLastRotate = false;
    private bool shouldMoveBackFromKitchen = false;
    public bool finishedBackToKitchenAndBack = false;
    private Vector3 position;
    private float speed = 0.04f;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldMoveToTable){      //if it true, start movement
            moveToTable();
        }
        if(shouldBackToKitchen){
            moveBackToKitchen();
        }
        if(shouldMoveBackFromKitchen){
            moveBackFromKitchen();
        }
        if(shouldLastRotate){
            lastRotate();
        }

    }

    private void moveToTable(){
        // moving next to table
        if(position.z > 9.5f){
            position.z -= speed;
            transform.position = position;
            return;
        }

        // rotating to face table
        if(transform.rotation.y < -0.71){
            transform.Rotate(new Vector3(0,-3f,0));
            return;
        }

        // move toward the table
        if(position.x < 3.15f){
            position.x += speed;
            transform.position = position;
            return;
        }
        finishedMoveToTable = true;
        shouldMoveToTable = false;

        //print(position);
        // print(transform.rotation);
    }

    private void moveBackToKitchen(){
        if(transform.rotation.y < 0.001){
            transform.Rotate(new Vector3(0,-3f,0));
            return;
        }
        if(position.z < 14.5f){
            position.z += speed;
            transform.position = position;
            return;
        }
        shouldBackToKitchen = false;
        shouldMoveBackFromKitchen = true;
    }

    private void moveBackFromKitchen(){
        if(transform.rotation.y < 0.99f){
            transform.Rotate(new Vector3(0,-3f,0));
            return;
        }
        if(position.z > 9.5f){
            position.z -= speed;
            transform.position = position;
            return;
        }
        shouldMoveBackFromKitchen = false;
        shouldLastRotate = true;
    }

    private void lastRotate(){
        if(transform.rotation.y > 0.71){
            transform.Rotate(new Vector3(0,-3f,0));
            return;
        }    
        shouldLastRotate = false;
        finishedBackToKitchenAndBack = true;
    }
}
