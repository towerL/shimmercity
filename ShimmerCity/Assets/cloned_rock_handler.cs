using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  cloned_rock_handler : MonoBehaviour {
	//移动初始位置
	float h0;
	private float speed=3;
	float mytime = 10.0f;

	private float harm=1.0f;
	private Vector3 used_position;
	private Quaternion used_rotation;

	private bool falling;
	private float timer;
	void Start () {
		h0 = transform.position.y;
		used_position = transform.position;
		used_rotation = transform.rotation;
		falling = false;
		timer = Time.time;
	}

	void Update () {
		if (falling) {
			mytime -= Time.deltaTime;
			if (System.Math.Abs (transform.position.y - h0) <= 15.0f) {
				transform.Translate (Vector2.down * speed * Time.deltaTime);
			}      
			if (mytime < 0) {
				var v = transform.position;
				v.y = h0;
				transform.position = v;
				mytime = 10.0f;
			}
		} else {
			if (Time.time - timer >= 2.0f)
				falling = true;
		}
	}

	private void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player"){
			GameObject newer_rock = Instantiate (Resources.Load ("prefabs/rock"),used_position,used_rotation) as GameObject;
			col.SendMessage ("PlayerDecreaseHP",harm);
			Destroy (gameObject);
		}
		if (col.tag == "Ground"){
			GameObject newer_rock = Instantiate (Resources.Load ("prefabs/rock"),used_position,used_rotation) as GameObject;
			Destroy (gameObject);
		}
	}
}