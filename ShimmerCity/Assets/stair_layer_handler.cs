using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stair_layer_handler : MonoBehaviour {

	private SpriteRenderer stair_layer;
	private bool layer_flag;

	void Start () {
		stair_layer = GetComponent<SpriteRenderer> ();
		stair_layer.sortingOrder = 2;
		layer_flag = false;
	}
	void Update () {
		stair_layer.sortingOrder = (layer_flag==true? 4: 2);
	}

	void SetLayerOrder(bool flag){
		layer_flag = flag;
	}
}
