using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class align_hammer2 : MonoBehaviour {

	public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "deerbug") {
			col.collider.SendMessage ("decreaseHp");
		}
		if (col.collider.tag == "Deerbug_long") {
			col.collider.SendMessage ("decreaseHp");
		}
		if (col.collider.tag == "Start_mouse") {
			col.collider.SendMessage ("decreaseHp");
		}
	}
}
