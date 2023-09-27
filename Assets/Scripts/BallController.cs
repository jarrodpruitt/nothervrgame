using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] SceneLoad sceneController;
    [SerializeField] Player child;

    void Start()
    {
        ball.gameObject.SetActive(false);
        if (sceneController.scene == 10)
        {
            Invoke("SpawnBall", 15f);
        }
        else if (sceneController.scene == 11)
        {
            Invoke("SpawnBall", 0f);
        }
        if (sceneController.scene == 11)
        {
            child.VoiceFlag(4.5f);
        }
    }
    void SpawnBall()
    {
        ball.gameObject.SetActive(true);
    }
    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Ball")
        {
            sceneController.LoadNextScene();
        }
    }
}
