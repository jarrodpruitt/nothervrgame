using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tray : MonoBehaviour
{
    public bool shouldMove = false;
    private float speed = 0.015f;

    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // if(shouldMove && pos.x < 7f){
        //     pos.x += speed;
        //     transform.position = pos;
        // }
    }
}
