using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class protect_layer_handler : MonoBehaviour {

	private bool protectlayer;

	SpriteRenderer protectlayer_render;

	void Start () {
		protectlayer_render = GetComponent<SpriteRenderer> ();
		protectlayer_render.sortingOrder = -2;
		protectlayer = false;
	}
	void Update () {
		if (protectlayer)
			protectlayer_render.sortingOrder = 3;
		else
			protectlayer_render.sortingOrder = -2;
	}

	void SetProtectLayer(bool flag){
		protectlayer = flag;
	}
}
