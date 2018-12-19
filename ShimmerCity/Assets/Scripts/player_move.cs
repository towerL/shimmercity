using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour {

	enum direction {right_dir,left_dir,up_dir,down_dir};
	private Rigidbody2D player_rigidbody;
	//private BoxCollider2D player_boxcollider;
	private CapsuleCollider2D player_boxcollider;
	private Animator player_animator;
	private Vector3 player_Scale;
	private Vector2 velocity;

	private float horizontal;
	private float vertical;
	private float move;

	public float force_move=70;
	public float jumpVelocity=170;

	private bool isGround = true;
	private bool isWall = false;
	private bool isLadder=false;
	private bool isHammer=true;
	//private bool isHammer=false;
	private bool isSister=true;
	//private bool isSister=false;
	private bool alive=true;
	private bool close_range_attack=false;
	private bool far_distance_attack=false; 
	private bool isStand = true;
	private bool isWalk = false;
	private bool isRun = false;
	private bool isBelt = false;
	private float velocity_x;
	private float velocity_y;
	private bool five_minutes=false;
	private bool isPush=false;

	private direction used_direction =direction.right_dir;
	private direction now_direction;
	private bool face_turned=false;

	private bool double_click = false;

	private int counter_close_range_attack;
	private int counter_far_distance_attack;
	private bool attack_transform = false;//for further use

	private bool gameexit=false;

	private bool timer = false;
	private float start_time;

	private bool speed_up=false;

	private bool enemy_check=false;

	private bool beltflag;
	private float beltdir;

	GameObject hammer;
	Transform hammer_transform;
	Rigidbody2D hammer_rigidbody;

	public float skill_time;
	private float timer_for_skill;
	private bool timer_for_triple;
	private int skill_counter;

	void Start () {
		player_rigidbody = this.GetComponent<Rigidbody2D> ();
		player_animator = this.GetComponent<Animator> ();
		//player_boxcollider = this.GetComponent<BoxCollider2D> ();
		player_boxcollider=this.GetComponent<CapsuleCollider2D>();
		hammer_transform = transform.Find("Hammer_for_attack");
		hammer = GameObject.Find("Hammer_for_attack");
		hammer_rigidbody = hammer.GetComponent<Rigidbody2D> ();
		player_Scale = transform.localScale;
		velocity = player_rigidbody.velocity;
		player_rigidbody.freezeRotation = true;
		//player_boxcollider.offset=new Vector2(0.0f,-0.1f);
		counter_close_range_attack = 0;
		counter_far_distance_attack = 0;
		start_time = Time.time;
		timer_for_skill = Time.time;
		timer_for_triple = false;
		skill_counter = 0;
	}

	void Update () {
		float h=Input.GetAxis("Horizontal");
		timer = true;
		speed_up = (isGround == true ? false : true);
		if (alive) {
			if (h > 0.01f && !close_range_attack && !far_distance_attack) {
				if (!isBelt && !isPush && isGround)
					player_rigidbody.AddForce (Vector2.right * force_move);
				else if (!isPush && isGround) {
					Vector3 pos = transform.position;
					pos.x += Time.deltaTime * 1.25f;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = 1.25f;
					player_rigidbody.velocity = vel;
				} else if (isPush && isGround) {
					Vector3 pos = transform.position;
					pos.x += Time.deltaTime * 1.2f;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = 1.2f;
					player_rigidbody.velocity = vel;
				} else if (!isLadder && !isGround && speed_up) {
					Vector3 pos = transform.position;
					pos.x += Time.deltaTime * 6.0f;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = 6.0f;
					player_rigidbody.velocity = vel;
				} /*else if ( isLadder && !isGround) {
					Vector3 pos = transform.position;
					pos.x += 0;//Time.deltaTime * 0.2f;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = 0;//p00.2f;;
					player_rigidbody.velocity = vel;
				}*/
				player_Scale.x = Mathf.Abs (player_Scale.x);
				transform.localScale = player_Scale;
				now_direction = direction.right_dir;
				timer = false;
			} else if (h < -0.01f && !close_range_attack && !far_distance_attack) {
				if (!isBelt && !isPush && isGround)
					player_rigidbody.AddForce (-Vector2.right * force_move);
				else if (!isPush && isGround) {
					Vector3 pos = transform.position;
					pos.x -= Time.deltaTime * 1.25f;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = -1.25f;
					player_rigidbody.velocity = vel;
				} else if (isPush && isGround) {
					Vector3 pos = transform.position;
					pos.x -= Time.deltaTime * 1.2f;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = -1.2f;
					player_rigidbody.velocity = vel;
				} else if (!isLadder && !isGround && speed_up) {
					Vector3 pos = transform.position;
					pos.x -= Time.deltaTime * 6.0f;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = -6.0f;
					player_rigidbody.velocity = vel;
				} else if (isLadder && !isGround) {
					Vector3 pos = transform.position;
					pos.x -= 0;//Time.deltaTime * 0.2f;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = 0;//-0.2f;
					player_rigidbody.velocity = vel;
				}
				player_Scale.x = -Mathf.Abs (player_Scale.x);
				transform.localScale = player_Scale;
				now_direction = direction.left_dir;
				timer = false;
			}
			face_turned = (used_direction == now_direction ? false : true);
			used_direction = now_direction;//further use

			Vector3 postrans = transform.position;
			if (isBelt && beltflag && beltdir > 0.0f) {	
				postrans.x += Time.deltaTime * 1.0f;
			}else if (isBelt && beltflag && beltdir < 0.0f) {	
				postrans.x -= Time.deltaTime * 1.0f;
			}/*else if (isBelt && !beltflag && beltdir > 0.0f) {	
				postrans.y += Time.deltaTime * 1.0f;
			}else if (isBelt && !beltflag && beltdir < 0.0f) {
				postrans.y -= Time.deltaTime * 1.0f;
			}*/
			transform.position = postrans;

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
				//Debug.Log ("player get the KeyCode Space,you will jump.");
				player_rigidbody.AddForce (Vector2.up*100*jumpVelocity);
				if (isWall) {
					player_rigidbody.gravityScale = 5;
				}
				speed_up = true;
				timer = false;
			}
				
			if (isGround && isHammer && Input.GetKeyDown(KeyCode.J)) {
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
				if (isHammer) {
					BroadcastMessage ("SetCloseAttack", true);
					BroadcastMessage ("SetFurtherAttack", false);
				}
			}
			//if (isGround && isHammer && Input.GetKeyUp (KeyCode.J))
			//	counter_close_range_attack = 0;
			if (isGround && isHammer && Input.GetKeyDown(KeyCode.K)) {
				far_distance_attack = true;
				close_range_attack = false;
				//counter_far_distance_attack++;
				counter_far_distance_attack=1;
				if (counter_close_range_attack > 0) {
					attack_transform = true;
					counter_close_range_attack = 0;
				}
				timer = false;
				if (isHammer) {
					BroadcastMessage ("SetCloseAttack", false);
					BroadcastMessage ("SetFurtherAttack", true);
				}
				if(player_Scale.x>0.0f)
					BroadcastMessage ("SetPlayerDir", true);
				else
					BroadcastMessage ("SetPlayerDir", false);
				//isHammer = false;
			}
			close_range_attack=(counter_close_range_attack>0.0f?true:false);
			far_distance_attack=(counter_far_distance_attack>0.0f?true:false);
			if (close_range_attack)
				counter_close_range_attack--;
			if (far_distance_attack)
				counter_far_distance_attack--;

			if (Input.GetKeyDown (KeyCode.L)&&skill_counter==0) {
				timer_for_triple=true;
				timer_for_skill = Time.time;
			}

			if(timer_for_triple){
				if (skill_counter < 3) {
					float now_timer = Time.time;
					if (now_timer - timer_for_skill >= skill_time) {
						GameObject skill_hammer = Instantiate (Resources.Load ("prefabs/skill_L_1")) as GameObject;
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

			//for test
			if (Input.GetKey (KeyCode.Q)) {
				alive = false;
				player_boxcollider.isTrigger = true;
				player_rigidbody.gravityScale = -10;
				Destroy (gameObject, 2);
				timer = false;
			}
				
			if (isHammer) {
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("hammer_in_attack").GetComponent<Collider2D> (), player_boxcollider);
			} else {
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("hammer_in_attack").GetComponent<Collider2D> (), player_boxcollider,false);
			}

			if (timer && !isLadder &&isGround && isHammer) {
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
				
			isStand=(Mathf.Abs(player_rigidbody.velocity.x)<0.1f?true:false) && !isPush && isGround;
			isWalk = (Mathf.Abs (player_rigidbody.velocity.x) > 0.1f && Mathf.Abs (player_rigidbody.velocity.x) < 1.3f ? true : false) && !isPush && isGround;
			isRun=(Mathf.Abs(player_rigidbody.velocity.x)>1.3f?true:false) && !isPush && isGround;


		} else {
			//Debug.Log ("the player is dead!");
			if (Input.GetKeyDown (KeyCode.R)) {
				gameexit = true;	
				//Debug.Log ("game is over!");
			}
		}

		player_animator.SetFloat ("horizontal", Mathf.Abs (h));
		player_animator.SetFloat ("vertical", player_rigidbody.velocity.y);
		player_animator.SetFloat ("velocity_x",Mathf.Abs(player_rigidbody.velocity.x));
		player_animator.SetFloat ("velocity_y",player_rigidbody.velocity.y);
		player_animator.SetBool ("close_range_attack",close_range_attack);
		player_animator.SetBool ("far_distance_attack",far_distance_attack);
		player_animator.SetBool ("isStand",isStand);
		player_animator.SetBool ("isWalk",isWalk);
		player_animator.SetBool ("isRun",isRun);
		player_animator.SetBool ("alive",alive);
		player_animator.SetBool ("gameexit",gameexit);
		player_animator.SetBool ("isGround",isGround);
		player_animator.SetBool ("isLadder",isLadder);
		player_animator.SetBool ("isHammer",isHammer);
		player_animator.SetBool ("isSister",isSister);
		player_animator.SetBool ("five_minutes",five_minutes);
		player_animator.SetBool ("isPush",isPush);
		player_animator.SetInteger("counter_close_range_attack",counter_close_range_attack);
	}

	private void doubleclick(){
		//todo
	}

	void SetInLadder(bool flag){
		isLadder = flag;
		timer = false;
		player_animator.SetBool ("isLadder",flag);
	}

	void SetIsHammer(bool flag){
		isHammer = flag;
		BroadcastMessage ("SetHammer", true);
		player_animator.SetBool ("isHammer",flag);
	}

	void SetSister(bool flag){
		isSister = flag;
		player_animator.SetBool ("isSister",flag);
	}

	void SetGround(bool flag){
		isGround = flag;
		player_animator.SetBool ("isGround",flag);
	}

	void SetPush(bool flag){
		isPush = flag;
		Vector2 vel = player_rigidbody.velocity;
		vel.x = 0.0f;//???
		player_rigidbody.velocity = vel;
		player_animator.SetBool ("isPush",flag);
	}

	void SetEnemy(bool flag){
		enemy_check = flag;
	}

	void SetBelt(bool flag){
		isBelt = flag;
	}

	void SetBeltFlag(bool flag){
		beltflag = flag;
		//Debug.Log (beltflag);
	}

	void SetBeltdir(float dir){
		beltdir = dir;
		//Debug.Log (beltdir);
	}

	public void HammerMessage(){
		hammer.SendMessage ("SetPos",hammer_transform.position);
		hammer.SendMessage ("SetVel",hammer_rigidbody.velocity);
		hammer.SendMessage ("SetRot",hammer_transform.rotation);
		hammer.SendMessage ("SetSca",hammer_transform.localScale);
	}

	/*(public void OnCollisionEnter2D(Collision2D col){
		if(col.collider.tag == "Ground" || col.collider.tag == "Box" || col.collider.tag == "Belt" || col.collider.tag == "Locker_sister"){
			isGround = true;
			player_rigidbody.gravityScale=30;
		}
		if (col.collider.tag == "Belt")
			isBelt = true;
		/*if (col.collider.tag == "Ladder") {
			//isLadder = true;
			//player_rigidbody.gravityScale = 0;
		}*/
		//will be used
		/*if(col.collider.tag == "Wall"){
			isWall = true;
			player_rigidbody.velocity=Vector2.zero;
			player_rigidbody.gravityScale=5;
		}*/
		/*if (col.collider.tag == "Enemy") {
			underattack=false;
		}
		player_animator.SetBool("attack",underattack);*/
		//player_animator.SetBool("isGround",isGround);
		//player_animator.SetBool ("isLadder",isLadder);
		//player_animator.SetBool("isWall",isWall);
	//}
	/*public void OnCollisionExit2D(Collision2D col){
		if(col.collider.tag=="Ground" || col.collider.tag == "Box" || col.collider.tag == "Belt" || col.collider.tag=="Locker_sister")
			isGround = false;
		if (col.collider.tag == "Belt")
			isBelt = false;
		/*if (col.collider.tag == "Ladder") {
			isLadder = false;
			player_rigidbody.gravityScale = 20;
		}*/
		//will be used
		/*if(col.collider.tag == "Wall"){
			isWall = false;
			player_rigidbody.gravityScale=30;
		}*/
		/*if (col.collider.tag == "Enemy") {
			underattack=false;
		}
		player_animator.SetBool("attack",underattack);*/
		//player_animator.SetBool("isGround",isGround);
		//player_animator.SetBool ("isLadder",isLadder);
		//anim.SetBool("isWall",isWall);
	//}


}
