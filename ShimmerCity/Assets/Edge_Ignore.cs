using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge_Ignore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag != "Player")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider.GetComponent<Collider2D>());
        }
    }
}
