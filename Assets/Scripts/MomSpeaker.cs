using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MomSpeaker : MonoBehaviour
{
    [SerializeField] GameObject voice;
    [SerializeField] Player child;
    [SerializeField] GameObject questionnaire;
    GameObject childGFX;
    AudioSource line;
    Animator myAnimation;

    bool spoke;
    bool qShowing;
    int scene;
    int lineNum;

    void Start()
    {
        lineNum = 0;
        spoke = false;
        qShowing = false;
        line = voice.GetComponent<AudioSource>();
        scene = SceneManager.GetActiveScene().buildIndex;
        questionnaire.SetActive(false);
        childGFX = child.transform.GetChild(1).gameObject;
        myAnimation = this.transform.parent.GetComponent<Animator>();
    }

    public void Play()
    {
        if (!spoke)
        {
            line.Play();
            myAnimation.SetTrigger("talking");
        }
        if ((scene == 3 && !qShowing) || (scene == 11 && !qShowing))
        {
            questionnaire.SetActive(true);
            qShowing = true;
        }
        spoke = true;
    }

    public void ChangeLine()
    {
        lineNum++;
        if (lineNum == 3)
            lineNum = 0;
        voice = transform.GetChild(lineNum).gameObject;
        line = voice.GetComponent<AudioSource>();
        spoke = false;
    }
}
