using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToyBehavior : MonoBehaviour
{
    [SerializeField]
    SceneLoad sceneController;
    public GameObject Fade;
    private Animator FadeAnimator;

    public GameObject mother;
    public GameObject brother;
    public GameObject brotherCar;

    Animator brotherAnimation;
    Animator momAnimation;

    public GameObject fade;

    // Start is called before the first frame update
    void Start()
    {
        FadeAnimator = Fade.GetComponent<Animator>();
    }


    public void onClick(){
        momAnimation = mother.GetComponent<Animator>();
        brotherAnimation = brother.GetComponent<Animator>();
        Invoke("momTalk8", 18f);
        Invoke("brotherTalk9", 25f);
        Invoke("newCarShow", 31);
        Invoke("fadeOut", 33);
        Invoke("Randomize", 35);
    }

    void momTalk8(){
        momAnimation.SetTrigger("talking");
    }

    void brotherTalk9(){
        brotherAnimation.SetTrigger("talking");
    }

    void newCarShow(){  
        brotherCar.SetActive(true);
    }

    void fadeOut(){
        fade.SetActive(true);
    }
    void Randomize()
    {
        sceneController.Randomize();
    }
}
