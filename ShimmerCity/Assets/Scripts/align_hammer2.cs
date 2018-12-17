using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class align_hammer2 : MonoBehaviour {

	public Transform target;
	public float pushmove=1500.0f;
	public float projectilemove=3000.0f;

	private SpriteRenderer spriterender;

	private bool incloseattack = false;
	private bool infurtherattack = false;

	public float attack_range;
	private float timer_flying_hammer;
	private bool player_dir;

	public Collider2D target_collider;
	private Vector3 Position;
	private Quaternion Rotation;
	private Vector3 Scale;
	private Vector2 Velocity;
	private bool getposvalue;
	private bool getrotvalue;
	private bool getscavalue;
	private bool getvelvalue;

	void Start () {
		spriterender = this.gameObject.GetComponent<SpriteRenderer> ();
		spriterender.sortingOrder = -2;
		timer_flying_hammer = Time.time;
		player_dir = true;
		getposvalue = false;
		getrotvalue = false;
		getscavalue = false;
		getvelvalue = false;
	}

	void Update () {
		if (infurtherattack) {
			if (getposvalue && getrotvalue && getscavalue && getvelvalue) {
				GameObject flying_hammer_instance = Instantiate (Resources.Load ("prefabs/flying_hammer2"), Position, Rotation) as GameObject;
				Transform flying_hammer_transform = flying_hammer_instance.GetComponent<Transform> ();
				flying_hammer_transform.localScale = Scale/2;
				Rigidbody2D flying_hammer_rigidbody = flying_hammer_instance.GetComponent<Rigidbody2D> ();
				Physics2D.IgnoreCollision (target_collider,flying_hammer_instance.GetComponent<Collider2D>());
				flying_hammer_rigidbody.AddForce (Vector2.up *projectilemove);
				if(player_dir)
					flying_hammer_rigidbody.AddForce (Vector2.right *pushmove);
				else
					flying_hammer_rigidbody.AddForce (-Vector2.right *pushmove);
				getposvalue = false;
				getrotvalue = false;
				getscavalue = false;
				getvelvalue = false;
				infurtherattack = false;
			}	
		} 
		if (incloseattack) {
			incloseattack = false;
		} 
	}

	void SetCloseAttack(bool flag){
		incloseattack = flag;
	}

	void SetFurtherAttack(bool flag){
		infurtherattack = flag;
	}

	void SetPlayerDir(bool flag){
		player_dir = flag;
	}

	void SetPos(Vector3 Pos){
		getposvalue = true;
		Position = Pos;
	}

	void SetRot(Quaternion Rot){
		getrotvalue = true;
		Rotation = Rot;
	}

	void SetSca(Vector3 Sca){
		getscavalue = true;
		Scale = Sca;
	}

	void SetVel(Vector2 Vel){
		getvelvalue = true;
		Velocity = Vel;
	}
}
