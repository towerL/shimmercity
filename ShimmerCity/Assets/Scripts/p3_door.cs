using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p3_door : MonoBehaviour {

    Animator do_an;
    bool isdead = false;
    bool isgeteyes = false;
	// Use this for initialization
	void Start () {
        do_an = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!isdead)
        {
            do_an.SetBool("IsOpen", true);
        }
        else if(isdead&& !isgeteyes)
        {
            do_an.SetBool("IsOpen", false);
            do_an.SetBool("needkey", true);
        }
        else if(isdead&&isgeteyes)
        {
            do_an.SetBool("IsOpen", false);
            do_an.SetBool("needkey", false);
            do_an.SetBool("haskey", true);
        }

	}

    void bossdie()
    {
        isdead = true;
    }

    void getkey()
    {
        isgeteyes = true;
    }
}
