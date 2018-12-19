using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move3 : MonoBehaviour {

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
	}

	void Update () {
		//float h=Input.GetAxis("Horizontal");
		timer = true;
		speed_up = (isGround == true ? false : true);
		if (alive) {
			if (Input.GetKey(KeyCode.D)) {
				if (!isLadder && !isGround && speed_up) {
					Vector3 pos = transform.position;
					pos.x += Time.deltaTime * vel_x_in_air;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = vel_x_in_air;
					player_rigidbody.velocity = vel;
				} else if ( isLadder && !isGround) {
					Vector3 pos = transform.position;
					pos.x += Time.deltaTime * ladder_v;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = ladder_v;
					player_rigidbody.velocity = vel;
				} else if(isGround && isPush){
					Vector3 pos = transform.position;
					pos.x += Time.deltaTime * push_v;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = push_v;
					player_rigidbody.velocity = vel;
				} else if(!isLadder){
					player_rigidbody.AddForce (10*Vector2.right * pushmove);
					float vx = player_rigidbody.velocity.x;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = (vx >= vel_x ? vel_x : vx);
					player_rigidbody.velocity = vel;
				}
				player_Scale.x = Mathf.Abs (player_Scale.x);
				transform.localScale = player_Scale;
				timer = false;
			} else if (Input.GetKey(KeyCode.A)) {
				if (!isLadder && !isGround && speed_up) {
					Vector3 pos = transform.position;
					pos.x -= Time.deltaTime * vel_x_in_air;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = -vel_x_in_air;
					player_rigidbody.velocity = vel;
				} else if (isLadder && !isGround) {
					Vector3 pos = transform.position;
					pos.x -= Time.deltaTime * ladder_v;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = -ladder_v;
					player_rigidbody.velocity = vel;
				} else if(isGround && isPush){
					Vector3 pos = transform.position;
					pos.x -= Time.deltaTime * push_v;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = -push_v;
					player_rigidbody.velocity = vel;
				} else if(!isLadder){
					player_rigidbody.AddForce (10*Vector2.left * pushmove);
					float vx = Mathf.Abs(player_rigidbody.velocity.x);
					Vector2 vel = player_rigidbody.velocity;
					vel.x = -(vx >= vel_x ? vel_x : vx);
					player_rigidbody.velocity = vel;
				}
				player_Scale.x = -Mathf.Abs (player_Scale.x);
				transform.localScale = player_Scale;
				timer = false;
			}

			if (isLadder && isGround) {
				isLadder = false;
			}

			if (isLadder) {
				if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S))
					player_animator.speed = 1.0f;
				else
					player_animator.speed = 0.0f;
			} else {
				player_animator.speed = 1.0f;
			}

			if (isGround && Input.GetKeyDown (KeyCode.Space)) {
				player_rigidbody.AddForce (Vector2.up*100*jumpVelocity);
				speed_up = true;
				timer = false;
			}

			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("hammer_in_attack").GetComponent<Collider2D> (), player_boxcollider);
			if (isGround && Input.GetKey(KeyCode.J)) {
				close_range_attack = true;
				far_distance_attack = false;
				counter_close_range_attack=1;
				if (counter_far_distance_attack > 0) {
					attack_transform = true;
					counter_far_distance_attack = 0;
				}
				timer = false;
				BroadcastMessage ("SetCloseAttack", true);
				BroadcastMessage ("SetFurtherAttack", false);
			}
			if (isGround && Input.GetKeyDown(KeyCode.K)) {
				far_distance_attack = true;
				close_range_attack = false;
				counter_far_distance_attack=1;
				if (counter_close_range_attack > 0) {
					attack_transform = true;
					counter_close_range_attack = 0;
				}
				timer = false;
				BroadcastMessage ("SetCloseAttack", false);
				BroadcastMessage ("SetFurtherAttack", true);
				if(player_Scale.x>0.0f)
					BroadcastMessage ("SetPlayerDir", true);
				else
					BroadcastMessage ("SetPlayerDir", false);
			}
			close_range_attack=(counter_close_range_attack>0.0f?true:false);
			far_distance_attack=(counter_far_distance_attack>0.0f?true:false);
			if (close_range_attack)
				counter_close_range_attack--;
			if (far_distance_attack)
				counter_far_distance_attack--;
			//for test
			if (Input.GetKey (KeyCode.Q)) {
				alive = false;
				player_boxcollider.isTrigger = true;
				player_rigidbody.gravityScale = -10;
				Destroy (gameObject, 2);
				timer = false;
			}

			if (Input.GetKeyDown (KeyCode.L)&&skill_counter==0) {
				timer_for_triple=true;
				timer_for_skill = Time.time;
			}

			if(timer_for_triple){
				if (skill_counter < 3) {
					float now_timer = Time.time;
					if (now_timer - timer_for_skill >= skill_time) {
						GameObject skill_hammer = Instantiate (Resources.Load ("prefabs/skill_L")) as GameObject;
						Physics2D.IgnoreCollision (player_boxcollider, skill_hammer.GetComponent<Collider2D> ());
						foreach (Collider2D col in GetComponentsInChildren<Collider2D>())
							Physics2D.IgnoreCollision (col, skill_hammer.GetComponent<Collider2D> ());
						skill_counter++;
						timer_for_skill = now_timer;
					}
				} else {
					timer_for_triple = false;
					skill_counter = 0;
				}
			}

			if (Input.GetKeyDown (KeyCode.U)) {
				if(!ProtectLayer)
					ProtectLayer = Instantiate (Resources.Load ("prefabs/Protect")) as GameObject;
				BroadcastMessage ("SetProtectLayer",true);
			}

			if (Input.GetKeyDown (KeyCode.I)) {
				if (ProtectLayer)
					Destroy (ProtectLayer);
				BroadcastMessage ("SetProtectLayer",false);
			}

			if (Input.GetKeyDown (KeyCode.C)) {
				GameObject win_the_game = Instantiate (Resources.Load ("prefabs/Win")) as GameObject;
			}

			if (timer && isGround) {
				float delttime = Time.time - start_time;
				if (delttime > 5.0f) {
					five_minutes = true;
					player_animator.SetBool ("five_minutes", five_minutes);
				} else {
					five_minutes = false;
					player_animator.SetBool ("five_minutes", five_minutes);
				}
			} else {
				start_time = Time.time;
				five_minutes = false;
				player_animator.SetBool ("five_minutes", five_minutes);
			}
		} else {
			if (Input.GetKeyDown (KeyCode.R)) {
				gameexit = true;	
				//Debug.Log ("game is over!");
			}
		}
		player_animator.SetFloat ("velocity_x",Mathf.Abs(player_rigidbody.velocity.x));
		player_animator.SetFloat ("velocity_y",player_rigidbody.velocity.y);
		player_animator.SetBool ("close_attack",close_range_attack);
		player_animator.SetBool ("far_attack",far_distance_attack);
		//player_animator.SetBool ("alive",alive);
		//player_animator.SetBool ("gameexit",gameexit);
		player_animator.SetBool ("isGround",isGround);
		player_animator.SetBool ("five_minutes",five_minutes);
		player_animator.SetBool ("isPush",isPush);
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

	public void HammerMessage(){
		hammer.SendMessage ("SetPos",hammer_transform.position);
		hammer.SendMessage ("SetVel",hammer_rigidbody.velocity);
		hammer.SendMessage ("SetRot",hammer_transform.rotation);
		hammer.SendMessage ("SetSca",hammer_transform.localScale);
	}

	public void OnCollisionEnter2D(Collision2D col){

	}

	public void OnCollisionStay2D(Collision2D col){

	}

	public void OnCollisionExit2D(Collision2D col){

	}


}