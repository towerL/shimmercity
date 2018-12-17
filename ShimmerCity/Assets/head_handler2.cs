using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head_handler2 : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "stone_stand") {
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Hands").GetComponent<Collider2D> (), col.GetComponent<Collider2D>());
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), col.GetComponent<Collider2D>());
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("hammer_in_attack").GetComponent<Collider2D> (), col.GetComponent<Collider2D>());
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<CapsuleCollider2D> (), col.GetComponent<Collider2D>());
		}
	}

	private void OnTriggerStay2D(Collider2D col){
		if (col.tag == "stone_stand") {
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Hands").GetComponent<Collider2D> (), col.GetComponent<Collider2D>());
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), col.GetComponent<Collider2D>());
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("hammer_in_attack").GetComponent<Collider2D> (), col.GetComponent<Collider2D>());
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<CapsuleCollider2D> (), col.GetComponent<Collider2D>());
		}
	}

	private void OnTriggerExit2D(Collider2D col){
		if (col.tag == "stone_stand") {
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Hands").GetComponent<Collider2D> (), col.GetComponent<Collider2D>(),false);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), col.GetComponent<Collider2D>(),false);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("hammer_in_attack").GetComponent<Collider2D> (), col.GetComponent<Collider2D>(),false);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<CapsuleCollider2D> (), col.GetComponent<Collider2D>(),false);
		}
	}
}
