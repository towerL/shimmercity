using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_hammer2 : MonoBehaviour {
	public float left_align;
	public float up_align;
	public float startangle;
	public float endangle;
	public float bigger;
	public float rot1_speed;
	public float rot2_speed;
	private Transform target;
	private float angle;
	private bool stage1;
	private bool stage2;
	private Vector3 pos;

	public float Disappear;
	private float disappear;
	public float disappear_speed;

	private int rotflag;

	void Start () {
		stage1 = true;
		stage2 = false;
		target = GameObject.FindGameObjectWithTag("Player").transform;
		rotflag = target.localScale.x>0.0f?1:-1;
		Vector3 Scale = transform.localScale;
		Scale.x=transform.localScale.x *rotflag;
		transform.localScale = Scale;
		transform.position = target.position + new Vector3 (-left_align*rotflag,up_align,0.0f);
		pos=transform.position + new Vector3 (-0.93f*rotflag, -2.02f, 0.0f);
		angle = startangle*rotflag;;
	}

	void FixedUpdate () {	
		if (stage1){
			float rotangle = rot1_speed * Time.deltaTime*rotflag;
			transform.RotateAround (pos, new Vector3 (0.0f, 0.0f, 90.0f), rotangle);
			angle -= rotangle;
			if (angle*rotflag<= 0.0f) {
				stage1 = false;
				stage2 = true;
			}	
		}
		if (stage2) {
			float rotangle = rot2_speed * Time.deltaTime;
			transform.Translate (rotangle/endangle*new Vector3(0.93f*rotflag,2.02f,0.0f));
			transform.RotateAround (pos, new Vector3 (0.0f, 0.0f, -90.0f), rotangle*rotflag);
			angle += rotangle;
			transform.localScale = bigger*(angle/endangle)*new Vector3(1.0f*rotflag,1.0f,1.0f);
			if (angle>= endangle) {
				stage2 = false;
				disappear = 0.0f;
			}
		}
		if (!stage1 && !stage2) {
			if (disappear <= Disappear) {
				disappear += Time.deltaTime*disappear_speed;
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
		if (col.collider.tag == "Skill_L") {
			Physics2D.IgnoreCollision (col.collider,GetComponent<Collider2D>());
		}
		if (col.collider.tag == "deerbug") {
			col.collider.SendMessage ("decreaseHp");
		}
		if (col.collider.tag == "Deerbug_long") {
			col.collider.SendMessage ("decreaseHp");
		}
		if (col.collider.tag == "Start_mouse") {
			col.collider.SendMessage ("decreaseHp");
		}
	}
}
