using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dead_boss : MonoBehaviour {


    float e_timer = 1.2f;
    Animator e_an;
	// Use this for initialization
	void Start () {
        e_an = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (e_timer >= 0)
            e_timer = e_timer - Time.deltaTime;
        else
        {
            e_an.speed = 0;
        }
	}
}
