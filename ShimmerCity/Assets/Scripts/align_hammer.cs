﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class align_hammer : MonoBehaviour {

	public Transform target;
	public float pushmove=1500.0f;
	public float projectilemove=3000.0f;

	private Rigidbody2D hammer_rigidbody;
	private PolygonCollider2D hammer_polygoncollider;
	private Animator hammer_animator;
	private SpriteRenderer spriterender;

	public Sprite static_sprite;
	public Sprite init_sprite;

	private Vector2 beginpos;
	private Vector2 endpos;

	private bool incloseattack = false;
	private bool infurtherattack = false;
	private bool Rotate=false;
	private bool hit_ground=false;
	private bool inhand=true;
	private bool exist = true;

	public float attack_range;
	//.private bool timer = false;
	//private float time;

	//public GameObject flying_hammer;
	private float timer_flying_hammer;
	//public  GameObject flying_hammer_instance;
	private bool player_dir;

	public Collider2D target_collider;
	private Vector3 Position;
	private Quaternion Rotation;
	private Vector3 Scale;
	private Vector2 Velocity;
	private bool getposvalue;
	private bool getrotvalue;
	private bool getscavalue;
	private bool getvelvalue;

	void Start () {
		hammer_animator = this.GetComponent<Animator> ();
		hammer_polygoncollider = this.GetComponent<PolygonCollider2D> ();
		spriterender = this.gameObject.GetComponent<SpriteRenderer> ();
		spriterender.sortingOrder = -2;
		timer_flying_hammer = Time.time;
		player_dir = true;
		getposvalue = false;
		getrotvalue = false;
		getscavalue = false;
		getvelvalue = false;
	}
		
	void Update () {
		if (infurtherattack && inhand && exist) {
			spriterender.sprite = static_sprite;
			spriterender.sortingOrder = 3;
			if (getposvalue && getrotvalue && getscavalue && getvelvalue) {
				GameObject flying_hammer_instance = Instantiate (Resources.Load ("prefabs/flying_hammer1"), Position,Rotation) as GameObject;
				Transform flying_hammer_transform = flying_hammer_instance.GetComponent<Transform> ();
				//flying_hammer_transform.localScale = Scale;
				Rigidbody2D flying_hammer_rigidbody = flying_hammer_instance.GetComponent<Rigidbody2D> ();
				Physics2D.IgnoreCollision (target_collider,flying_hammer_instance.GetComponent<Collider2D>());
				if(player_dir)
					flying_hammer_rigidbody.AddForce (Vector2.right *pushmove);
				else
					flying_hammer_rigidbody.AddForce (-Vector2.right *pushmove);
				flying_hammer_rigidbody.AddForce (Vector2.up *projectilemove);
				getposvalue = false;
				getrotvalue = false;
				getscavalue = false;
				getvelvalue = false;
				infurtherattack = false;
			}				
		} 
		if (incloseattack && inhand && exist) {
			incloseattack = false;
			spriterender.sortingOrder = 0;
		} 

		/*if (!exist) {
			hammer_animator.Play ("hammer_hit");
			//Destroy (gameObject, 2);
		}*/
		hammer_animator.SetBool ("Rotate",Rotate);
		hammer_animator.SetBool ("hit_ground",hit_ground);
		hammer_animator.SetBool ("incloseattack",incloseattack);
		hammer_animator.SetBool ("infurtherattack",infurtherattack);
		hammer_animator.SetBool ("inhand",inhand);
		hammer_animator.SetBool ("getposval",getposvalue);
		hammer_animator.SetBool ("getrotval",getrotvalue);
		hammer_animator.SetBool ("getscaval",getscavalue);
		hammer_animator.SetBool ("getvelval",getvelvalue);
		hammer_animator.SetBool ("exist",exist);
	}

	/*public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "deerbug") {
			ContactPoint2D contact = col.contacts[0];
			Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			Vector3 pos = contact.point;
			Vector2 direction = transform.position-target.position;
			float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			Debug.Log ("Hit the deerbug!");
			col.collider.SendMessage ("decreaseHp");
		}
	}*/

	public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "Skill_L") {
			Physics2D.IgnoreCollision (col.collider,GetComponent<Collider2D>());
		}
		if (col.collider.tag == "deerbug") {
			col.collider.SendMessage ("decreaseHp");
		}
	}
		

	void SetCloseAttack(bool flag){
		incloseattack = flag;
		hammer_animator.SetBool ("incloseattack",incloseattack);
	}

	void SetFurtherAttack(bool flag){
		infurtherattack = flag;
		hammer_animator.SetBool ("infurtherattack",infurtherattack);
	}

	void SetHammer(bool flag){
		inhand = flag;
		hammer_animator.SetBool ("inhand",inhand);
	}

	void SetPlayerDir(bool flag){
		player_dir = flag;
	}

	void SetPos(Vector3 Pos){
		getposvalue = true;
		Position = Pos;
		hammer_animator.SetBool ("getposval",getposvalue);
	}

	void SetRot(Quaternion Rot){
		getrotvalue = true;
		Rotation = Rot;
		hammer_animator.SetBool ("getrotval",getrotvalue);
	}

	void SetSca(Vector3 Sca){
		getscavalue = true;
		Scale = Sca;
		hammer_animator.SetBool ("getscaval",getscavalue);
	}

	void SetVel(Vector2 Vel){
		getvelvalue = true;
		Velocity = Vel;
		hammer_animator.SetBool ("getvelval",getvelvalue);
	}
}
