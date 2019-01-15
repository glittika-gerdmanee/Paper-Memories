using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Fungus;

public class activateCutscene : MonoBehaviour {

    public PlayableDirector timeline;
    public CharacterController player;
    public new BoxCollider gameObject;
    public float countdown;

    // Use this for initialization
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
        gameObject = GetComponent<BoxCollider>();
        player = FindObjectOfType<CharacterController>();
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timeline.Play();
            Destroy(gameObject);
            StartCoroutine(toggleMove());
        }
    }

    private IEnumerator toggleMove()
    {
        player.enabled = false;
        yield return new WaitForSeconds(countdown);
        player.enabled = true;
    }
}
