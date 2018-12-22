using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour {
    //移动初始位置
    float h0;
	public float speed=3.0f;
    float mytime = 10.0f;

	private float harm=1.0f;
	private Vector3 used_position;
	private Quaternion used_rotation;

	void Start () {
        h0 = transform.position.y;
		used_position = transform.position;
		used_rotation = transform.rotation;
	}

	void Update () {
        mytime-=Time.deltaTime;
        if (System.Math.Abs(transform.position.y - h0) <= 15.0f) {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }      
        if (mytime<0)
        {
            var v = transform.position;
            v.y = h0;
            transform.position = v;
            mytime = 10.0f;
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
