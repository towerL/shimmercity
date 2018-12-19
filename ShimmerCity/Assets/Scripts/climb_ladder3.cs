using System.Collections.Generic;
using UnityEngine;

public class climb_ladder3 : MonoBehaviour {
	public Collider2D target;
	public Transform ladder_transition;
	private Transform player_boxcollider;
	private Vector2 velocity;
	public float climbspeed = 2.0f;
	private bool climb=false;
	private bool pushable;

	void Start(){
		player_boxcollider=GameObject.FindGameObjectWithTag("Player").transform;
		pushable = false;
	}

	private void OnTriggerStay2D(Collider2D col){
		if (col.tag == "Player" && !climb) {
			climb = (Mathf.Abs (col.GetComponent<Rigidbody2D> ().velocity.x) < 0.01f ? true : false) && (Mathf.Abs (col.GetComponent<Rigidbody2D> ().velocity.y) < 0.01f ? true : false);
		}
		if (col.tag == "Player" && climb) {
			if (Input.GetKey (KeyCode.W)) {
				Vector3 posplayer = player_boxcollider.position;
				posplayer.x = ladder_transition.position.x;
				player_boxcollider.position = posplayer;
				col.GetComponent<Rigidbody2D> ().gravityScale = 0;
				velocity.x = col.GetComponent<Rigidbody2D> ().velocity.x;
				velocity.y = climbspeed;
				col.GetComponent<Rigidbody2D> ().velocity=velocity;
				Physics2D.IgnoreCollision (col.GetComponent<Collider2D>(),target);
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Hands").GetComponent<Collider2D> (), target);
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), target);
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("hammer_in_attack").GetComponent<Collider2D> (), target);
				col.SendMessage ("SetInLadder",true);
				target.SendMessage ("SetLayerOrder",true);
			} else if (Input.GetKey (KeyCode.S)) {
				Vector3 posplayer = player_boxcollider.position;
				posplayer.x = ladder_transition.position.x;
				player_boxcollider.position = posplayer;
				col.GetComponent<Rigidbody2D> ().gravityScale = 0;
				velocity.x = col.GetComponent<Rigidbody2D> ().velocity.x;
				velocity.y = -climbspeed;
				col.GetComponent<Rigidbody2D> ().velocity=velocity;
				Physics2D.IgnoreCollision (col.GetComponent<Collider2D>(),target);
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Hands").GetComponent<Collider2D> (), target);
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), target);
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("hammer_in_attack").GetComponent<Collider2D> (), target);
				col.SendMessage ("SetInLadder",true);
				target.SendMessage ("SetLayerOrder",true);
			} else if(Input.GetKey(KeyCode.Space)){
				Vector3 posplayer = player_boxcollider.position;
				posplayer.x = ladder_transition.position.x;
				player_boxcollider.position = posplayer;
				col.GetComponent<Rigidbody2D> ().gravityScale = 10;
				col.SendMessage ("SetInLadder",false);
				target.SendMessage ("SetLayerOrder",false);
				Physics2D.IgnoreCollision (col.GetComponent<Collider2D>(),target,false);
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Hands").GetComponent<Collider2D> (), target,false);
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), target,false);
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("hammer_in_attack").GetComponent<Collider2D> (), target,false);
			} 
		}
	}

	private void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Player") {
			col.GetComponent<Rigidbody2D> ().gravityScale = 30;
			climb = false;
			Physics2D.IgnoreCollision (col.GetComponent<Collider2D>(),target,false);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Hands").GetComponent<Collider2D> (), target,false);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), target,false);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("hammer_in_attack").GetComponent<Collider2D> (), target,false);
			col.SendMessage ("SetInLadder",false);
		}
	}

	void SetPushable(bool flag){
		pushable = flag;
		Debug.Log ("get the boss message");
	}
}
