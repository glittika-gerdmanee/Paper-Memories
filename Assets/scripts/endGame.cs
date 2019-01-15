using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour {

    public float countdown;

	// Use this for initialization
	void Start () {
            StartCoroutine(endTheGame());
	}
    private IEnumerator endTheGame()
    {
        yield return new WaitForSeconds(countdown);
        Application.Quit();
    }
}
