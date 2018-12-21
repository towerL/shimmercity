using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add_flying_hammer3 : MonoBehaviour {

	public float pushmove;
	public float projectilemove;

	private Rigidbody2D hammer_rigidbody;
	private PolygonCollider2D hammer_polygoncollider;
	private Animator hammer_animator;
	private SpriteRenderer spriterender;

	private bool Rotate=false;
	private bool exist = true;

	void Start () {
		hammer_animator = this.GetComponent<Animator> ();
		hammer_polygoncollider = this.GetComponent<PolygonCollider2D> ();
		hammer_rigidbody = this.GetComponent<Rigidbody2D> ();
		spriterender = this.gameObject.GetComponent<SpriteRenderer> ();
		spriterender.sortingOrder = -2;
	}

	void FixedUpdate () {
		if (exist) {
			spriterender.sortingOrder = 5;
			Rotate = true;
		} 
		hammer_animator.SetBool ("Rotate",Rotate);
		hammer_animator.SetBool ("exist",exist);
	}

	public void OnCollisionEnter2D(Collision2D col){
		if(col.collider.tag == "Ground" || col.collider.tag == "Brick" ){
			Destroy (gameObject);
		}
		if (col.collider.tag == "deerbug") {
			hammer_animator.Play ("lying_hammer");
			Destroy (gameObject);
			col.collider.SendMessage ("decreaseHp");
		}
	}

	public void OnCollisionExit2D(Collision2D col){
		if (col.collider.tag == "Ground" || col.collider.tag == "Brick") {
			Destroy (gameObject);
		}
	}

}

