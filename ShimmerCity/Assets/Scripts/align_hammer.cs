using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class align_hammer : MonoBehaviour {
	public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "deerbug") {
			col.collider.SendMessage ("decreaseHp");
		}
	}
}
