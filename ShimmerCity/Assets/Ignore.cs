using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player" || collision.collider.tag == "Feet")
        {
            Physics2D.IgnoreCollision(collision.collider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
