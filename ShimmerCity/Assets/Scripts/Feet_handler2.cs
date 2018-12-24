﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet_handler2 : MonoBehaviour {
	public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "Ground") {
			SendMessageUpwards ("SetGround", true);
		} else if (col.collider.tag == "Pipe") {
			SendMessageUpwards ("SetGround", true);
			SendMessageUpwards ("SetPipe", true);
		} else if (col.collider.tag == "stone_stand") {
			//col.rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
			SendMessageUpwards ("SetStone", true);
			SendMessageUpwards ("SetGround", true);
		} else if(col.collider.tag == "deerbug" || col.collider.tag == "Deerbug_long" || col.collider.tag == "Start_mouse" || col.collider.tag == "Spider"){
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D> (), col.collider);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), col.collider);
		}
	}

	public void OnCollisionStay2D(Collision2D col){
		if (col.collider.tag == "Ground") {
			SendMessageUpwards ("SetGround", true);
		} else if (col.collider.tag == "Pipe") {
			SendMessageUpwards ("SetGround", true);
			SendMessageUpwards ("SetPipe", true);
		} else if (col.collider.tag == "stone_stand") {
			//col.rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;;
			SendMessageUpwards ("SetStone", true);
			SendMessageUpwards ("SetGround", true);
		} else if(col.collider.tag == "deerbug" || col.collider.tag == "Deerbug_long" || col.collider.tag == "Start_mouse" || col.collider.tag == "Spider"){
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D> (), col.collider);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), col.collider);
		}
	}

		
	public void OnCollisionExit2D(Collision2D col){
		if (col.collider.tag == "Ground") {
			SendMessageUpwards("SetGround",false);
		}else if (col.collider.tag == "Pipe") {
			SendMessageUpwards("SetGround",false);
			SendMessageUpwards ("SetPipe", false);
		}else if (col.collider.tag == "stone_stand") {
			col.rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
			SendMessageUpwards ("SetStone", true);
			SendMessageUpwards("SetGround",false);
		}else if(col.collider.tag == "deerbug" || col.collider.tag == "Deerbug_long" || col.collider.tag == "Start_mouse" || col.collider.tag == "Spider"){
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D> (), col.collider,false);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), col.collider,false);
		}
	}

	/*
	public void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Ground") {
			SendMessageUpwards ("SetGround", true);
		} else if (col.tag == "Pipe") {
			SendMessageUpwards ("SetGround", true);
			SendMessageUpwards ("SetPipe", true);
		} else if (col.tag == "stone_stand") {
			SendMessageUpwards ("SetStone", true);
			SendMessageUpwards ("SetGround", true);
		} else if(col.tag == "deerbug" || col.tag == "Deerbug_long"){
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D> (), col);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), col);
		}
	}

	public void OnTriggerStay2D(Collider2D col){
		if (col.tag == "Ground") {
			SendMessageUpwards ("SetGround", true);
		} else if (col.tag == "Pipe") {
			SendMessageUpwards ("SetGround", true);
			SendMessageUpwards ("SetPipe", true);
		} else if (col.tag == "stone_stand") {
			SendMessageUpwards ("SetStone", true);
			SendMessageUpwards ("SetGround", true);
		} else if(col.tag == "deerbug" || col.tag == "Deerbug_long"){
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D> (), col);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), col);
		}
	}


	public void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Ground") {
			SendMessageUpwards("SetGround",false);
		}else if (col.tag == "Pipe") {
			SendMessageUpwards("SetGround",false);
			SendMessageUpwards ("SetPipe", false);
		}else if (col.tag == "stone_stand") {
			SendMessageUpwards ("SetStone", true);
			SendMessageUpwards("SetGround",false);
		}else if(col.tag == "deerbug" || col.tag == "Deerbug_long"){
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D> (), col,false);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), col,false);
		}
	}*/
}
