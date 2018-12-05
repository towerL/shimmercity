using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hands_handler : MonoBehaviour {
	private void OnTriggerStay2D(Collider2D col){
		if (col.tag == "Box") {
			if (col.transform.position.x > this.transform.parent.position.x && Input.GetKey (KeyCode.D)) {
				Vector3 pos = col.transform.position;
				pos.x += Time.deltaTime * 1.2f;
				col.transform.position = pos;
				//Debug.Log ("right!");
				SendMessageUpwards ("SetPush", true);
			} else if (col.transform.position.x < this.transform.parent.position.x && Input.GetKey (KeyCode.A)) {
				Vector3 pos = col.transform.position;
				pos.x -= Time.deltaTime * 1.2f;
				col.transform.position = pos;
				//Debug.Log ("left!");
				SendMessageUpwards ("SetPush", true);
			} else {
				SendMessageUpwards("SetPush",false);
			}
		}
		if(col.tag == "deerbug"){
			//Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D> (), col.GetComponent<PolygonCollider2D>());
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), col.GetComponent<PolygonCollider2D>());
		}
	}
		
	private void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Box") {
			SendMessageUpwards("SetPush",false);
		}
		if(col.tag == "deerbug"){
			//Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D> (), col.GetComponent<PolygonCollider2D>(),false);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), col.GetComponent<PolygonCollider2D>(),false);
		}
	}

}