using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_move : MonoBehaviour {

	enum direction {right_dir,left_dir,up_dir,down_dir};
	private Rigidbody2D player_rigidbody;
	//private BoxCollider2D player_boxcollider;
	private CapsuleCollider2D player_boxcollider;
	private Animator player_animator;
	private Vector3 player_Scale;
	private Vector2 velocity;
    AudioSource aus;
    private float horizontal;
	private float vertical;
	private float move;

	public float force_move=70;
	public float jumpVelocity=170;
	public float vel_x_in_air=3.0f;

	private bool isGround = true;
	private bool isWall = false;
	private bool isLadder=false;
	//private bool isHammer=true;
	private bool isHammer=false;
	//private bool isSister=true;
	private bool isSister=false;
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
	private bool skill_L = false;
	private bool sister_skill = false;

	private float player_health;

	private bool moveable;

	private GameObject[] ladders;

	public float pushmove=1000.0f;
	public float projectile = 1500.0f;

	private float attacked_timer;
	private bool attacked;
	private Color used_color;

	private bool shake;
	private float shake_timer;

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
		player_health = 100.0f;
        aus = gameObject.GetComponent<AudioSource>();
		used_color = GetComponent<Renderer> ().material.color;
        moveable = true;
	}

	void FixedUpdate () {
        GameObject.Find("Hp_bar").SendMessage("setHp", player_health);
        float h=Input.GetAxis("Horizontal");
		timer = true;
		speed_up = (isGround == true ? false : true);
		if (alive) {
			if (moveable&&(Input.GetKey(KeyCode.D)||(Input.GetKey(KeyCode.RightArrow))) && !close_range_attack && !far_distance_attack) {
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
					pos.x += Time.deltaTime * 2.4f;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = 2.4f;
					player_rigidbody.velocity = vel;
				} else if (!isLadder && !isGround && speed_up) {
					Vector3 pos = transform.position;
					pos.x += Time.deltaTime * vel_x_in_air;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = vel_x_in_air;
					player_rigidbody.velocity = vel;
				} else {

				}
				player_Scale.x = Mathf.Abs (player_Scale.x);
				transform.localScale = player_Scale;
				now_direction = direction.right_dir;
				timer = false;
			} else if (moveable && (Input.GetKey(KeyCode.A)||(Input.GetKey(KeyCode.LeftArrow))) && !close_range_attack && !far_distance_attack) {
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
					pos.x -= Time.deltaTime * 2.4f;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = -2.4f;
					player_rigidbody.velocity = vel;
				} else if (!isLadder && !isGround && speed_up) {
					Vector3 pos = transform.position;
					pos.x -= Time.deltaTime * vel_x_in_air;
					transform.position = pos;
					Vector2 vel = player_rigidbody.velocity;
					vel.x = -vel_x_in_air;
					player_rigidbody.velocity = vel;
				} else {

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
				postrans.x += Time.deltaTime * 1.5f;
			}else if (isBelt && beltflag && beltdir < 0.0f) {	
				postrans.x -= Time.deltaTime * 1.5f;
			}
			transform.position = postrans;

			if (isLadder && isGround) {
				isLadder = false;
			}
				
			if (isLadder) {
				player_rigidbody.gravityScale = 0;
				if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S))
					player_animator.speed = 1.0f;
				else
					player_animator.speed = 0.0f;
			} else {
				player_rigidbody.gravityScale = 20;
				player_animator.speed = 1.0f;
			}

			if (isGround && Input.GetKey(KeyCode.Space)) {
				jump_aus ();
				velocity=player_rigidbody.velocity;
				velocity.y = jumpVelocity;
				player_rigidbody.velocity = velocity;
				speed_up = true;
				timer = false;
			}

















			/*普攻J*/
			if (isGround && isHammer && Input.GetKeyDown(KeyCode.J)) {
				hummer_aus ();
				
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
			}
			/*远程攻*/
			if (isGround && isHammer && Input.GetKeyDown(KeyCode.K)) {
				hummer_throw ();
				moveable = false;
				far_distance_attack = true;
				close_range_attack = false;
				//counter_far_distance_attack++;
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
			/*技能L键盘*/
			if (sister_skill && isGround && isHammer && Input.GetKeyDown (KeyCode.L)&&skill_counter==0) {
				triple_hit ();
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
            if(Fpbar_controller.Instance.bisFull == false)
            {
                sister_skill = false;
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
					skill_L = false;
					skill_counter = 0;
				}
				timer = false;
			}


































			if (player_health<0.0f) {
				alive = false;
				timer = false;
				SceneManager.LoadScene("GameoverScene");
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
		player_animator.SetBool ("skill_L",skill_L);
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

	private void doubleclick(){
		//todo
	}

	void Setmove(){
		moveable = true;
	}

	void SetInLadder(bool flag){
		isLadder = flag;
		timer = false;
		player_animator.SetBool ("isLadder",flag);
	}

	void SetIsHammer(bool flag){
		isHammer = flag;
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
		vel.x = 0.0f;
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
	}

	void SetBeltdir(float dir){
		beltdir = dir;
	}

	void PlayerDecreaseHP(float harm_blood){
		player_health -= harm_blood;
		GetComponent<Renderer> ().material.color = new Color (0, 255, 255);
		attacked = true;
		attacked_timer = Time.time;
		shake = true;
	}

	void Flying_hammer(){
		GameObject flying_hammer_instance = Instantiate (Resources.Load ("prefabs/flying_hammer1"), hammer_transform.position,hammer_transform.rotation) as GameObject;
		Transform flying_hammer_transform = flying_hammer_instance.GetComponent<Transform> ();
		flying_hammer_transform.localScale = new Vector3(0.6f,0.6f,0.6f);
		Rigidbody2D flying_hammer_rigidbody = flying_hammer_instance.GetComponent<Rigidbody2D> ();
		if(player_Scale.x>0.0f)
			flying_hammer_rigidbody.AddForce (Vector2.right *pushmove);
		else
			flying_hammer_rigidbody.AddForce (-Vector2.right *pushmove);
		flying_hammer_rigidbody.AddForce (Vector2.up *projectile);
	}

	void Drop_the_hammer(){
		GameObject flying_hammer_instance = Instantiate (Resources.Load ("prefabs/flying_hammer1"), hammer_transform.position,hammer_transform.rotation) as GameObject;
		Transform flying_hammer_transform = flying_hammer_instance.GetComponent<Transform> ();
		flying_hammer_transform.localScale = new Vector3(0.6f,0.6f,0.6f);
	}

	public void OnCollisionEnter2D(Collision2D col){
		if(col.collider.tag == "Belt"&&!isGround){
			Vector3 pos = transform.position;
			pos.y -= Time.deltaTime * 3.0f;
			transform.position = pos;
			player_rigidbody.gravityScale = 40;
		}
		/*if (col.collider.tag == "deerbug") {
			GetComponent<Renderer> ().material.color = new Color (0, 255, 255);
			attacked = true;
			attacked_timer = Time.time;
			shake = true;
		}*/
	}

	public void OnCollisionStay2D(Collision2D col){
		if(col.collider.tag == "Belt"&&!isGround){
			Vector3 pos = transform.position;
			pos.y -= Time.deltaTime * 3.0f;
			transform.position = pos;
			player_rigidbody.gravityScale = 40;
		}
	}

	public void OnCollisionExit2D(Collision2D col){
		if(col.collider.tag == "Belt"){
			player_rigidbody.gravityScale = 20;
		}

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
