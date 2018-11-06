using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climb_ladder : MonoBehaviour {

	public Collider2D target;
	private Vector2 velocity;
	public float climbspeed = 2.0f;
	private bool climb=false;

	private void OnTriggerStay2D(Collider2D col){
		climb=(Mathf.Abs(col.GetComponent<Rigidbody2D> ().velocity.x)<0.01f?true:false);
		if (col.tag == "Player" && climb) {
			if (Input.GetKey (KeyCode.W)) {
				Debug.Log ("climb up!");
				col.GetComponent<Rigidbody2D> ().gravityScale = 0;
				velocity.x = col.GetComponent<Rigidbody2D> ().velocity.x;
				velocity.y = climbspeed;
				col.GetComponent<Rigidbody2D> ().velocity=velocity;
				Physics2D.IgnoreCollision (col.GetComponent<Collider2D>(),target);
				col.SendMessage ("SetInLadder",true);
			} else if (Input.GetKey (KeyCode.S)) {
				Debug.Log ("climb down!");
				col.GetComponent<Rigidbody2D> ().gravityScale = 0;
				velocity.x = col.GetComponent<Rigidbody2D> ().velocity.x;
				velocity.y = -climbspeed;
				col.GetComponent<Rigidbody2D> ().velocity=velocity;
				Physics2D.IgnoreCollision (col.GetComponent<Collider2D>(),target,true);
				col.SendMessage ("SetInLadder",true);
			} else {
				//col.GetComponent<Rigidbody2D> ().gravityScale = 20;
				velocity.x = col.GetComponent<Rigidbody2D> ().velocity.x;
				velocity.y = 0;
				col.GetComponent<Rigidbody2D> ().velocity=velocity;
			}
		}
	}

	private void OnTriggerExit2D(Collider2D col){
		Debug.Log ("ladder exit!");
		if (col.tag == "Player") {
			Debug.Log ("ladder exit!");
			col.GetComponent<Rigidbody2D> ().gravityScale = 20;
			Physics2D.IgnoreCollision (col.GetComponent<Collider2D>(),target,false);
			col.SendMessage ("SetInLadder",false);
		}
	}

}
