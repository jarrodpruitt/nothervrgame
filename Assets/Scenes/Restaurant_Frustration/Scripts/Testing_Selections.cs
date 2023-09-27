using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing_Selections : MonoBehaviour
{
    [SerializeField]
    SceneLoad sceneController;

    public GameObject SelectionCanvas;
    public GameObject Fade;
    private Animator FadeAnimator;

    public AudioSource audioSource;
    public AudioClip Audio;
    public AudioClip lesson;
    int button_index = 0;
    // Start is called before the first frame update
    void Start()
    {
        FadeAnimator = Fade.GetComponent<Animator>();
    }

    public void ButtonPress(int value){
        button_index = value;
        StartCoroutine(finale());
    }

    IEnumerator finale(){
        if(button_index == 1 || button_index == 2){
            // When button is pressed, move button off screen so that it cannot be pressed again
            Vector3 pos = SelectionCanvas.transform.position;
            pos.y += 1000f;
            SelectionCanvas.transform.position = pos;

            audioSource.clip = Audio;
            audioSource.Play();
            yield return new WaitForSeconds(Audio.length);

            audioSource.clip = lesson;
            audioSource.Play();

            yield return new WaitForSeconds(lesson.length);


            FadeAnimator.Play("fadeout");
            StartCoroutine(Randomize());
        }else{
            // When button is pressed, move button off screen so that it cannot be pressed again
            Vector3 pos = SelectionCanvas.transform.position;
            pos.y += 1000f;

            SelectionCanvas.transform.position = pos;
            audioSource.clip = Audio;
            audioSource.Play();
            yield return new WaitForSeconds(Audio.length);
            pos.y -= 1000f;
            SelectionCanvas.transform.position = pos;
        }
    }
    IEnumerator Randomize()
    {
        yield return new WaitForSeconds(1);
        sceneController.Randomize();
    }
}
