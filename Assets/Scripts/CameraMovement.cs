using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
   {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
 
        Vector3 right = transform.right * h * Time.deltaTime;
        Vector3 forward = transform.forward * v * Time.deltaTime;
 
        transform.Translate(right + forward);
    }
}
