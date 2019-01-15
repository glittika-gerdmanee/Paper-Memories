using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorToggle : MonoBehaviour {

    private Animator _anim;
    public AudioSource doorSound;
    public bool nearTrigger;
    public bool doorClose = true;


	// Use this for initialization
	void Start () {
        _anim = GetComponent<Animator>();
        doorSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            nearTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            nearTrigger = false;
            _anim.SetBool("isOpen", false);
        }
    }

    // Update is called once per frame
    void Update () {
		
        if(nearTrigger == true)
        {
            if (Input.GetKeyDown("e"))
            {

                _anim.SetBool("isOpen", true);
                doorSound.Play();
            }
        }
	}
}
