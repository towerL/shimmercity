using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hands_handler : MonoBehaviour {
	private void OnTriggerStay2D(Collider2D col){
		if (col.tag == "Box") {
			SendMessageUpwards("SetPush",true);
			if (col.transform.position.x > transform.position.x && Input.GetKey(KeyCode.D)) {
				Vector3 pos = col.transform.position;
				pos.x += Time.deltaTime * 0.49f;
				col.transform.position = pos;
			}else if (col.transform.position.x < transform.position.x && Input.GetKey(KeyCode.A)) {
				Vector3 pos = col.transform.position;
				pos.x -= Time.deltaTime * 0.49f;
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