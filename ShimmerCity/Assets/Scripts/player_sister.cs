using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_sister : MonoBehaviour {
	public void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player" ) {
			//Debug.Log ("get the sister!");
			col.SendMessage ("SetSister",true);
			Destroy(this.gameObject);
		}
	}

}

