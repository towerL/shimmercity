using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add_flying_hammer : MonoBehaviour {

	public float pushmove=1500.0f;
	public float projectilemove=3000.0f;

	private Rigidbody2D hammer_rigidbody;
	private PolygonCollider2D hammer_polygoncollider;
	private Animator hammer_animator;
	private SpriteRenderer spriterender;

	private bool Rotate=false;
	private bool hit_ground=false;
	private bool exist = true;

	void Start () {
		hammer_animator = this.GetComponent<Animator> ();
		hammer_polygoncollider = this.GetComponent<PolygonCollider2D> ();
		hammer_rigidbody = this.GetComponent<Rigidbody2D> ();
		spriterender = this.gameObject.GetComponent<SpriteRenderer> ();
		spriterender.sortingOrder = -2;
	}

	void Update () {
		if (exist) {
			spriterender.sortingOrder = 3;
			//flying_hammer_instance=GameObject.Instantiate (flying_hammer, transform.position,Quaternion.identity) as GameObject;	
			//hammer_rigidbody.AddForce (Vector2.right * pushmove);
			//hammer_rigidbody.AddForce (Vector2.up * projectilemove);
			Rotate = true;
		} else if (!exist) {
			hammer_animator.Play ("hammer_hit");
			Destroy (gameObject, 2);
		}
		hammer_animator.SetBool ("Rotate",Rotate);
		hammer_animator.SetBool ("hit_ground",hit_ground);
	}

	public void OnCollisionEnter2D(Collision2D col){
		if(col.collider.tag == "Ground" || col.collider.tag == "Box" || col.collider.tag == "Belt" ){
			//Rotate = false;
			hit_ground = true;
			exist = false;
			hammer_animator.SetBool ("Rotate",Rotate);
			hammer_animator.SetBool ("hit_ground",hit_ground);
		}
		if (col.collider.tag == "deerbug") {
			hammer_animator.Play ("lying_hammer");
			col.collider.SendMessage ("decreaseHp");
		}
	}

	public void OnCollisionExit2D(Collision2D col){
		if (col.collider.tag == "Ground" || col.collider.tag == "Box" || col.collider.tag == "Belt") {
			exist = false;
		}
	}

}
