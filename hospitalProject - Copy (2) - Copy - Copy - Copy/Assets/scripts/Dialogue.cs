using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Dialogue : MonoBehaviour {

    public GameObject textBox; //panel that holds the text on screen
    public Text customText; //text pop up if object is examined
    public TextAsset textFile; //separate file containing dialogue
    public string[] textLines; //array displaying each line of dialogue from textFile

    public int currentLine; //to indicate which line the dialogue is playing
    public int endLine; //to indicate when script will stop reading dialogue line

    public bool displayText; //enables/disables text visibility
    public bool nearTrigger; //detect if player is in trigger zone
    public CharacterController player;

    void Start() {

        player = FindObjectOfType<CharacterController>();

        if(textFile != null)
        {
            textLines = (textFile.text.Split('\n')); //wraps line to split where '\n' is found in text file
        }

        //ensures that dialogue ends at the correct number (line) in array
        if (endLine == 0)
        {
            endLine = textLines.Length - 1;
        }

        //activates textbox for dialogue
        if(displayText == true) {
            EnableTextBox();
        }
        else {
            DisableTextBox();
        }

    }

    //grants player access to dialogue by making displayText true
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Display text is true");
            displayText = true;
            nearTrigger = true;
        }
    }

    //prevents player from triggering dialogue anywhere outside of trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Display text is false");
            displayText = false;
            nearTrigger = false;
        }
    }

    void Update() {
        
        
        //If no conversation is shown, then dialogue line doesn't need to be updated
        if (!displayText) {
            return;
        }

        customText.text = textLines[currentLine]; //displays the text that is assigned to the number in currentLine from textLines

        //should allow dialogue to activate if displayText is true
        if (Input.GetKeyDown("space")) {
                Debug.Log("space key is pressed");
                EnableTextBox();
                currentLine += 1; //goes through next line
            }

            //when dialogue finishes it should allow player to move again and remove dialogue UI
            if (currentLine > endLine) {
                DisableTextBox();
            }
    }
    
    //display textbox, deactivates player movement
    public void EnableTextBox() {
        textBox.SetActive(true);
        player.enabled = false;
    }

    //hide textbox, allows player movement
    public void DisableTextBox() {
        textBox.SetActive(false);
        player.enabled = true;
    }
}
