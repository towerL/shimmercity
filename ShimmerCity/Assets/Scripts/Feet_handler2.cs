using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet_handler2 : MonoBehaviour {
	public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "Ground" || col.collider.tag == "deerbug" || col.collider.tag == "Deerbug_long") {
			SendMessageUpwards ("SetGround", true);
		} else if (col.collider.tag == "Pipe") {
			SendMessageUpwards ("SetGround", true);
			SendMessageUpwards ("SetPipe", true);
		} else if (col.collider.tag == "stone_stand") {
			col.rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
			Debug.Log ("emmm");
			SendMessageUpwards ("SetStone", true);
			SendMessageUpwards ("SetGround", true);
		}
	}

	public void OnCollisionStay2D(Collision2D col){
		if (col.collider.tag == "Ground" || col.collider.tag == "deerbug" || col.collider.tag == "Deerbug_long") {
			SendMessageUpwards ("SetGround", true);
		} else if (col.collider.tag == "Pipe") {
			SendMessageUpwards ("SetGround", true);
			SendMessageUpwards ("SetPipe", true);
		} else if (col.collider.tag == "stone_stand") {
			col.rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
			SendMessageUpwards ("SetStone", true);
			SendMessageUpwards ("SetGround", true);
		}
	}

		
	public void OnCollisionExit2D(Collision2D col){
		if (col.collider.tag == "Ground" || col.collider.tag == "deerbug" || col.collider.tag == "Deerbug_long") {
			SendMessageUpwards("SetGround",false);
		}else if (col.collider.tag == "Pipe") {
			SendMessageUpwards("SetGround",false);
			SendMessageUpwards ("SetPipe", false);
		}else if (col.collider.tag == "stone_stand") {
			col.rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
			SendMessageUpwards ("SetStone", true);
			SendMessageUpwards("SetGround",false);
		}
	}
}
