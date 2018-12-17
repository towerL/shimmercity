using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignore_ground : MonoBehaviour {

	public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "Ground")
			GetComponent<Collider2D> ().isTrigger = true;
	}

	public void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Ground")
			GetComponent<Collider2D> ().isTrigger = false;
	}
		
}
