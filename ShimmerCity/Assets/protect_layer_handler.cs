using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class protect_layer_handler : MonoBehaviour {

	private bool protectlayer;

	SpriteRenderer protectlayer_render;
	private CircleCollider2D circle;
	void Start () {
		protectlayer_render = GetComponent<SpriteRenderer> ();
		circle = GetComponent<CircleCollider2D> ();
		protectlayer_render.sortingOrder = -2;
		protectlayer = false;
		circle.isTrigger = true;
		circle.enabled = false;
	}
	void Update () {
		if (protectlayer) {
			protectlayer_render.sortingOrder = 3;
			circle.isTrigger = false;
		} else {
			protectlayer_render.sortingOrder = -2;
			circle.isTrigger = true;
			circle.enabled = false;
		}
	}

	void SetProtectLayer(bool flag){
		protectlayer = flag;
		circle.enabled = true;
	}

	public void OnCollisionEnter2D(Collision2D col){
		Destroy (col.gameObject);
	}
}
