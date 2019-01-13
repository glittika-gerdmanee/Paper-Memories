using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class cutToCamera : MonoBehaviour {

    public PlayableDirector timeline;
    public CharacterController player;
    public float countdown;

    // Use this for initialization
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timeline.Stop();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timeline.Play();
            player.enabled = !player.enabled;
            Destroy(gameObject, countdown);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
