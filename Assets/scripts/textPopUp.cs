using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class textPopUp : MonoBehaviour {

    [SerializeField] private Text customText;
    [SerializeField] private GameObject trigger;

	// Use this for initialization
	void OnTriggerEnter (Collider other) {
		
        if (other.CompareTag("Player"))
        {
            customText.enabled = true;
        }
	}

    void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            customText.enabled = false;
            
        }
    }
}
