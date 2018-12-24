using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class player_move2 : MonoBehaviour {

	enum direction {right_dir,left_dir,up_dir,down_dir};

	public float vel_x=6.0f;
	public float vel_x_in_air=3.0f;
	public float vel_x_on_pipe = 1.2f;
	private Rigidbody2D player_rigidbody;
	private CapsuleCollider2D player_boxcollider;
	private Animator player_animator;
	private Vector3 player_Scale;
	private Vector2 velocity;

	public float force_move=70;
	public float jumpVelocity=170;

	private bool isGround = true;
	private bool isPipe = false;
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

	GameObject hammer;
	Transform hammer_transform;
	Rigidbody2D hammer_rigidbody;

	private float player_health;

	public float skill_time;
	private float timer_for_skill;
	private bool timer_for_triple;
	private int skill_counter;
	private bool skill_L = false;
	private bool sister_skill = false;

	private bool moveable;

	private bool Onstone;

	void Start () {
		player_rigidbody = this.GetComponent<Rigidbody2D> ();
		player_animator = this.GetComponent<Animator> ();
		player_boxcollider=this.GetComponent<CapsuleCollider2D>();
		player_Scale = transform.localScale;
		velocity = player_rigidbody.velocity;
		player_rigidbody.freezeRotation = true;
		hammer_transform = transform.Find("Hammer_for_attack");
		hammer = GameObject.Find("Hammer_for_attack");
		hammer_rigidbody = hammer.GetComponent<Rigidbody2D> ();
		counter_close_range_attack = 0;
		counter_far_distance_attack = 0;
		start_time = Time.time;
		player_health = 100.0f;

		moveable = true;

		Onstone = false;
	}

	void Update () {
		//Debug.Log (player_health);
		//float h=Input.GetAxis("Horizontal");
		timer = true;
		speed_up = (isGround == true ? false : true);
		if (alive) {
			if (moveable&&(Input.GetKey(KeyCode.D)||(Input.GetKey(KeyCode.RightArrow))) && !close_range_attack && !far_distance_attack) {
				if (!isPipe && !isGround && speed_up) {
					Vector3 pos = transform.position;
					pos.x += Time.deltaTime * vel_x_in_air;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = vel_x_in_air;
					player_rigidbody.velocity = vel;
				} else {
					player_rigidbody.AddForce (10*Vector2.right * force_move);
					float vx = player_rigidbody.velocity.x;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = (vx >= vel_x ? vel_x : vx);
					player_rigidbody.velocity = vel;
				}
				player_Scale.x = Mathf.Abs (player_Scale.x);
				transform.localScale = player_Scale;
				timer = false;
			} else if (moveable && (Input.GetKey(KeyCode.A)||(Input.GetKey(KeyCode.LeftArrow))) && !close_range_attack && !far_distance_attack) {
				if (!isPipe && !isGround && speed_up) {
					Vector3 pos = transform.position;
					pos.x -= Time.deltaTime * vel_x_in_air;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = -vel_x_in_air;
					player_rigidbody.velocity = vel;
				}  else {
					player_rigidbody.AddForce (10*Vector2.left * force_move);
					float vx = Mathf.Abs(player_rigidbody.velocity.x);
					Vector2 vel = player_rigidbody.velocity;
					vel.x = -(vx >= vel_x ? vel_x : vx);
					player_rigidbody.velocity = vel;
				}
				player_Scale.x = -Mathf.Abs (player_Scale.x);
				transform.localScale = player_Scale;
				timer = false;
			} 

			if (isGround && Input.GetKeyDown(KeyCode.Space)) {
				player_rigidbody.AddForce (Vector2.up*100*jumpVelocity);
				speed_up = true;
				timer = false;
			}
			 
			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("hammer_in_attack").GetComponent<Collider2D> (), player_boxcollider);
			if (isGround && Input.GetKeyDown(KeyCode.J)) {
				moveable = false;
				close_range_attack = true;
				far_distance_attack = false;
				counter_close_range_attack++;
				//counter_close_range_attack=1;
				player_animator.SetInteger("counter_close_range_attack",counter_close_range_attack);
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

			if (isGround && Input.GetKeyDown (KeyCode.L)&&skill_counter==0) {
				timer_for_triple=true;
				timer_for_skill = Time.time;
				timer = false;
				skill_L = true;
			}

			if(Input.GetKeyDown(KeyCode.P) && Fpbar_controller.Instance.bisFull == true)
			{
				Fpbar_controller.Instance.ReleaseSkill();
				sister_skill = true;
			}

			if(timer_for_triple){
				if (skill_counter < 3) {
					float now_timer = Time.time;
					if (now_timer - timer_for_skill >= skill_time) {
						GameObject skill_hammer = Instantiate (Resources.Load ("prefabs/skill_L_2")) as GameObject;
						Physics2D.IgnoreCollision (player_boxcollider, skill_hammer.GetComponent<Collider2D> ());
						foreach (Collider2D col in GetComponentsInChildren<Collider2D>())
							Physics2D.IgnoreCollision (col, skill_hammer.GetComponent<Collider2D> ());
						skill_counter++;
						timer_for_skill = now_timer;
					}
				} else {
					timer_for_triple = false;
					skill_L = false;
					skill_counter = 0;
				}
				timer = false;
			}
				
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
		player_animator.SetInteger("counter_close_range_attack",counter_close_range_attack);
		player_animator.SetBool ("skill_L",skill_L);
		if (!isGround)
			player_rigidbody.gravityScale = 15;
		else 
			player_rigidbody.gravityScale = 10;

		if (Onstone)
			player_rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
		else
			player_rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
	}
		
	void Setmove(){
		moveable = true;
		player_rigidbody.velocity = new Vector3 (0.0f, -1.0f, 0.0f);
	}

	void SetStone(bool flag){
		Onstone = flag;
	}

	void SetGround(bool flag){
		isGround = flag;
		player_animator.SetBool ("isGround",flag);
	}

	void SetPipe(bool flag){
		isPipe = flag;
	}

	void SetEnemy(bool flag){
		enemy_check = flag;
	}

	void PlayerDecreaseHP(float harm_blood){
		player_health -= harm_blood;
	}

	public void HammerMessage(){
		hammer.SendMessage ("SetPos",hammer_transform.position);
		hammer.SendMessage ("SetVel",hammer_rigidbody.velocity);
		hammer.SendMessage ("SetRot",hammer_transform.rotation);
		hammer.SendMessage ("SetSca",hammer_transform.localScale);
	}

	public void OnCollisionEnter2D(Collision2D col){
		if(col.collider.tag == "Pipe" ){
		}
		if(col.collider.tag == "Rock" ){
			//hp--;
		}
		if(col.collider.tag == "stone_stand" ){
			Physics2D.IgnoreCollision (col.collider,GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> ());
		}

	}

	public void OnCollisionStay2D(Collision2D col){
		if(col.collider.tag == "Pipe" ){
		}
		if(col.collider.tag == "stone_stand" ){
			Physics2D.IgnoreCollision (col.collider,GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> ());
		}

	}

	public void OnCollisionExit2D(Collision2D col){
		if(col.collider.tag == "stone_stand" ){
			Physics2D.IgnoreCollision (col.collider,GameObject.FindGameObjectWithTag ("Feet").GetComponent<Collider2D> (),false);
		}
	}


}