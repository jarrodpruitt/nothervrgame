using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperMove : MonoBehaviour
{
    [SerializeField] GameObject paper;
    [SerializeField] GameObject soda;
    [SerializeField] GameObject spill;
    [SerializeField] Player child;

    int point;
    bool rotated;
    float moveSpeed;

    void Start()
    {
        spill.SetActive(false);
        rotated = false;
        point = 0;
        moveSpeed = 1f;
    }

    void Update()
    {
        if (point == 0)
        {
            this.transform.position += transform.forward * moveSpeed * Time.deltaTime;
            if (this.transform.position.z <= 9.3)
            {
                point = 1;
            }
        }
        if (point == 1)
        {
            if (!rotated)
            {
                this.transform.Rotate(0f, 100f, 0f, Space.Self);
                paper.transform.position = new Vector3(3f, 1.98f, 9.42f);
                paper.transform.Rotate(-66f, 18f, -16.41f, Space.Self);
                soda.transform.position = new Vector3(4.05f, 1.37f, 9.8f);
                soda.transform.Rotate(-90f, 12f, 0f);
                spill.SetActive(true);
                child.VoiceFlag(8f);
                rotated = true;
            }
            this.transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

    }
}
