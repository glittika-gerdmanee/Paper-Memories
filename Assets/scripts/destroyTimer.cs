using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyTimer : MonoBehaviour {

    public float countdown;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, countdown);
	}

}
