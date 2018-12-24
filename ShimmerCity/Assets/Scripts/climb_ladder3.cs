using System.Collections.Generic;
using UnityEngine;

public class climb_ladder3 : MonoBehaviour {
	public Collider2D target;
	public Transform ladder_transition;
	public Transform ladder_endpos;
	private Transform player_boxcollider;
	private Vector2 velocity;
	public float climbspeed = 2.0f;
	private bool climb=false;

	public float ladder_translate;
	private bool pushable;
	private Vector3 endpos;
	private bool inladder;

	private bool isGround=true;

	void Start(){
		player_boxcollider=GameObject.FindGameObjectWithTag("Player").transform;
		pushable = false;
		//pushable = true;
		inladder = false;
	}

	void FixedUpdate(){
		if (inladder && climb && !(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))) {
			Vector3 posplayer = player_boxcollider.position;
			posplayer.x = ladder_transition.position.x;
			player_boxcollider.position = posplayer;
		}
		if (pushable) {
			if (transform.position.x <= ladder_endpos.position.x) {
				endpos = transform.position;
				endpos.x += ladder_translate * Time.deltaTime;
				transform.position = endpos;
				if (inladder) {
					Vector3 posplayer = player_boxcollider.position;
					posplayer.x = transform.position.x;
					player_boxcollider.position = posplayer;
				}
			} else {
				Physics2D.IgnoreLayerCollision (9, 10,false);
				Physics2D.IgnoreLayerCollision (9, 11,false);
			}
		}
		if (inladder) {
			Physics2D.IgnoreLayerCollision (9, 10);
			Physics2D.IgnoreLayerCollision (9, 11);
			target.SendMessage ("SetLayerOrder", true);
		} else {
			Physics2D.IgnoreLayerCollision (9, 10,false);
			Physics2D.IgnoreLayerCollision (9, 11,false);
			target.SendMessage ("SetLayerOrder", false);
		}
	}

	void SetGround(bool flag){
		isGround = flag;
	}

	private void OnTriggerStay2D(Collider2D col){
		if (col.tag == "Player" && !climb) {
			climb = isGround && (Mathf.Abs (col.GetComponent<Rigidbody2D> ().velocity.x) < 0.01f ? true : false) && (Mathf.Abs (col.GetComponent<Rigidbody2D> ().velocity.y) < 0.01f ? true : false);
		}
		if (col.tag == "Player" && climb) {
			if (Input.GetKey (KeyCode.W)) {
				inladder = true;
				col.GetComponent<Rigidbody2D> ().gravityScale = 0;
				velocity.x = col.GetComponent<Rigidbody2D> ().velocity.x;
				velocity.y = climbspeed;
				col.GetComponent<Rigidbody2D> ().velocity=velocity;
				Physics2D.IgnoreCollision (col.GetComponent<Collider2D>(),target);
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Hands").GetComponent<Collider2D> (), target);
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), target);
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("hammer_in_attack").GetComponent<Collider2D> (), target);
				col.SendMessage ("SetInLadder",true);
			} else if (Input.GetKey (KeyCode.S)) {
				inladder = true;
				col.GetComponent<Rigidbody2D> ().gravityScale = 0;
				velocity.x = col.GetComponent<Rigidbody2D> ().velocity.x;
				velocity.y = -climbspeed;
				col.GetComponent<Rigidbody2D> ().velocity=velocity;
				Physics2D.IgnoreCollision (col.GetComponent<Collider2D>(),target);
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Hands").GetComponent<Collider2D> (), target);
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), target);
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("hammer_in_attack").GetComponent<Collider2D> (), target);
				col.SendMessage ("SetInLadder",true);
			} else if(Input.GetKey(KeyCode.Space)){
				inladder = false;
				col.GetComponent<Rigidbody2D> ().gravityScale = 30;
				col.SendMessage ("SetInLadder",false);
				climb = false;
				Physics2D.IgnoreCollision (col.GetComponent<Collider2D>(),target,false);
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Hands").GetComponent<Collider2D> (), target,false);
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), target,false);
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("hammer_in_attack").GetComponent<Collider2D> (), target,false);
			} 
		}
	}

	private void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Player") {
			inladder = false;
			col.GetComponent<Rigidbody2D> ().gravityScale = 30;
			climb = false;
			Physics2D.IgnoreCollision (col.GetComponent<Collider2D>(),target,false);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Hands").GetComponent<Collider2D> (), target,false);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), target,false);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("hammer_in_attack").GetComponent<Collider2D> (), target,false);
			col.SendMessage ("SetInLadder",false);
		}
	}

	void SetPushable(){
		pushable = true;
	}
}
