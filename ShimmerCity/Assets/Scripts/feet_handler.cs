using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feet_handler : MonoBehaviour {

	public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "Ground" || col.collider.tag == "Box" || col.collider.tag == "Nail" || col.collider.tag == "Locker_sister") {
			//SendMessageUpwards ("SetGround", true);
		} else if (col.collider.tag == "Belt") {
			SendMessageUpwards ("SetBelt", true);
		} else if (col.collider.tag == "Nail") {
			SendMessageUpwards ("SetNail", true);
		} else if (col.collider.tag == "Pipe") {
			//SendMessageUpwards ("SetGround", true);
		} else if(col.collider.tag == "deerbug"){
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D> (), col.collider);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), col.collider);
		}
		SendMessageUpwards ("SetGround", true);	
	}

	public void OnCollisionStay2D(Collision2D col){
		if (col.collider.tag == "Ground" || col.collider.tag == "Box" || col.collider.tag == "Nail" || col.collider.tag == "Locker_sister") {
			//SendMessageUpwards ("SetGround", true);
		} else if (col.collider.tag == "Belt") {
			//SendMessageUpwards ("SetGround", true);
			SendMessageUpwards ("SetBelt", true);
		} else if (col.collider.tag == "Nail") {
			SendMessageUpwards ("SetNail", true);
		} else if (col.collider.tag == "Pipe") {
			//SendMessageUpwards ("SetGround", true);
		} else if(col.collider.tag == "deerbug"){
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D> (), col.collider);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), col.collider);
		}
		SendMessageUpwards ("SetGround", true);	
	}
		

	public void OnCollisionExit2D(Collision2D col){
		if (col.collider.tag == "Ground" || col.collider.tag == "Box"|| col.collider.tag == "Nail"  || col.collider.tag == "Locker_sister"  || col.collider.tag == "deerbug") {
			//SendMessageUpwards("SetGround",false);
		}else if (col.collider.tag == "Belt") {
			//SendMessageUpwards("SetGround",false);
			SendMessageUpwards ("SetBelt", false);
		}else if (col.collider.tag == "Nail") {
			SendMessageUpwards ("SetNail", false);
		}else if (col.collider.tag == "Pipe") {
			//SendMessageUpwards ("SetGround", false);
		}else if(col.collider.tag == "deerbug"){
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D> (), col.collider,false);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), col.collider,false);
		}
		SendMessageUpwards("SetGround",false);
	}
}