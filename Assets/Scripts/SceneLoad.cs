using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public int scene;
    public bool trainingStart;
    void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(scene + 1);
    }
    public void LoadScene(int _scene)
    {
        SceneManager.LoadScene(_scene);
    }
    public void Randomize()
    {
        if(trainingStart){
            Debug.LogWarning("Playing PreTraining Scene");
            LoadScene(1);
            trainingStart = false;
        }else{
            string currentEmotion = SceneRandomizer.Instance.emotionBeingPlayed;
            if (SceneRandomizer.Instance.testingOver == true && SceneRandomizer.Instance.sceneChoices.Count == 0){
                Debug.LogWarning("Ending Testing ... Returning to Menu");
                LoadScene(0);
            } else if (SceneRandomizer.Instance.sceneChoices.Count == 0){
                Debug.LogWarning("Loading Testing Scene");
                switch (currentEmotion) {
                    case "Frustration":
                        SceneRandomizer.Instance.sceneChoices = new List<int> { 12 };
                        break;
                    case "Anger":
                        SceneRandomizer.Instance.sceneChoices = new List<int> { 10 };
                        break;
                    case "Sadness":
                        SceneRandomizer.Instance.sceneChoices = new List<int> { 9 };
                        break;
                    case "Overjoy":
                        SceneRandomizer.Instance.sceneChoices = new List<int> { 13 };
                        break;
                    case "Anxiety":
                        SceneRandomizer.Instance.sceneChoices = new List<int> {  };
                        break;
                }
                SceneRandomizer.Instance.testingOver = true;
                Debug.LogWarning("Playing PreTesting Scene");
                LoadScene(8);
            }  else {
                Debug.LogWarning("Playing Training/Testing Scene");
                int randScene = Random.Range(0, SceneRandomizer.Instance.sceneChoices.Count - 1);
                LoadScene(SceneRandomizer.Instance.sceneChoices[randScene]);
                SceneRandomizer.Instance.sceneChoices.RemoveAt(randScene);
            }
        }

        
    }
}