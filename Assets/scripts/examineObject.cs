using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class examineObject : MonoBehaviour
{

    [TextArea(3, 3)]
    public string[] itemDescription = new string[1]; //string input for object
    public GameObject dialogueBox = null; //panel that holds the text on screen
    public Text customText; //text pop up if object is examined
    public int textPos = 0; // current position in string array
    public Image customImage; //image pop up if necessary

    public bool displayText; //enables/disables text visibility
    public bool nearTrigger; //detect if player is in trigger zone
    public bool imgOn; //enables/disables image visibility
    public CharacterController player;
    public highlightObject highlight;

    void Start()
    {
        customText.enabled = false;
        displayText = false;
        nearTrigger = false;
        imgOn = true;

        player = FindObjectOfType<CharacterController>();
        highlight = GetComponent<highlightObject>();

        //activates textbox for dialogue
        if (displayText == true)
        {
            textboxToggle();
        }

    }

    //grants player access to dialogue by making displayText true
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Display text is true");
            displayText = true;
            nearTrigger = true;
            imgOn = true;
        }
    }

    //prevents player from triggering dialogue anywhere outside of trigger
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Display text is false");
            displayText = false;
            nearTrigger = false;
            imgOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //If no conversation is shown, then dialogue line doesn't need to be updated
        if (!displayText)
        {
            return;
        }
        

        //should allow dialogue to activate if displayText is true
        if (Input.GetKeyDown("e"))
        {
            Debug.Log("E key is pressed");
            customText.text = itemDescription[textPos];
            textToggle();
            textboxToggle();
            Debug.Log("Image is here!");
            imageToggle();

            if (highlight)
            {
                highlight.StopHighlight(); //disables from gameObject being highlight while examined
            }
        }
    }

    //toggles whether image displays or not
    public void imageToggle()
    {
        if (imgOn == true)
        {
        customImage.enabled = !customImage.enabled;
        }
    }

    //toggles whether text displays or not
    public void textToggle()
    {
        customText.enabled = !customText.enabled;

    }
    
    //toggles player movement and dialogue box
    public void textboxToggle()
    {
        dialogueBox.SetActive(true);
        player.enabled = !player.enabled;
    }


}
