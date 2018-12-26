using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AItips : MonoBehaviour {
    int count = 0;

    void receiveMsg() {
        count += 1;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("count"+"sdahjh"+count);
	}

}
