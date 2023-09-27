using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceSegment : MonoBehaviour
{
    [SerializeField]
    LineCounter count;
    MeshRenderer skin;
    public bool colored;

    void Start()
    {
        skin = GetComponent<MeshRenderer>();
        skin.enabled = false;
        colored = false;
    }
    
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.layer == this.gameObject.layer)
            skin.enabled = true;
        if (colored == false)
        {
            count.IncrementCount();
        }
        colored = true;
    }
}
