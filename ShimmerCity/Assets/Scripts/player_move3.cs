using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move3 : MonoBehaviour {

	enum direction {right_dir,left_dir,up_dir,down_dir};

	public float vel_x=6.0f;
	public float vel_x_in_air=3.0f;
	public float push_v = 1.2f;
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

	void Start () {
		player_rigidbody = this.GetComponent<Rigidbody2D> ();
		player_animator = this.GetComponent<Animator> ();
		player_boxcollider=this.GetComponent<CapsuleCollider2D>();
		player_Scale = transform.localScale;
		velocity = player_rigidbody.velocity;
		player_rigidbody.freezeRotation = true;
		counter_close_range_attack = 0;
		counter_far_distance_attack = 0;
		start_time = Time.time;
	}

	void Update () {
		float h=Input.GetAxis("Horizontal");
		timer = true;
		speed_up = (isGround == true ? false : true);
		if (alive) {
			if (h > 0.01f) {
				if (!isLadder && !isGround && speed_up) {
					Vector3 pos = transform.position;
					pos.x += Time.deltaTime * vel_x_in_air;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = vel_x_in_air;
					player_rigidbody.velocity = vel;
				} else if ( isLadder && !isGround) {
					Vector3 pos = transform.position;
					pos.x += Time.deltaTime * 0.2f;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = 0.2f;
					player_rigidbody.velocity = vel;
				} else if(isGround && isPush){
					Vector3 pos = transform.position;
					pos.x += Time.deltaTime * push_v;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = push_v;
					player_rigidbody.velocity = vel;
				} else {
					Vector2 vel = player_rigidbody.velocity;
					float vx = Time.deltaTime * vel_x;
					vel.x = (vx >= vel_x ? vel_x : vx);
					player_rigidbody.velocity = vel;
				}
				player_Scale.x = Mathf.Abs (player_Scale.x);
				transform.localScale = player_Scale;
				timer = false;
			} else if (h < -0.01f) {
				if (!isLadder && !isGround && speed_up) {
					Vector3 pos = transform.position;
					pos.x -= Time.deltaTime * vel_x_in_air;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = -vel_x_in_air;
					player_rigidbody.velocity = vel;
				} else if (isLadder && !isGround) {
					Vector3 pos = transform.position;
					pos.x -= Time.deltaTime * 0.2f;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = -0.2f;
					player_rigidbody.velocity = vel;
				} else if(isGround && isPush){
					Vector3 pos = transform.position;
					pos.x -= Time.deltaTime * push_v;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = -push_v;
					player_rigidbody.velocity = vel;
				} else {
					Vector2 vel = player_rigidbody.velocity;
					float vx = Time.deltaTime * vel_x;
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
				if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D))
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

			if (isGround && Input.GetKey(KeyCode.J)) {
				close_range_attack = true;
				far_distance_attack = false;
				counter_close_range_attack++;
				if (counter_far_distance_attack > 0) {
					attack_transform = true;
					counter_far_distance_attack = 0;
				}
				timer = false;
				BroadcastMessage ("SetCloseAttack", true);
				BroadcastMessage ("SetFurtherAttack", false);
			}
			if (isGround && Input.GetKey(KeyCode.K)) {
				far_distance_attack = true;
				close_range_attack = false;
				counter_far_distance_attack++;
				if (counter_close_range_attack > 0) {
					attack_transform = true;
					counter_close_range_attack = 0;
				}
				timer = false;
				BroadcastMessage ("SetCloseAttack", false);
				BroadcastMessage ("SetFurtherAttack", true);
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

	public void OnCollisionEnter2D(Collision2D col){

	}

	public void OnCollisionStay2D(Collision2D col){

	}

	public void OnCollisionExit2D(Collision2D col){

	}


}