using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageScript : MonoBehaviour
{
    private int choice = -1;

    public int getChoice(){
        return choice;
    }

    public void makeRedChoice(){
        choice = 1;
    }
    public void makeBlueChoice(){
        choice = 2;
    }

    public void makePurpleChoice(){
        choice = 3;
    }
}
