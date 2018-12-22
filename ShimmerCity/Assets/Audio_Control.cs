using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Control : MonoBehaviour {
    public static Audio_Control Intance;
    AudioSource aus;
    // Use this for initialization
    void Start () {
        Intance = this;
        aus = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
