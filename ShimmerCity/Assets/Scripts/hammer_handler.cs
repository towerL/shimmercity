using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammer_handler : MonoBehaviour {
	public void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			//Debug.Log ("get the hammer!");
			col.SendMessage ("SetIsHammer", true);
			Destroy (this.gameObject);
		}
	}
		
}
