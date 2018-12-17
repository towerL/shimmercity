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
	private bool hit_ground=false;
	private bool exist = true;

	void Start () {
		hammer_animator = this.GetComponent<Animator> ();
		hammer_polygoncollider = this.GetComponent<PolygonCollider2D> ();
		hammer_rigidbody = this.GetComponent<Rigidbody2D> ();
		spriterender = this.gameObject.GetComponent<SpriteRenderer> ();
		spriterender.sortingOrder = -2;
		/*hammer_rigidbody.AddForce (-Vector2.right *pushmove);
		hammer_rigidbody.AddForce (Vector2.up *projectilemove);
		Debug.Log (hammer_rigidbody.velocity.x);*/
	}

	void Update () {
		if (exist) {
			spriterender.sortingOrder = 5;
			Rotate = true;
		} else if (!exist) {
			//hammer_animator.Play ("hammer_hit");
			Destroy (gameObject,0.2f);
		}
		hammer_animator.SetBool ("Rotate",Rotate);
		hammer_animator.SetBool ("hit_ground",hit_ground);
		hammer_animator.SetBool ("exist",exist);
	}

	public void OnCollisionEnter2D(Collision2D col){
		if(col.collider.tag == "Ground" || col.collider.tag == "Brick" ){
			Rotate = false;
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
		if (col.collider.tag == "Ground" || col.collider.tag == "Brick") {
			exist = false;
		}
	}

}

