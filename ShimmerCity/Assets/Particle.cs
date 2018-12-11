using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {

	public Transform inner;
	private ParticleSystem particle;
	private ParticleSystem.ShapeModule shape_paticle;

	void Start () {
		particle = GetComponent<ParticleSystem> ();
		shape_paticle = particle.shape;
	}

	void Update () {
		Vector3 pos = shape_paticle.position;
		pos.x = inner.position.x;
		pos.y = inner.position.y;
		pos.z = inner.position.z;
		shape_paticle.position = pos;
	}
}
