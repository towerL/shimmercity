using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet_handler2 : MonoBehaviour {

	private float used_time;
	private float exit_time;
	private bool timer;

	void Start(){
		timer = false;
	}

	void FixedUpdate(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			timer = false;
			SendMessageUpwards ("SetGround", false);
		}
	}

	public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "Ground") {
			//SendMessageUpwards ("SetGround", true);
		} else if (col.collider.tag == "Pipe") {
			//SendMessageUpwards ("SetGround", true);
			SendMessageUpwards ("SetPipe", true);
		} else if (col.collider.tag == "stone_stand") {
			//col.rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
			SendMessageUpwards ("SetStone", true);
			//SendMessageUpwards ("SetGround", true);
			if (!timer)
				timer = true;
			used_time = Time.time;
		} else if(col.collider.tag == "deerbug" || col.collider.tag == "Deerbug_long" || col.collider.tag == "Start_mouse" || col.collider.tag == "Spider"){
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D> (), col.collider);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), col.collider);
		}
        if(col.collider.tag == "Scene2Edge")
        {
            Physics2D.IgnoreCollision(col.collider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        SendMessageUpwards ("SetGround", true);
	}

	public void OnCollisionStay2D(Collision2D col){
		if (col.collider.tag == "Ground") {
			//SendMessageUpwards ("SetGround", true);
		} else if (col.collider.tag == "Pipe") {
			//SendMessageUpwards ("SetGround", true);
			SendMessageUpwards ("SetPipe", true);
		} else if (col.collider.tag == "stone_stand") {
			//col.rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;;
			SendMessageUpwards ("SetStone", true);
			//SendMessageUpwards ("SetGround", true);
		} else if(col.collider.tag == "deerbug" || col.collider.tag == "Deerbug_long" || col.collider.tag == "Start_mouse" || col.collider.tag == "Spider"){
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D> (), col.collider);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), col.collider);
		}
		SendMessageUpwards ("SetGround", true);
	}

		
	public void OnCollisionExit2D(Collision2D col){
		if (col.collider.tag == "Ground") {
			SendMessageUpwards("SetGround",false);
		}else if (col.collider.tag == "Pipe") {
			SendMessageUpwards("SetGround",false);
			SendMessageUpwards ("SetPipe", false);
		}else if (col.collider.tag == "stone_stand") {
			//col.rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
			exit_time=Time.time;
			if (exit_time - used_time >= 0.1f) {
				timer = false;
				SendMessageUpwards ("SetStone", false);
				SendMessageUpwards ("SetGround", false);
			}
		}else if(col.collider.tag == "deerbug" || col.collider.tag == "Deerbug_long" || col.collider.tag == "Start_mouse" || col.collider.tag == "Spider"){
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D> (), col.collider,false);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), col.collider,false);
		}

	}

}
