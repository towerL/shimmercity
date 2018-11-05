using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class player_move : MonoBehaviour {

	enum direction {right_dir,left_dir,up_dir,down_dir};

	private Rigidbody2D player_rigidbody;
	private Animator player_animator;
	private Vector3 player_position;
	private Vector3 player_Scale;
	private Vector2 velocity;

	private float jumpForce;
	private float horizontal;
	private float vertical;
	private float moveSpeed;
	private float move;

	private float force_move=80;
	public float jumpVelocity=90;

	private bool isGround = true;
	private bool isWall = false;
	private bool isLadder=false;
	//private bool isHammer=true;
	private bool isHammer=false;
	private bool alive=true;
	private bool close_range_attack=false;
	private bool far_distance_attack=false;
	private float velocity_x;
	private float velocity_y;

	private direction used_direction =direction.right_dir;
	private direction now_direction;
	private bool face_turned=false;

	private bool double_click = false;

	private int counter_close_range_attack;
	private int counter_far_distance_attack;
	private bool attack_transform = false;//for further use

	private bool gameexit=false;

	void Start () {
		player_rigidbody = this.GetComponent<Rigidbody2D> ();
		player_animator = this.GetComponent<Animator> ();
		player_Scale = transform.localScale;
		velocity = player_rigidbody.velocity;
		player_position = transform.position;
		counter_close_range_attack = 0;
		counter_far_distance_attack = 0;
		jumpForce = 300f;
		moveSpeed = 5.5f;
	}

	void Update () {
		float h=Input.GetAxis("Horizontal");
		if (alive) {
			if (h > 0.01f) {
				player_rigidbody.AddForce (Vector2.right * force_move);
				player_Scale.x = Mathf.Abs (player_Scale.x);
				transform.localScale = player_Scale;
				now_direction = direction.right_dir;
			} else if (h < -0.01f) {
				player_rigidbody.AddForce (-Vector2.right * force_move);
				player_Scale.x = -Mathf.Abs (player_Scale.x);
				transform.localScale = player_Scale;
				now_direction = direction.left_dir;
			}
			face_turned = (used_direction == now_direction ? false : true);
			used_direction = now_direction;//further use
			if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.RightArrow))
				velocity.x = 0;
			if (isGround && Input.GetKeyDown (KeyCode.Space)) {
				Debug.Log ("player get the KeyCode Space");
				velocity.y = jumpVelocity;
				player_rigidbody.velocity = velocity;
				if (isWall) {
					player_rigidbody.gravityScale = 5;
				}
			}
			if (isGround && Input.GetKey(KeyCode.J)) {
				close_range_attack = true;
				far_distance_attack = false;
				counter_close_range_attack++;
				if (counter_far_distance_attack > 0) {
					attack_transform = true;
					counter_far_distance_attack = 0;
				}
			}
			/*if (isGround && Input.GetKeyUp (KeyCode.J)) {
				close_range_attack = false;
				far_distance_attack = false;
			}*/
			if (isGround && Input.GetKey(KeyCode.K)) {
				far_distance_attack = true;
				close_range_attack = false;
				counter_far_distance_attack++;
				if (counter_close_range_attack > 0) {
					attack_transform = true;
					counter_close_range_attack = 0;
				}
			}
			close_range_attack=(counter_close_range_attack>0?true:false);
			far_distance_attack=(counter_far_distance_attack>0?true:false);
			if (close_range_attack)
				counter_close_range_attack--;
			if (far_distance_attack)
				counter_far_distance_attack--;

			//for test
			if (Input.GetKey (KeyCode.Q))
				alive = false;

			//Debug.Log (counter_close_range_attack);
			/*if (isGround && Input.GetKeyUp (KeyCode.K)) {
				far_distance_attack = false;
				close_range_attack = false;
			}*/

		} else {
			Debug.Log ("the player is dead!");
			if (Input.GetKeyDown (KeyCode.R)) {
				gameexit = true;	
				Debug.Log ("game is over!");
			}
		}

		player_animator.SetFloat ("horizontal", Mathf.Abs (h));
		player_animator.SetFloat ("velocity_x",Mathf.Abs(player_rigidbody.velocity.x));
		player_animator.SetFloat ("velocity_y",player_rigidbody.velocity.y);
		//player_animator.SetFloat ("vertical", player_rigidbody.velocity.y);
		player_animator.SetBool ("close_range_attack",close_range_attack);
		player_animator.SetBool ("far_distance_attack",far_distance_attack);
		player_animator.SetBool ("alive",alive);
		player_animator.SetBool ("gameexit",gameexit);
		player_animator.SetBool ("isGround",isGround);
		player_animator.SetBool ("isWall",isWall);
		player_animator.SetBool ("isLadder",isLadder);
		player_animator.SetBool ("isHammer",isHammer);

	}

	private void doubleclick(){
		//todo
	}

	public void OnCollisionEnter2D(Collision2D col){
		if(col.collider.tag == "Ground"){
			isGround = true;
			player_rigidbody.gravityScale=30;
		}
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
		player_animator.SetBool("isGround",isGround);
		//player_animator.SetBool("isWall",isWall);
	}
	public void OnCollisionExit2D(Collision2D col){
		if(col.collider.tag=="Ground")
			isGround = false;
		//will be used
		/*if(col.collider.tag == "Wall"){
			isWall = false;
			player_rigidbody.gravityScale=30;
		}*/
		/*if (col.collider.tag == "Enemy") {
			underattack=false;
		}
		player_animator.SetBool("attack",underattack);*/
		player_animator.SetBool("isGround",isGround);
		//anim.SetBool("isWall",isWall);
	}

}
