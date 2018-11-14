using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class align_hammer : MonoBehaviour {

	public Transform target;
	public float pushmove=1500.0f;
	public float projectilemove=3000.0f;
	private Rigidbody2D hammer_rigidbody;
	private BoxCollider2D hammer_boxcollider;
	private Animator hammer_animator;
	private Vector3 hammer_Scale;
	private Vector3 pos;
	private bool inattack=false;
    //private bool inattack=true;
	private bool Rotate=false;
	private bool hit_ground=false;
	private bool returnback=false;
	private bool inhand=true;
	private bool exist = true;

	void Start () {
		hammer_rigidbody = this.GetComponent<Rigidbody2D> ();
		hammer_animator = this.GetComponent<Animator> ();
		hammer_boxcollider = this.GetComponent<BoxCollider2D> ();
		hammer_Scale = transform.localScale;
		pos = transform.position;
		pos.x = target.position.x+0.5f;
		pos.y = target.position.y;
		transform.position = pos;
	}
		
	void Update () {
		if (!inattack && inhand && exist) {
			Vector3 pos = transform.position;
			/*if (pos.x > target.position.x) {
				pos.x = target.position.x + 0.5f;
				hammer_Scale.x = Mathf.Abs (hammer_Scale.x);
			} else {
				pos.x = target.position.x - 0.5f;
				hammer_Scale.x = -Mathf.Abs (hammer_Scale.x);
			}*/
			pos.x = target.position.x;
			pos.y = target.position.y;
			transform.position = pos;
		} else if (inattack && inhand && exist) {
			/*Vector3 pos = transform.position;
			if (pos.x > target.position.x) {
				hammer_Scale.x = Mathf.Abs (hammer_Scale.x);
				hammer_rigidbody.AddForce (Vector2.right * pushmove);
			} else {
				hammer_Scale.x = -Mathf.Abs (hammer_Scale.x);
				hammer_rigidbody.AddForce (-Vector2.right * pushmove);
			}*/
			hammer_rigidbody.AddForce (Vector2.right * pushmove);
			hammer_rigidbody.AddForce (Vector2.up * projectilemove);
			Rotate = true;
			hammer_animator.Play ("hammer_rotate");
			//exist = false;
			inhand = false;
			inattack = false;
			hammer_animator.SetBool ("Rotate", Rotate);
			hammer_animator.SetBool ("inhand",inhand);
			hammer_animator.SetBool ("inattack",inattack);
		}
		if (!exist) {
			//Destroy (gameObject, 2);
		}
		hammer_animator.SetBool ("Rotate",Rotate);
		hammer_animator.SetBool ("hit_ground",hit_ground);
		hammer_animator.SetBool ("returnback",returnback);
		hammer_animator.SetBool ("inattack",inattack);
		hammer_animator.SetBool ("inhand",inhand);
	}

	public void OnCollisionEnter2D(Collision2D col){
		if(col.collider.tag == "Ground" || col.collider.tag == "Box" || col.collider.tag == "Belt" ){
			Rotate= false;
			hit_ground = true;
			returnback = true;
			exist = false;
			Vector2 direction = transform.position-target.position;
			float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			hammer_animator.SetBool ("Rotate",Rotate);
			hammer_animator.SetBool ("hit_ground",hit_ground);
			hammer_animator.SetBool ("returnback",returnback);
		}
	}

	void SetAttack(bool flag){
		inattack = flag;
		Rotate = true;
		hammer_animator.SetBool ("inattack",inattack);
		hammer_animator.SetBool ("Rotate",Rotate);
	}

	void SetHammer(bool flag){
		inhand = flag;
		hammer_animator.SetBool ("inhand",inhand);
	}

	public void OnCollisionExit2D(Collision2D col){
		if (col.collider.tag == "Ground" || col.collider.tag == "Box" || col.collider.tag == "Belt") {
			exist = false;
			//inhand = false;
			//hammer_animator.SetBool ("inhand",inhand);
		}
	}
}
