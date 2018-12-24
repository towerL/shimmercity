using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add_flying_hammer : MonoBehaviour {
	
	private Animator hammer_animator;
	private SpriteRenderer spriterender;

	private bool Rotate;

	void Start () {
		hammer_animator = this.GetComponent<Animator> ();
		spriterender = this.gameObject.GetComponent<SpriteRenderer> ();
		spriterender.sortingOrder = 3;
		Rotate = true;
	}

	void FixedUpdate () {
		hammer_animator.SetBool ("Rotate",Rotate);
	}

	private void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "deerbug") {
			col.collider.SendMessage ("decreaseHp");
		}
		Destroy (gameObject);
	}

}
