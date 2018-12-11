using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick_handler : MonoBehaviour {

	public double number;

	private double show_time=7.0f;
	private double disappear_time=3.0f;

	private double time_index;
	private double period;
	private double used_time;
	private double real_time;

	private double index_time;
	private bool change_index;

	private SpriteRenderer brick_sprite;
	private BoxCollider2D brick_collider;
	System.Random time;

	void Start () {
		brick_sprite = GetComponent<SpriteRenderer> ();
		brick_sprite.sortingOrder = -2;
		brick_collider = GetComponent<BoxCollider2D> ();
		brick_collider.isTrigger = true;
		period = show_time + disappear_time;
		time = new System.Random ();
		used_time = Time.time;
		change_index = true;
	}
	void Update () {
		if (change_index) {
			time_index = time.NextDouble () * period/2+number;
			change_index = false;
		}
		real_time = Time.time;
		index_time = real_time - used_time + time_index;
		if (index_time > period) {
			change_index = true;
			index_time -= period;
			used_time = real_time;
		}
		if (index_time >= 0.0f && index_time <= show_time) {
			brick_sprite.sortingOrder = 0;
			brick_collider.isTrigger = false;
		} else if (index_time >= show_time && index_time < period) {
			brick_sprite.sortingOrder = -2;
			brick_collider.isTrigger = true;
		}
		//Debug.Log (time_index);
	}
}
