using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mom : MonoBehaviour
{
    [SerializeField] MomSpeaker speaker;
    Animator myAnimator;
    int scene;
    
    void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        myAnimator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        if (scene == 1 || scene == 8)
        {
            speaker.Play();
        }
    }
}
