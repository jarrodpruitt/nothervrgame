using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneRandomizer : MonoBehaviour
{
    public static SceneRandomizer Instance;
    public string emotionBeingPlayed;
    public bool testingOver = false;
    [HideInInspector] public List<int> sceneChoices;
    int scene;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }


        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void EmotionSelector(string emotion) {
        emotionBeingPlayed = emotion;
        switch (emotion) {
            case "Frustration":
                sceneChoices = new List<int> { 6 };
                break;
            case "Anger":
                sceneChoices = new List<int> { 2 };
                break;
            case "Sadness":
                sceneChoices = new List<int> { 5 };
                break;
            case "Overjoy":
                sceneChoices = new List<int> { 7 };
                break;
            case "Anxiety":
                sceneChoices = new List<int> {  };
                break;
        }
    }
}
