using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick_handler : MonoBehaviour {

	public double number;

	private double show_time=7.0f;
	private double disappear_time=3.0f;

	private double time_index;
	private double period;

	private float used_time;
	private float real_time;

	private float index_time;

	private bool change_index;

	private SpriteRenderer brick_sprite;
	private BoxCollider2D brick_collider;
	System.Random time;

	public int level;
	public int index;
	public float build_timer=3.0f;
	public float show_timer=15.0f;
	public float disappear_timer=2.0f;
	public bool tag_for_delta;
	private float total_period;
	private float base_timer;
	private float offset_timer;

	void Start () {
		brick_sprite = GetComponent<SpriteRenderer> ();
		brick_sprite.sortingOrder = -2;
		brick_collider = GetComponent<BoxCollider2D> ();
		brick_collider.isTrigger = true;
		period = show_time + disappear_time;
		time = new System.Random ();
		change_index = true;
		total_period = build_timer + show_timer + disappear_timer;
		used_time = (tag_for_delta==false?Time.time:Time.time+total_period);
		base_timer = (level - 1) * build_timer;
		offset_timer =(index - 1) * build_timer / 3;
	}
	void Update () {  
		/*if (change_index) {
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
		}*/

		real_time = Time.time;
		index_time = real_time - used_time;
		if (index_time > total_period) {
			index_time -= total_period;
			used_time = real_time;
		}
		if(index_time>=base_timer + offset_timer && index_time<base_timer+build_timer+show_timer){
			brick_sprite.sortingOrder = 0;
			brick_collider.isTrigger = false;
		} else if ((index_time >= base_timer+build_timer+show_timer && index_time < total_period)||(index_time<base_timer + offset_timer)) {
			brick_sprite.sortingOrder = -2;
			brick_collider.isTrigger = true;
		} 
	}
}