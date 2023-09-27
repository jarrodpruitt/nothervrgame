using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBall : MonoBehaviour
{
    void Update()
    {
        this.transform.position += this.transform.forward * .005f;
    }
}
