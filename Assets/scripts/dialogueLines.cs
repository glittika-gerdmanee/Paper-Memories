using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueLines : MonoBehaviour
{
    //array of strings for Instructions panel
    [TextArea(3,5)]
    public string[] texts = new string[1];

    //current position in string array
    public int textPos = 0;

    //String currently displayed in Text
    public Text currentText = null;


    public void Start()
    {

    }

    public void continueDialogue()
    {
        if (textPos + 1 < texts.Length)
        {
            ++textPos;
        }
    }

    public void resetConvo()
    {
        if (textPos >= 1)
        {
            textPos = 0;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown("E")){
        currentText.text = texts[textPos];
        }
    }
}
