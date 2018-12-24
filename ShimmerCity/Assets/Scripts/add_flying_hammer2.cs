using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add_flying_hammer2 : MonoBehaviour {

	private Animator hammer_animator;
	private SpriteRenderer spriterender;

	private bool Rotate;

	void Start () {
		hammer_animator = this.GetComponent<Animator> ();
		spriterender = this.gameObject.GetComponent<SpriteRenderer> ();
		spriterender.sortingOrder = 6;
		Rotate = true;
	}

	void FixedUpdate () {
		hammer_animator.SetBool ("Rotate",Rotate);
	}

	private void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "Deerbug_long") {
			col.collider.SendMessage ("decreaseHp");
		}
		if (col.collider.tag == "Start_mouse") {
			col.collider.SendMessage ("decreaseHp");
		}
		Destroy (gameObject);
	}
}

