using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_player : MonoBehaviour {

	enum direction {right_dir,left_dir,up_dir,down_dir};

	public float vel_x=6.0f;
	public float vel_x_in_air=3.0f;
	public float push_v = 1.2f;
	public float ladder_v=0.2f;
	public float pushmove=70.0f;
	public float jumpVelocity=170;
	private Rigidbody2D player_rigidbody;
	private CapsuleCollider2D player_boxcollider;
	private Animator player_animator;
	private Vector3 player_Scale;
	private Vector2 velocity;

	private bool isGround = true;
	private bool isLadder = false;
	private bool isPush = false;
	private bool alive=true;
	private bool close_range_attack=false;
	private bool far_distance_attack=false;
	private float velocity_x;
	private float velocity_y;
	private bool five_minutes=false;

	private int counter_close_range_attack;
	private int counter_far_distance_attack;
	private bool attack_transform = false;//for further use

	private bool gameexit=false;

	private bool timer = false;
	private float start_time;

	private bool speed_up=false;

	private bool enemy_check=false;

	private GameObject ProtectLayer;

	public float skill_time;
	private float timer_for_skill;
	private bool timer_for_triple;
	private int skill_counter;

	GameObject hammer;
	Transform hammer_transform;
	Rigidbody2D hammer_rigidbody;

	private float player_health;

	private bool shield;
	private bool in_shield;
	private float shield_timer;
	private float shield_now_timer;
	public float shield_functimer;

	private GameObject target_boss;
	private Transform target_boss_transform;

	enum location_hor{left,right,near};
	enum location_ver{up,down};
	private bool stage;
	private location_hor AI_Location_hor;
	private location_ver AI_Location_ver;
	private float area_attack;

	private float player_speed; 
	private Vector3 player_positon;
	private Vector2 player_velocity;
	private float close_attack_timer;
	private bool AI_attack;
	private bool init_close_attack;
	private int AI_count;

	private bool isAttack;
	private float Away_timer;

	private bool move;

	private float attacked_timer;
	private bool attacked;
	private Color used_color;

	private bool shake;
	private float shake_timer;


	void Start () {
		player_rigidbody = this.GetComponent<Rigidbody2D> ();
		player_animator = this.GetComponent<Animator> ();
		player_boxcollider=this.GetComponent<CapsuleCollider2D>();
		player_Scale = transform.localScale;
		velocity = player_rigidbody.velocity;
		player_rigidbody.freezeRotation = true;
		counter_close_range_attack = 0;
		counter_far_distance_attack = 0;
		hammer_transform = transform.Find("Hammer_for_attack");
		hammer = GameObject.Find("Hammer_for_attack");
		hammer_rigidbody = hammer.GetComponent<Rigidbody2D> ();
		start_time = Time.time;
		timer_for_skill = Time.time;
		timer_for_triple = false;
		skill_counter = 0;
		player_health = 100.0f;
		shield = false;
		in_shield = false;

		target_boss = GameObject.Find ("boss");
		target_boss_transform = target_boss.transform;
		stage = true;
		AI_Location_hor = location_hor.left;
		AI_Location_ver = location_ver.up;
		area_attack = 2.2f;
		player_speed = 6.0f;
		AI_attack = true;
		init_close_attack=false;
		AI_count = 0;
		isAttack = false;
		move = true;

		alive = true;
		used_color = GetComponent<Renderer> ().material.color;
	}
		
	private location_hor AI_location_horcheck(){
		if (transform.position.x < target_boss_transform.position.x - area_attack)
			return location_hor.left;
		else if (transform.position.x > target_boss_transform.position.x + area_attack)
			return location_hor.right;
		else
			return location_hor.near;
	}

	private location_ver AI_location_vercheck(){
		if (transform.position.y > target_boss_transform.position.y + area_attack) 
			return location_ver.up;
		else
			return location_ver.down;
	}

	public void SetMove(){
		move=true;
	}

	public void SetCount(){
		AI_count++;
	}

	void FixedUpdate () {
		AI_Location_hor = AI_location_horcheck ();
		AI_Location_ver = AI_location_vercheck ();
		if (alive) {
			if (stage) {
				if (move && !isAttack && AI_Location_hor == location_hor.left) {
					if (!isPush) {
						player_positon = transform.position;
						player_positon.x += player_speed * Time.deltaTime;
						transform.position = player_positon;
						player_velocity = player_rigidbody.velocity;
						player_velocity.x = 6.0f;
						player_rigidbody.velocity = player_velocity;
					} else {
						player_positon = transform.position;
						player_positon.x += Time.deltaTime * push_v;
						transform.position = player_positon;
						player_velocity = player_rigidbody.velocity;
						player_velocity.x = push_v;
						player_rigidbody.velocity = player_velocity;
					}
					player_Scale.x = Mathf.Abs (player_Scale.x);
					transform.localScale = player_Scale;
				} else if (move && !isAttack && AI_Location_hor == location_hor.right) {
					if (!isPush) {
						player_positon = transform.position;
						player_positon.x -= player_speed * Time.deltaTime;
						transform.position = player_positon;
						player_velocity = player_rigidbody.velocity;
						player_velocity.x = -6.0f;
						player_rigidbody.velocity = player_velocity;
					} else {
						player_positon = transform.position;
						player_positon.x -= Time.deltaTime * push_v;
						transform.position = player_positon;
						player_velocity = player_rigidbody.velocity;
						player_velocity.x = push_v;
						player_rigidbody.velocity = player_velocity;
					}
					player_Scale.x = -Mathf.Abs (player_Scale.x);
					transform.localScale = player_Scale;
				} else if (!isAttack && AI_Location_hor == location_hor.near) {
					if (AI_Location_ver == location_ver.up) {
						Debug.Log ("here attack?");

					} else {
						if (!AI_attack && !init_close_attack) {
							close_attack_timer = Time.time;
							init_close_attack = true;
							player_animator.SetBool ("close_attack", AI_attack);
						}
						if (init_close_attack) {
							if (Time.time - close_attack_timer >= 0.2f) {
								AI_attack = true;
								init_close_attack = false;
							}
						}
						if (AI_attack) {
							player_velocity = player_rigidbody.velocity;
							player_velocity.x = 0.0f;
							player_rigidbody.velocity = player_velocity;
							move = false;
							player_animator.Play ("close_attack");
							if (AI_count >= 1) {
								isAttack = true;
								AI_attack = false;
								AI_count = 0;
								Away_timer = Time.time;
							}
						}
					}
				} else if (isAttack && Time.time - Away_timer <= 1.5f) {
					if (transform.position.x < target_boss_transform.position.x) {
						player_positon = transform.position;
						player_positon.x -= player_speed * Time.deltaTime;
						transform.position = player_positon;
						player_velocity = player_rigidbody.velocity;
						player_velocity.x = -6.0f;
						player_rigidbody.velocity = player_velocity;
						player_Scale.x = -Mathf.Abs (player_Scale.x);
						transform.localScale = player_Scale;
					} else if (transform.position.x > target_boss_transform.position.x) {
						player_positon = transform.position;
						player_positon.x += player_speed * Time.deltaTime;
						transform.position = player_positon;
						player_velocity = player_rigidbody.velocity;
						player_velocity.x = 6.0f;
						player_rigidbody.velocity = player_velocity;
						player_Scale.x = Mathf.Abs (player_Scale.x);
						transform.localScale = player_Scale;
					}
				} 

				if (isAttack && (Time.time - Away_timer) * 6.0f >= 7.5f && Time.time - Away_timer <= 4.0f) {
					player_positon = transform.position;
					player_positon.x += 0.0f;
					transform.position = player_positon;
					player_velocity = player_rigidbody.velocity;
					player_velocity.x = 0.0f;
					player_rigidbody.velocity = player_velocity;
				} else if (isAttack && Time.time - Away_timer > 4.0f) {
					isAttack = false;
					move = true;
				}

				if (Input.GetKey (KeyCode.Q)||player_health<0.0f) {
					alive = false;
					timer = false;
				}

				if (attacked) {
					if (Time.time - attacked_timer >= 0.2f) {
						GetComponent<Renderer> ().material.color = used_color;
						attacked = false;
					}
				}

				if (shake) {
					shake_timer = Time.time;
					float in_attack_time = shake_timer - attacked_timer;
					if (in_attack_time <= 2.0f) {
						if (((int)(shake_timer * 10))%2==1)
							GetComponent<Renderer> ().enabled = true;
						else
							GetComponent<Renderer> ().enabled = false;
					} else
						shake = false;
				} else {
					GetComponent<Renderer> ().enabled = true;
				}


			} else {


			}


			if (Input.GetKey (KeyCode.Q)||player_health<0.0f) {
				alive = false;
				timer = false;
			}
		}

		player_animator.SetFloat ("vel_x",Mathf.Abs(player_rigidbody.velocity.x));
		player_animator.SetBool ("close_attack",AI_attack);
		player_animator.SetBool ("isGround",isGround);
		player_animator.SetBool ("five_minutes",five_minutes);
		player_animator.SetBool ("isPush",isPush);
		player_animator.SetBool ("alive",alive);

	}

	void PlayerDecreaseHP(float harm_blood){
		player_health -= harm_blood;
		GetComponent<Renderer> ().material.color = new Color (0, 255, 255);
		attacked = true;
		attacked_timer = Time.time;
		shake = true;
	}

	void Drop_the_hammer(){
		GameObject flying_hammer_instance = Instantiate (Resources.Load ("prefabs/flying_hammer2"), hammer_transform.position,hammer_transform.rotation) as GameObject;
		Transform flying_hammer_transform = flying_hammer_instance.GetComponent<Transform> ();
		flying_hammer_transform.localScale = new Vector3(0.3f,0.3f,0.3f);
	}


	void SetGround(bool flag){
		isGround = flag;
		player_animator.SetBool ("isGround",flag);
	}

	void SetInLadder(bool flag){
		isLadder = flag;
		timer = false;
		player_animator.SetBool ("isLadder",flag);
	}

	void SetPush(bool flag){
		isPush = flag;
		Vector2 vel = player_rigidbody.velocity;
		vel.x = 0.0f;
		player_rigidbody.velocity = vel;
		player_animator.SetBool ("isPush",flag);
	}

	void SetEnemy(bool flag){
		enemy_check = flag;
	}

	void SetShield(bool flag){
		shield = true;
	}
		
	public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "b0ss_hand") {
			player_health -= 1.0f;
			GetComponent<Renderer> ().material.color = new Color (0, 255, 255);
			attacked = true;
			attacked_timer = Time.time;
			shake = true;
			Debug.Log ("boss_hand1");
		}else if (col.collider.tag == "boss_tentacle") {
			player_health -= 2.0f;
			GetComponent<Renderer> ().material.color = new Color (0, 255, 255);
			attacked = true;
			attacked_timer = Time.time;
			shake = true;
			Debug.Log ("boss_tentacle1");
		}
	}
		
}