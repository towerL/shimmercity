using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_hammer : MonoBehaviour {

	public Transform target;
	public float startangle;
	public float endangle;
	public float bigger;
	private float angle;
	private bool stage1;
	private bool stage2;
	private Vector3 pos;

	public float Disappear;
	private float disappear;

	void Start () {
		angle = startangle;
		stage1 = true;
		stage2 = false;
		target = GameObject.FindGameObjectWithTag("bottle").transform;
		transform.position = target.position + new Vector3 (-2.0f,4.0f,0.0f);
		pos=transform.position + new Vector3 (-0.93f, -2.02f, 0.0f);

	}

	void Update () {	
		if (stage1){
			float rotangle = 100.0f * Time.deltaTime;
			transform.RotateAround (pos, new Vector3 (0.0f, 0.0f, 90.0f), rotangle);
			angle -= rotangle;
			if (angle <= 0.0f) {
				stage1 = false;
				stage2 = true;
			}	
		}
		if (stage2) {
			float rotangle = 600.0f * Time.deltaTime;
			transform.Translate (rotangle/endangle*new Vector3(0.93f,2.02f,0.0f));
			transform.RotateAround (pos, new Vector3 (0.0f, 0.0f, -90.0f), rotangle);
			angle += rotangle;
			transform.localScale = bigger*(angle/endangle)*new Vector3(1.0f,1.0f,1.0f);
			if (angle >= endangle) {
				stage2 = false;
				disappear = 0.0f;
			}
		}
		if (!stage1 && !stage2) {
			if (disappear <= Disappear) {
				disappear += Time.deltaTime;
			}
			if (GetComponent<SpriteRenderer> ().material.color.a <= 1) {
				GetComponent<Renderer> ().material.color = new Color (GetComponent<Renderer> ().material.color.r
					, GetComponent<Renderer> ().material.color.g
					, GetComponent<Renderer> ().material.color.b
					, gameObject.GetComponent<Renderer> ().material.color.a - disappear / 50);
			}
			if (GetComponent<SpriteRenderer> ().material.color.a <= 0.0f)
				Destroy (gameObject);
		}
	}

	public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "Boss") {

		}
	}
}
