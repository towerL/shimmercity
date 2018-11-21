using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feet_handler : MonoBehaviour {

	public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "Ground" || col.collider.tag == "Box" || col.collider.tag == "Nail") {
			SendMessageUpwards ("SetGround", true);
		} else if (col.collider.tag == "Belt") {
			SendMessageUpwards ("SetGround", true);
			SendMessageUpwards ("SetBelt", true);
		} else if (col.collider.tag == "Nail") {
			SendMessageUpwards ("SetNail", true);
		}
	}
	public void OnCollisionExit2D(Collision2D col){
		if (col.collider.tag == "Ground" || col.collider.tag == "Box"|| col.collider.tag == "Nail") {
			SendMessageUpwards("SetGround",false);
		}else if (col.collider.tag == "Belt") {
			SendMessageUpwards("SetGround",false);
			SendMessageUpwards ("SetBelt", false);
		}else if (col.collider.tag == "Nail") {
			SendMessageUpwards ("SetNail", false);
		}
	}
}