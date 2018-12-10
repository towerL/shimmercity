using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet_handler2 : MonoBehaviour {
	public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "Ground" || col.collider.tag == "deerbug" || col.collider.tag == "Deerbug_long" || col.collider.tag == "Stone" ) {
			SendMessageUpwards ("SetGround", true);
		} else if (col.collider.tag == "Pipe") {
			SendMessageUpwards ("SetGround", true);
		}
	}
		
	public void OnCollisionExit2D(Collision2D col){
		if (col.collider.tag == "Ground" || col.collider.tag == "deerbug" || col.collider.tag == "Deerbug_long" || col.collider.tag == "Stone"  ) {
			SendMessageUpwards("SetGround",false);
		}else if (col.collider.tag == "Pipe") {
			SendMessageUpwards ("SetGround", false);
		}
	}
}
