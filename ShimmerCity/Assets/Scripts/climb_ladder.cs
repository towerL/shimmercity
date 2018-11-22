using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climb_ladder : MonoBehaviour {

	public Collider2D target;
	public Transform ladder_transition;
	private Transform player_boxcollider;
	private Vector2 velocity;
	public float climbspeed = 2.0f;
	private bool climb=false;
	private float player_boxcollider_y;
	private float ladder_transition_y;
	private bool used_below;
	private bool now_below;
	private bool used_ground=true;

	void Start(){
		player_boxcollider=GameObject.FindGameObjectWithTag("Player").transform;
		//ladder_transition=GameObject.FindGameObjectWithTag("Ladder1_transition").transform;
		player_boxcollider_y=player_boxcollider.position.y;
		ladder_transition_y = ladder_transition.position.y;
		used_below=(player_boxcollider_y<ladder_transition_y?true:false);
		climb = false;
	}

	private void OnTriggerStay2D(Collider2D col){
		if (col.tag == "Player" && !climb) {
			climb = (Mathf.Abs (col.GetComponent<Rigidbody2D> ().velocity.x) < 0.01f ? true : false) && (Mathf.Abs (col.GetComponent<Rigidbody2D> ().velocity.y) < 0.01f ? true : false);
		}
		player_boxcollider_y = player_boxcollider.position.y;
		now_below = (player_boxcollider_y < ladder_transition_y ? true : false);
		if (col.tag == "Player" && climb) {
			if (Input.GetKey (KeyCode.W)) {
				//Debug.Log ("climb up!");
				col.GetComponent<Rigidbody2D> ().gravityScale = 0;
				velocity.x = col.GetComponent<Rigidbody2D> ().velocity.x;
				velocity.y = climbspeed;
				col.GetComponent<Rigidbody2D> ().velocity=velocity;
				Physics2D.IgnoreCollision (col.GetComponent<Collider2D>(),target);
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Hands").GetComponent<Collider2D> (), target);
				//Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Hands").GetComponent<Collider2D> (), this.GetComponent<Collider2D> ());
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), target);
				//Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), this.GetComponent<Collider2D> ());
				if(used_below && !now_below){
					Vector3 pos = player_boxcollider.position;
					pos.y += 1.4f;
					player_boxcollider.position = pos;
				}
				col.SendMessage ("SetInLadder",true);
			} else if (Input.GetKey (KeyCode.S)) {
				//Debug.Log ("climb down!");
				col.GetComponent<Rigidbody2D> ().gravityScale = 0;
				velocity.x = col.GetComponent<Rigidbody2D> ().velocity.x;
				velocity.y = -climbspeed;
				col.GetComponent<Rigidbody2D> ().velocity=velocity;
				Physics2D.IgnoreCollision (col.GetComponent<Collider2D>(),target);
				if(!used_below && (player_boxcollider_y>=ladder_transition_y+1.5f)){
					Vector3 pos = player_boxcollider.position;
					pos.y -= 1.4f;
					player_boxcollider.position = pos;
				}
				col.SendMessage ("SetInLadder",true);
			} else if(Input.GetKey(KeyCode.Space)){
				col.GetComponent<Rigidbody2D> ().gravityScale = 10;
				col.SendMessage ("SetInLadder",false);
			} /*else {
				col.GetComponent<Rigidbody2D> ().gravityScale = 0;
				velocity.x = col.GetComponent<Rigidbody2D> ().velocity.x/100;
				velocity.y = 0;
				col.GetComponent<Rigidbody2D> ().velocity=velocity;
			}*/
		}
		if(col.tag == "Player")
			used_below = now_below;
	}

	private void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Player") {
			//Debug.Log ("ladder exit!");
			col.GetComponent<Rigidbody2D> ().gravityScale = 30;
			climb = false;
			Physics2D.IgnoreCollision (col.GetComponent<Collider2D>(),target,false);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Hands").GetComponent<Collider2D> (), target,false);
			//Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Hands").GetComponent<Collider2D> (), this.GetComponent<Collider2D> (),false);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), target,false);
			//Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), this.GetComponent<Collider2D> (),false);
			col.SendMessage ("SetInLadder",false);
		}
	}
}
