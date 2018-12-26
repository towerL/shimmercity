using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_hands : MonoBehaviour {
	private void OnTriggerStay2D(Collider2D col){
		if (col.tag == "bottle") {
			if (col.transform.position.x > this.transform.parent.position.x) {
				Vector3 pos = col.transform.position;
				pos.x += Time.deltaTime * 1.2f;
				col.transform.position = pos;
				//SendMessageUpwards ("SetPush", true);
			} else if (col.transform.position.x < this.transform.parent.position.x) {
				Vector3 pos = col.transform.position;
				pos.x -= Time.deltaTime * 1.2f;
				col.transform.position = pos;
				//SendMessageUpwards ("SetPush", true);
			}
		}
	}

	private void OnTriggerExit2D(Collider2D col){
		if (col.tag == "bottle") {
			//SendMessageUpwards("SetPush",false);
		}
	}
}