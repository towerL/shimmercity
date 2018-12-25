using System.Collections.Generic;
using UnityEngine;

public class AI_ladder : MonoBehaviour {
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
		
	void SetInLadder(){
		inladder=true;
	}

	void SetPushable(){
		pushable = true;
	}
}
