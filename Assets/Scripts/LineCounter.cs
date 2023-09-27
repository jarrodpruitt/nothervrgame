using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LineCounter : MonoBehaviour
{
    [SerializeField] GameObject DJ;
    [SerializeField] SceneLoad sceneController;

    private int count;
    private int scene;
    AudioSource blip;
    AudioSource end_noise;
    private bool celebrated;

    public GameObject Fade;
    private Animator FadeAnimator;

    void Start()
    {
        FadeAnimator = Fade.GetComponent<Animator>();
        scene = SceneManager.GetActiveScene().buildIndex;
        blip = GetComponent<AudioSource>();
        end_noise = DJ.GetComponent<AudioSource>();
        count = 0;
        celebrated = false;
    }

    void Update()
    {
        blip.pitch = count / 100f;
        if (scene == 2)
        {
            if (count >= 400)
                LoadNextScene();
        }
        if (scene == 4)
        {
            if (count >= 500 && !celebrated)
            {
                Finale();
            }

        }
    }

    public void IncrementCount()
    {
        blip.Play();
        count++;
    }

    public void LoadNextScene()
    {
        end_noise.Play();
        SceneManager.LoadScene(scene + 1);
    }

    public void Finale()
    {
        end_noise.Play();
        celebrated = true;
        StartCoroutine(finale());
    }

    IEnumerator finale()
    {
        yield return new WaitForSeconds(1);
        FadeAnimator.Play("fadeout");
        StartCoroutine(Randomize());
    }
    IEnumerator Randomize()
    {
        yield return new WaitForSeconds(1);
        sceneController.Randomize();
    }
}
