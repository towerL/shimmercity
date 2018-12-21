using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Event : MonoBehaviour {

	GameObject hammer;
	Transform hammer_transform;
	Rigidbody2D hammer_rigidbody;

	void Start () {
		hammer_transform = transform.Find("Hammer_for_attack");
		hammer = GameObject.Find("Hammer_for_attack");
		hammer_rigidbody = hammer.GetComponent<Rigidbody2D> ();
	}

	public void HammerMessage1(){
		hammer.SendMessage ("SetPos",hammer_transform.position);
	}
	public void HammerMessage2(){
		hammer.SendMessage ("SetVel",hammer_rigidbody.velocity);
	}
	public void HammerMessage3(){
		hammer.SendMessage ("SetRot",hammer_transform.rotation);
	}
	public void HammerMessage4(){
		hammer.SendMessage ("SetSca",hammer_transform.localScale);
	}
}
