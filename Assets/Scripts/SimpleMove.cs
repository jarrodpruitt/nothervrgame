using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            transform.position += 5f * Vector3.forward * Time.deltaTime;
        }
    }
}
