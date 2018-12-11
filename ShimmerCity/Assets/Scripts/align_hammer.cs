using System.Collections;
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



	void Start () {
		hammer_animator = this.GetComponent<Animator> ();
		hammer_polygoncollider = this.GetComponent<PolygonCollider2D> ();
		spriterender = this.gameObject.GetComponent<SpriteRenderer> ();
		spriterender.sortingOrder = -2;
	}
		
	void Update () {
		if (infurtherattack && inhand && exist) {
			spriterender.sprite = static_sprite;
			spriterender.sortingOrder = 3;
			/*this.gameObject.AddComponent<Rigidbody2D> ();
			hammer_rigidbody = this.GetComponent<Rigidbody2D> ();
			hammer_rigidbody.AddForce (Vector2.right * pushmove);
			hammer_rigidbody.AddForce (Vector2.up * projectilemove);
			Rotate = true;
			inhand = false;
			infurtherattack = false;
			*/
			/*
			GameObject hammer_cloned = new GameObject ();
			hammer_cloned.AddComponent<SpriteRenderer> ();
			SpriteRenderer hammer_sprite = hammer_cloned.GetComponent<SpriteRenderer> ();
			hammer_sprite.sprite = init_sprite;
			hammer_sprite.sortingOrder = 4;
			hammer_cloned.name="hammer_thrown";
			//hammer_cloned.transform.position = transform.Find ("hammer_in_attack").position;
			hammer_cloned.AddComponent<PolygonCollider2D> ();
			PolygonCollider2D hammer_collider = hammer_cloned.GetComponent<PolygonCollider2D> ();
			hammer_collider.isTrigger = false;
			hammer_cloned.AddComponent<Rigidbody2D> ();
			Rigidbody2D hammer_cloned_rigidbody = hammer_cloned.GetComponent<Rigidbody2D> ();
			hammer_rigidbody.AddForce (Vector2.right * pushmove);
			hammer_rigidbody.AddForce (Vector2.up * projectilemove);*/

			infurtherattack = false;
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
	}

	public void OnCollisionEnter2D(Collision2D col){
		if(col.collider.tag == "Ground" || col.collider.tag == "Box" || col.collider.tag == "Belt" ){
			Rotate = false;
			hit_ground = true;
			exist = false;
			Vector2 direction = transform.position-target.position;
			float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			Destroy (this.gameObject.GetComponent<Rigidbody> ());
			hammer_animator.SetBool ("Rotate",Rotate);
			hammer_animator.SetBool ("hit_ground",hit_ground);
		}
		if (col.collider.tag == "deerbug") {
			ContactPoint2D contact = col.contacts[0];
			Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			Vector3 pos = contact.point;
			Vector2 direction = transform.position-target.position;
			float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			hammer_animator.Play ("lying_hammer");
			Debug.Log ("Hit the deerbug!");
			//col.gameObject.SendMessage ();
		}
	}

	public void OnCollisionExit2D(Collision2D col){
		if (col.collider.tag == "Ground" || col.collider.tag == "Box" || col.collider.tag == "Belt") {
			exist = false;
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

}
