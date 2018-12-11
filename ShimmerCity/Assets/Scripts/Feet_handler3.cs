using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet_handler3 : MonoBehaviour {
	public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "Ground" || col.collider.tag == "Brick" || col.collider.tag == "StaticBrick" || col.collider.tag == "bottle") {
			SendMessageUpwards ("SetGround", true);
		} 
	}

	public void OnCollisionExit2D(Collision2D col){
		if (col.collider.tag == "Ground" || col.collider.tag == "Brick" || col.collider.tag == "StaticBrick" || col.collider.tag == "bottle") {
			SendMessageUpwards("SetGround",false);
		}
	}
}
