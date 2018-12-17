using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hands_handler2 : MonoBehaviour {
	private void OnTriggerStay2D(Collider2D col){
		if(col.tag == "deerbug" || col.tag == "Deerbug_long" ){
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D> (), col.GetComponent<PolygonCollider2D>());
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), col.GetComponent<PolygonCollider2D>());
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("hammer_in_attack").GetComponent<Collider2D> (), col.GetComponent<PolygonCollider2D>());
		}
	}

	private void OnTriggerExit2D(Collider2D col){
		if(col.tag == "deerbug" || col.tag == "Deerbug_long" ){
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D> (), col.GetComponent<PolygonCollider2D>(),false);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (), col.GetComponent<PolygonCollider2D>(),false);
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("hammer_in_attack").GetComponent<Collider2D> (), col.GetComponent<PolygonCollider2D>(),false);
		}
	}

}
