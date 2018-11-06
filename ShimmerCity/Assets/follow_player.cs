using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_player : MonoBehaviour {

	public Transform target;

	void Update () {
 		Vector3 pos = transform.position;
		pos.x = target.position.x;
		pos.y = target.position.y;
		transform.position = pos;
	}
}
