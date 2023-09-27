using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScriptTesting : MonoBehaviour
{
    public AudioSource source;
    public AudioClip dialogue1;

    [SerializeField]
    SceneLoad sceneController;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(dialogue());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator dialogue(){
        source.PlayOneShot(dialogue1,1); 
        yield return new WaitForSeconds(dialogue1.length);
        StartCoroutine(Randomize());
    }

    IEnumerator Randomize()
    {
        yield return new WaitForSeconds(1);
        sceneController.Randomize();
    }
}
