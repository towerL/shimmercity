using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 8);
	}
	
	// Update is called once per frame
	void Update () {
	  // Instantiate()
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(gameObject);
        }
        else
            return;
    }
}
