using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBox : MonoBehaviour
{

    
    public TMP_Text objective;
    public TMP_Text objectiveText;
    // Start is called before the first frame update
    void Start()
    {
        objective.text = "Your mom has asked you";
        objectiveText.text = "to talk to the hostess";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
