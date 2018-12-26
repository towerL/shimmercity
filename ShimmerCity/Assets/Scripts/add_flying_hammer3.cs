using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add_flying_hammer3 : MonoBehaviour {

	private Animator hammer_animator;
	private SpriteRenderer spriterender;

	private bool Rotate;

	void Start () {
		hammer_animator = this.GetComponent<Animator> ();
		spriterender = this.gameObject.GetComponent<SpriteRenderer> ();
		spriterender.sortingOrder = 10;
		Rotate = true;
	}

	void FixedUpdate () {
		hammer_animator.SetBool ("Rotate",Rotate);
	}

	private void OnCollisionEnter2D(Collision2D col){
		//if (col.collider.tag == "boss") {//
		//	col.collider.SendMessage ("decreaseHp");
		//}
		Debug.Log (col.gameObject.name);
		Debug.Log (col.gameObject.tag);
		Destroy (gameObject);
	}
		
}

