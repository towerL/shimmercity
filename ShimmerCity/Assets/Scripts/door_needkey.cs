using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_needkey : MonoBehaviour {
    bool isdead = false;
    bool isgeteyes = false;
    Renderer rd;
    // Use this for initialization
    void Start () {
        rd = this.GetComponent<Renderer>();
        rd.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(isdead&&!isgeteyes)
        {
            rd.enabled = true;
        }
        if(isdead&&isgeteyes)
        {
            rd.enabled = false;
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
