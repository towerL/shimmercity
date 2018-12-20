using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floating_shield : MonoBehaviour {
	float radian = 0; 
	float perRadian = 0.03f;
	float radius = 0.4f; 
	Vector3 oldPos; 
	void Start()
	{
		oldPos = transform.position; 
	}

	void Update()
	{
		radian += perRadian; 
		float dy = Mathf.Cos(radian) * radius; 
		transform.position = oldPos + new Vector3(0, dy, 0);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Player") {
			collision.SendMessage ("SetShield",true);
			GameObject.FindWithTag ("MainCamera").SendMessage ("SetShieldFlag1",true);
			Destroy (gameObject);
		}
	}
}
