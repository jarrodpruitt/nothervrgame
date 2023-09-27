using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    [SerializeField]
    SceneLoad sceneController;
    public GameObject Fade;
    private Animator FadeAnimator;

    public AudioSource audioSource;
    public AudioClip Audio;
    // Start is called before the first frame update
    void Start()
    {
        FadeAnimator = Fade.GetComponent<Animator>();
    }

    public void ButtonPress(){
        StartCoroutine(finale());
    }

    IEnumerator finale(){
        audioSource.clip = Audio;
        audioSource.Play();
        yield return new WaitForSeconds(Audio.length);
        FadeAnimator.Play("fadeout");
        StartCoroutine(Randomize());
    }
    IEnumerator Randomize()
    {
        yield return new WaitForSeconds(1);
        sceneController.Randomize();
    }
}
