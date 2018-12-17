using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet_handler2 : MonoBehaviour {
	public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "Ground" || col.collider.tag == "deerbug" || col.collider.tag == "Deerbug_long" || col.collider.tag == "stone_stand" ) {
			SendMessageUpwards ("SetGround", true);
		} else if (col.collider.tag == "Pipe") {
			SendMessageUpwards ("SetGround", true);
			SendMessageUpwards ("SetPipe", true);
		}
	}

	public void OnCollisionStay2D(Collision2D col){
		if (col.collider.tag == "Ground" || col.collider.tag == "deerbug" || col.collider.tag == "Deerbug_long" || col.collider.tag == "stone_stand" ) {
			SendMessageUpwards ("SetGround", true);
		} else if (col.collider.tag == "Pipe") {
			SendMessageUpwards ("SetGround", true);
			SendMessageUpwards ("SetPipe", true);
		}
	}

		
	public void OnCollisionExit2D(Collision2D col){
		if (col.collider.tag == "Ground" || col.collider.tag == "deerbug" || col.collider.tag == "Deerbug_long" || col.collider.tag == "stone_stand"  ) {
			SendMessageUpwards("SetGround",false);
		}else if (col.collider.tag == "Pipe") {
			SendMessageUpwards("SetGround",false);
			SendMessageUpwards ("SetPipe", false);
		}
	}
}
