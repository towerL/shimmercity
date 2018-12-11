using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hands_handler3 : MonoBehaviour {
	private void OnTriggerStay2D(Collider2D col){
		if (col.tag == "bottle") {
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
	}

	private void OnTriggerExit2D(Collider2D col){
		if (col.tag == "bottle") {
			SendMessageUpwards("SetPush",false);
		}
	}
}