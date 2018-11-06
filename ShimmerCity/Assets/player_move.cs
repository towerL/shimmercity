using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class player_move : MonoBehaviour {

	enum direction {right_dir,left_dir,up_dir,down_dir};

	private Rigidbody2D player_rigidbody;
	private BoxCollider2D player_boxcollider;
	private Animator player_animator;
	private Vector3 player_position;
	private Vector3 player_Scale;
	private Vector2 velocity;

	private float jumpForce;
	private float horizontal;
	private float vertical;
	private float moveSpeed;
	private float move;

	public float force_move=70;
	public float jumpVelocity=170;

	private bool isGround = true;
	private bool isWall = false;
	private bool isLadder=false;
	//private bool isHammer=true;
	private bool isHammer=false;
	private bool alive=true;
	private bool close_range_attack=false;
	private bool far_distance_attack=false;
	private bool isStand = true;
	private bool isWalk = false;
	private bool isRun = false;
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
		player_boxcollider = this.GetComponent<BoxCollider2D> ();
		player_Scale = transform.localScale;
		velocity = player_rigidbody.velocity;
		player_position = transform.position;
		player_rigidbody.freezeRotation = true;
		player_boxcollider.offset=new Vector2(0.0f,-0.1f);
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
			if (isLadder && isGround && Input.GetKeyDown (KeyCode.W)) {

			}
			if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.RightArrow))
				velocity.x = 0;
			if (isGround && Input.GetKeyDown (KeyCode.Space)) {
				Debug.Log ("player get the KeyCode Space,you will jump.");
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
			close_range_attack=(counter_close_range_attack>0.0f?true:false);
			far_distance_attack=(counter_far_distance_attack>0.0f?true:false);
			if (close_range_attack)
				counter_close_range_attack--;
			if (far_distance_attack)
				counter_far_distance_attack--;

			isStand=(Mathf.Abs(player_rigidbody.velocity.x)<0.1f?true:false);
			isWalk = (Mathf.Abs (player_rigidbody.velocity.x) > 0.1f && Mathf.Abs (player_rigidbody.velocity.x) < 0.5f ? true : false);
			isRun=(Mathf.Abs(player_rigidbody.velocity.x)>0.5f?true:false);
			if (isGround && isStand)
				player_boxcollider.offset = new Vector2 (0.0f, -0.1f);
			else if (isGround && isWalk)
				player_boxcollider.offset = new Vector2 (0.0f, 0.1f);
			else if (isGround && isRun)
				player_boxcollider.offset = new Vector2 (0.0f, 0.3f);
			else 
				player_boxcollider.offset = new Vector2 (0.0f, 0.0f);
			Debug.Log (player_boxcollider.offset.y);
			Debug.Log (this.GetComponent<BoxCollider2D>().offset.y);
			//for test
			if (Input.GetKey (KeyCode.Q)) {
				alive = false;
				player_boxcollider.isTrigger = true;
				player_rigidbody.gravityScale = -10;
				Destroy (gameObject, 2);
			}
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
		player_animator.SetBool ("isWall",isWall);
		player_animator.SetBool ("isLadder",isLadder);
		player_animator.SetBool ("isHammer",isHammer);

	}

	private void doubleclick(){
		//todo
	}

	void SetInLadder(bool flag){
		isLadder = flag;
		player_animator.SetBool ("isLadder",flag);
	}

	public void OnCollisionEnter2D(Collision2D col){
		if(col.collider.tag == "Ground" || col.collider.tag == "Box" || col.collider.tag == "Belt"){
			isGround = true;
			player_rigidbody.gravityScale=30;
		}
		if (col.collider.tag == "Ladder") {
			isLadder = true;
			player_rigidbody.gravityScale = 0;
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
		player_animator.SetBool ("isLadder",isLadder);
		//player_animator.SetBool("isWall",isWall);
	}
	public void OnCollisionExit2D(Collision2D col){
		if(col.collider.tag=="Ground" || col.collider.tag == "Box" || col.collider.tag == "Belt")
			isGround = false;
		if (col.collider.tag == "Ladder") {
			isLadder = false;
			player_rigidbody.gravityScale = 20;
		}
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
		player_animator.SetBool ("isLadder",isLadder);
		//anim.SetBool("isWall",isWall);
	}

}
