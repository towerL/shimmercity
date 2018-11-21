using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hands_handler : MonoBehaviour {

	/*public void OnCollisionStay2D(Collision2D col){
		if (col.collider.tag == "Box") {
			SendMessageUpwards("SetPush",true);
			//if(col.transform.position.x>transform.position.x)
			//	col.rigidbody.AddForce(Vector2.right*0.1f);
		}
 	}
	public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "Box") {
			SendMessageUpwards("SetPush",true);a
		}
	}
	public void OnCollisionExit2D(Collision2D col){
		if (col.collider.tag == "Box") {
			SendMessageUpwards("SetPush",false);
		}
	}*/

	private void OnTriggerStay2D(Collider2D col){
		if (col.tag == "Box") {
			SendMessageUpwards("SetPush",true);
			if (col.transform.position.x > transform.position.x && Input.GetKey(KeyCode.D)) {
				Vector3 pos = col.transform.position;
				pos.x += Time.deltaTime * 0.3f;
				col.transform.position = pos;
			}else if (col.transform.position.x < transform.position.x && Input.GetKey(KeyCode.A)) {
				Vector3 pos = col.transform.position;
				pos.x -= Time.deltaTime * 0.3f;
				col.transform.position = pos;
			}
		}
	}

	private void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Box") {
			SendMessageUpwards("SetPush",false);
		}
	}

}