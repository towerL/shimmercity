using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_move3 : MonoBehaviour {

	enum direction {right_dir,left_dir,up_dir,down_dir};

	public float vel_x=6.0f;
	public float vel_x_in_air=3.0f;
	public float push_v = 1.2f;
	public float ladder_v=0.2f;
	public float force_move=70.0f;
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

	private bool moveable;

	private GameObject[] ladders;
    AudioSource aus;
    private float attacked_timer;
	private bool attacked;
	private Color used_color;

	public float pushmove=1000.0f;
	public float projectile = 1500.0f;

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
		moveable = true;
		used_color = GetComponent<Renderer> ().material.color;
        aus = gameObject.GetComponent<AudioSource>();
    }

	void FixedUpdate () {
        GameObject.Find("Hp_bar").SendMessage("setHp", player_health);
        //float h=Input.GetAxis("Horizontal");
        timer = true;
		speed_up = (isGround == true ? false : true);
		if (alive) {
			if (moveable&&(Input.GetKey(KeyCode.D)||(Input.GetKey(KeyCode.RightArrow))) && !close_range_attack && !far_distance_attack) {
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

			if (isLadder && isGround) {
				isLadder = false;
			}

			if (isLadder) {
				player_rigidbody.gravityScale = 0;
				for (int i = 0; i <= 14; i++) {
					if(i!=9)
						Physics2D.IgnoreLayerCollision (9,i);
				}
				if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S))
					player_animator.speed = 1.0f;
				else
					player_animator.speed = 0.0f;
			} else {
				player_rigidbody.gravityScale = 20;
				for (int i = 0; i <= 14 ; i++) {
					if(i!=9)
						Physics2D.IgnoreLayerCollision (9,i,false);
				}
				player_animator.speed = 1.0f;
			}

			if (isGround && Input.GetKeyDown (KeyCode.Space)) {
				jump_aus ();
				velocity=player_rigidbody.velocity;
				velocity.y = jumpVelocity;
				player_rigidbody.velocity = velocity;
				speed_up = true;
				timer = false;
			}

			Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("hammer_in_attack").GetComponent<Collider2D> (), player_boxcollider);
			if (isGround && Input.GetKey(KeyCode.J)) {
				hummer_aus ();
				moveable = false;
				close_range_attack = true;
				far_distance_attack = false;
				counter_close_range_attack=1;
				if (counter_far_distance_attack > 0) {
					attack_transform = true;
					counter_far_distance_attack = 0;
				}
				timer = false;
			}
			if (isGround && Input.GetKeyDown(KeyCode.K)) {
				hummer_throw ();
				far_distance_attack = true;
				close_range_attack = false;
				counter_far_distance_attack=1;
				if (counter_close_range_attack > 0) {
					attack_transform = true;
					counter_close_range_attack = 0;
				}
				timer = false;
			}
			close_range_attack=(counter_close_range_attack>0.0f?true:false);
			far_distance_attack=(counter_far_distance_attack>0.0f?true:false);
			if (close_range_attack)
				counter_close_range_attack--;
			if (far_distance_attack)
				counter_far_distance_attack--;


			if (player_health<0.0f) {
				alive = false;
				timer = false;
				SceneManager.LoadScene("GameoverScene3");
			}

			if (Input.GetKeyDown (KeyCode.L)&&skill_counter==0) {
				triple_hit ();
				timer_for_triple=true;
				timer_for_skill = Time.time;
			}

			if(timer_for_triple){
				if (skill_counter < 3) {
					float now_timer = Time.time;
					if (now_timer - timer_for_skill >= skill_time) {
						GameObject skill_hammer = Instantiate (Resources.Load ("prefabs/skill_L_3")) as GameObject;
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

			if (Input.GetKeyDown (KeyCode.U)&&shield) {
				//if(!ProtectLayer)
				//	ProtectLayer = Instantiate (Resources.Load ("prefabs/Protect")) as GameObject;
				BroadcastMessage ("SetProtectLayer",true);
				shield = false;
				shield_timer = Time.time;
				in_shield = true;
			}
				
			if (in_shield) {
				shield_now_timer= Time.time;
				if (shield_now_timer-shield_timer>=shield_functimer) {
					if (ProtectLayer)
						Destroy (ProtectLayer);
					BroadcastMessage ("SetProtectLayer", false);
					in_shield = false;
					GameObject.FindWithTag ("MainCamera").SendMessage ("SetShieldFlag2",true);
				}
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
			}
		}
		player_animator.SetFloat ("velocity_x",Mathf.Abs(player_rigidbody.velocity.x));
		player_animator.SetFloat ("velocity_y",player_rigidbody.velocity.y);
		player_animator.SetBool ("close_attack",close_range_attack);
		player_animator.SetBool ("far_attack",far_distance_attack);
		player_animator.SetBool ("isGround",isGround);
		player_animator.SetBool ("five_minutes",five_minutes);
		player_animator.SetBool ("isPush",isPush);
		player_animator.SetBool ("alive",alive);
		player_animator.SetBool ("move",moveable);
		ladders = GameObject.FindGameObjectsWithTag ("Ladder");
		foreach (GameObject ladder in ladders){
			ladder.SendMessage("SetGround",isGround);
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
	}

	void Setmove(){
		moveable = true;
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

	void PlayerDecreaseHP(float harm_blood){
		player_health -= harm_blood;
		GetComponent<Renderer> ().material.color = new Color (0, 255, 255);
		attacked = true;
		attacked_timer = Time.time;
		shake = true;
        if(SceneManager.GetActiveScene().name == "Part3")
        {
            GameObject.Find("Fp_bar").SendMessage("Freame_Increase");
            GameObject.Find("Sister_Head").SendMessage("Fpbaradd");
        }
	}

	void PlayerIncreaseHP(float blood_bag){
		player_health += blood_bag;
		GetComponent<Renderer> ().material.color = new Color(160,32,240);
		attacked = true;
		attacked_timer = Time.time;
		shake = false;
	}

	void Flying_hammer(){
		GameObject flying_hammer_instance = Instantiate (Resources.Load ("prefabs/flying_hammer3"), hammer_transform.position,hammer_transform.rotation) as GameObject;
		Transform flying_hammer_transform = flying_hammer_instance.GetComponent<Transform> ();
		flying_hammer_transform.localScale = new Vector3(0.3f,0.3f,0.3f);
		Rigidbody2D flying_hammer_rigidbody = flying_hammer_instance.GetComponent<Rigidbody2D> ();
		if(player_Scale.x>0.0f)
			flying_hammer_rigidbody.AddForce (Vector2.right *pushmove);
		else
			flying_hammer_rigidbody.AddForce (-Vector2.right *pushmove);
		flying_hammer_rigidbody.AddForce (Vector2.up *projectile);
		Debug.Log (flying_hammer_rigidbody.position);
	}

	void Drop_the_hammer(){
		GameObject flying_hammer_instance = Instantiate (Resources.Load ("prefabs/flying_hammer3"), hammer_transform.position,hammer_transform.rotation) as GameObject;
		Transform flying_hammer_transform = flying_hammer_instance.GetComponent<Transform> ();
		flying_hammer_transform.localScale = new Vector3(0.3f,0.3f,0.3f);
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

	/*public void OnCollisionStay2D(Collision2D col){
		if (col.collider.tag == "b0ss_hand") {
			player_health -= 1.0f;
			GetComponent<Renderer> ().material.color = new Color (0, 255, 255);
			attacked = true;
			Debug.Log ("boss_hand2");
		}else if (col.collider.tag == "boss_tentacle") {
			player_health -= 2.0f;
			GetComponent<Renderer> ().material.color = new Color (0, 255, 255);
			attacked = true;
			Debug.Log ("boss_tentacle2");
		}
	}*/

	public void OnCollisionExit2D(Collision2D col){

	}
	void run_aus()
	{
		AudioClip clip = (AudioClip)Resources.Load("Audios/coe/通用/人物动作发声相关/跑步3", typeof(AudioClip));
		aus.clip = clip;
		aus.Play();
	}

	void jump_aus()
	{
		AudioClip clip = (AudioClip)Resources.Load("Audios/coe/通用/人物动作发声相关/跳跃2", typeof(AudioClip));
		aus.clip = clip;
		aus.Play();
	}

	void hummer_throw()
	{
		AudioClip clip = (AudioClip)Resources.Load("Audios/coe/通用/锤子相关/扔出锤子", typeof(AudioClip));
		aus.clip = clip;
		aus.Play();
	}

	void hummer_aus()
	{
		AudioClip clip = (AudioClip)Resources.Load("Audios/coe/通用/锤子相关/锤子打鸡生", typeof(AudioClip));
		aus.clip = clip;
		aus.Play();
	}

	void triple_hit()
	{
		AudioClip clip = (AudioClip)Resources.Load("Audios/coe/通用/锤子相关/大招", typeof(AudioClip));
		aus.clip = clip;
		aus.Play();
	}

}