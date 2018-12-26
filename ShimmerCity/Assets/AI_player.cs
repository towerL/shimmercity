using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_player : MonoBehaviour {

	enum direction {right_dir,left_dir,up_dir,down_dir};


	private Rigidbody2D player_rigidbody;
	private CapsuleCollider2D player_boxcollider;
	private Animator player_animator;
	private Vector3 player_Scale;
	private Vector2 velocity;

	private bool isGround = true;
	private bool isLadder = false;
	private bool alive=true;
	private bool close_range_attack=false;
	private bool far_distance_attack=false;

	private int counter_close_range_attack;

	private float player_health;

	private GameObject target_boss;
	private Transform target_boss_transform;

	enum location_hor{left,right,near};
	enum location_ver{up,down};
	private location_hor AI_Location_hor;
	private location_ver AI_Location_ver;
	private float area_attack;

	private bool stage1;
	private bool stage2;
	private bool stage3;

	private float player_speed; 
	private Vector3 player_positon;
	private Vector2 player_velocity;
	private bool move;

	private float attacked_timer;
	private bool attacked;
	private Color used_color;
	private bool shake;
	private float shake_timer;

	private bool find_boundary;

	private bool begin_start = false;
	private bool boss_dead = false;
	private bool door_find = false;

	private float timer_for_eye;

	private bool inladder = false;
	GameObject ladder;


    private Vector3 Position;
    private Quaternion Rotation;

	void Start () {
		player_rigidbody = this.GetComponent<Rigidbody2D> ();
		player_animator = this.GetComponent<Animator> ();
		player_boxcollider=this.GetComponent<CapsuleCollider2D>();

		player_Scale = transform.localScale;
		velocity = player_rigidbody.velocity;
		player_rigidbody.freezeRotation = true;
        target_boss = GameObject.Find("used_boss");
        target_boss_transform = target_boss.transform;
        AI_Location_hor = location_hor.left;
		AI_Location_ver = location_ver.up;
		area_attack = 1.8f;
		player_speed = 2.0f;
		player_health = 100.0f;
		stage1 = true;
		stage2 = false;
		stage3 = false;
		move = true;
		alive = true;
		used_color = GetComponent<Renderer> ().material.color;
		attacked = false;
		find_boundary = false;
		ladder=GameObject.Find("ladder");
        Position = transform.position;
        Rotation = transform.rotation;
	}
		
	private location_hor AI_location_horcheck(){
        try
        {
            if (transform.position.x < target_boss_transform.position.x - area_attack)
                return location_hor.left;
            else if (transform.position.x > target_boss_transform.position.x + area_attack)
                return location_hor.right;
            else
                return location_hor.near;
        }
        catch
        {
            return location_hor.right;
        }

	}

	private location_ver AI_location_vercheck(){
        try
        {
            if (transform.position.y > target_boss_transform.position.y + area_attack)
                return location_ver.up;
            else
                return location_ver.down;
        }
        catch
        {
            return location_ver.up;
        }

	}

	public void SetMove(){
		move=true;
	}

	void Update () {
        if (begin_start){
            //try{
                target_boss = GameObject.Find("pl_boss(Clone)");
                target_boss_transform = target_boss.transform;
                begin_start = false;
           // }
           // catch{
            //    target_boss = GameObject.Find("used_boss");
            //    target_boss_transform = target_boss.transform;
            // }
        }
		if (boss_dead) {
			stage1 = false;
			stage2 = true;
			target_boss = GameObject.Find ("Bosseyes(Clone)");
			target_boss_transform = target_boss.transform;
			timer_for_eye = Time.time;
			boss_dead = false;
			area_attack = 0.4f;
			player_animator.SetBool ("close_attack",false);
		}
		if (door_find) {
			stage2 = false;
			stage3 = true;
			target_boss = GameObject.Find ("ladder");
			target_boss_transform = target_boss.transform;
			timer_for_eye = Time.time;
			door_find = false;
			area_attack = 0.4f;
		}

		AI_Location_hor = AI_location_horcheck ();
		AI_Location_ver = AI_location_vercheck ();
		if (alive) {
			if (stage1) {
				if (move && !attacked && !find_boundary && AI_Location_hor == location_hor.left) {
					player_positon = transform.position;
					player_positon.x += player_speed * Time.deltaTime;
					transform.position = player_positon;
					player_velocity = player_rigidbody.velocity;
					player_velocity.x = player_speed;
					player_rigidbody.velocity = player_velocity;
					player_Scale.x = Mathf.Abs (player_Scale.x);
					transform.localScale = player_Scale;
				} else if (move && !attacked && !find_boundary && AI_Location_hor == location_hor.right) {
					player_positon = transform.position;
					player_positon.x -= player_speed * Time.deltaTime;
					transform.position = player_positon;
					player_velocity = player_rigidbody.velocity;
					player_velocity.x = -player_speed;
					player_rigidbody.velocity = player_velocity;
					player_Scale.x = -Mathf.Abs (player_Scale.x);
					transform.localScale = player_Scale;
				} else if (move && !attacked && !find_boundary && AI_Location_hor == location_hor.near) {
					move = false;
					player_animator.Play ("AI_close_attack");
				} else if (move && find_boundary) {
					if (transform.position.x < target_boss_transform.position.x) {
						player_positon = transform.position;
						player_positon.x -= player_speed * Time.deltaTime;
						transform.position = player_positon;
						player_velocity = player_rigidbody.velocity;
						player_velocity.x = -player_speed;
						player_rigidbody.velocity = player_velocity;
						player_Scale.x = -Mathf.Abs (player_Scale.x);
						transform.localScale = player_Scale;
					} else {
						player_positon = transform.position;
						player_positon.x += player_speed * Time.deltaTime;
						transform.position = player_positon;
						player_velocity = player_rigidbody.velocity;
						player_velocity.x = player_speed;
						player_rigidbody.velocity = player_velocity;
						player_Scale.x = Mathf.Abs (player_Scale.x);
						transform.localScale = player_Scale;
					}
				}
			} 
			if (stage2) {
				if (AI_Location_hor == location_hor.left) {
					player_positon = transform.position;
					player_positon.x += player_speed * Time.deltaTime;
					transform.position = player_positon;
					player_velocity = player_rigidbody.velocity;
					player_velocity.x = player_speed;
					player_rigidbody.velocity = player_velocity;
					player_Scale.x = Mathf.Abs (player_Scale.x);
					transform.localScale = player_Scale;
				} else if (AI_Location_hor == location_hor.right) {
					player_positon = transform.position;
					player_positon.x -= player_speed * Time.deltaTime;
					transform.position = player_positon;
					player_velocity = player_rigidbody.velocity;
					player_velocity.x = -player_speed;
					player_rigidbody.velocity = player_velocity;
					player_Scale.x = -Mathf.Abs (player_Scale.x);
					transform.localScale = player_Scale;
				} else {
					if (Time.time - timer_for_eye >= 1.0f) {
						player_velocity = player_rigidbody.velocity;
						player_velocity.y = 60.0f;
						player_rigidbody.velocity = player_velocity;
					}
				}
			}
			if (stage3) {
				if (AI_Location_hor == location_hor.left) {
					player_positon = transform.position;
					player_positon.x += player_speed * Time.deltaTime;
					transform.position = player_positon;
					player_velocity = player_rigidbody.velocity;
					player_velocity.x = player_speed;
					player_rigidbody.velocity = player_velocity;
					player_Scale.x = Mathf.Abs (player_Scale.x);
					transform.localScale = player_Scale;
				} else if (AI_Location_hor == location_hor.right) {
					player_positon = transform.position;
					player_positon.x -= player_speed * Time.deltaTime;
					transform.position = player_positon;
					player_velocity = player_rigidbody.velocity;
					player_velocity.x = -player_speed;
					player_rigidbody.velocity = player_velocity;
					player_Scale.x = -Mathf.Abs (player_Scale.x);
					transform.localScale = player_Scale;
				} else {
					inladder = true;
					isGround = false;
					player_animator.Play ("player_climb");
					ladder.SendMessage ("SetInLadder",inladder);
					if(player_positon.y<7.6f){
						player_positon = transform.position;
						player_positon.x = target_boss.transform.position.x;
						player_positon.y += 2.0f * Time.deltaTime;
						transform.position = player_positon;
						player_velocity = player_rigidbody.velocity;
						player_velocity.x = 0.0f;
						player_velocity.y = 2.0f;
						player_rigidbody.velocity = player_velocity;
					}else if(player_positon.y>8.4f){
						player_positon = transform.position;
						player_positon.x = target_boss.transform.position.x;
						player_positon.y -= 2.0f * Time.deltaTime;
						transform.position = player_positon;
						player_velocity = player_rigidbody.velocity;
						player_velocity.x = 0.0f;
						player_velocity.y = -2.0f;
						player_rigidbody.velocity = player_velocity;
					}else{
						player_animator.speed = 0;
						player_rigidbody.gravityScale = 0;
					}
				}
			}


            if (player_health <= 0.0f){
                GameObject.Find("Y-4_01tips1").SendMessage("receiveMsg");
                GameObject.Find("Generate").SendMessage("SetPlayer");
                //alive = false;
                Destroy(this.gameObject);
            }
            try{
                if (find_boundary){
                    Physics2D.IgnoreCollision(player_boxcollider, target_boss.GetComponent<Collider2D>());
                }else{
                    Physics2D.IgnoreCollision(player_boxcollider, target_boss.GetComponent<Collider2D>(), false);
                }
            }catch{
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
					if (((int)(shake_timer * 10)) % 2 == 1)
						GetComponent<Renderer> ().enabled = true;
					else
						GetComponent<Renderer> ().enabled = false;
				} else
					shake = false;
			} else {
				GetComponent<Renderer> ().enabled = true;
			}
		} else {

			Debug.Log ("new player");
		}
		player_animator.SetFloat ("vel_x",Mathf.Abs(player_rigidbody.velocity.x));
		player_animator.SetBool ("isGround",isGround);
		player_animator.SetBool ("alive", alive);
		player_animator.SetBool("inadder",inladder);
	}

	void PlayerDecreaseHP(float harm_blood){
		player_health -= harm_blood;
		GetComponent<Renderer> ().material.color = new Color (0, 255, 255);
		attacked = true;
		attacked_timer = Time.time;
		shake = true;
		find_boundary = true;
	}


    void Drop_the_hammer()
    {
        GameObject flying_hammer_instance = Instantiate(Resources.Load("prefabs/flying_hammer3"), transform.position,transform.rotation) as GameObject;
        Transform flying_hammer_transform = flying_hammer_instance.GetComponent<Transform>();
        flying_hammer_transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
    }

    void SetGround(bool flag){
		isGround = flag;
		player_animator.SetBool ("isGround",flag);
	}

	void SetInLadder(bool flag){
		isLadder = flag;
		player_animator.SetBool ("isLadder",flag);
	}

	void SetBossShow(){
		begin_start = true;
	}
		
	void SetBossDead(){
		boss_dead = true;
	}

	void SetBossEyes(){
		door_find = true;
	}

	public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "b0ss_hand") {
			player_health -= 100.0f;
			GetComponent<Renderer> ().material.color = new Color (0, 255, 255);
			attacked = true;
			attacked_timer = Time.time;
			shake = true;
			find_boundary = true;
		} else if (col.collider.tag == "boss_tentacle") {
			player_health -= 100.0f;
			GetComponent<Renderer> ().material.color = new Color (0, 255, 255);
			attacked = true;
			attacked_timer = Time.time;
			shake = true;
			find_boundary = true;
		} else if (col.collider.tag == "boundary") {
			find_boundary = false;
		}
	}
		
}