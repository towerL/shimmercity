using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisionAttack : MonoBehaviour {
    float attackTimer;
    float attackTime;
    private Animator ani;
    float mytime = 1.0f;
    AudioSource aus;
	public float harm=10.0f;
	bool flag = false;
	float timer = 4.0f;
	void Start () {
        ani = GetComponent<Animator>();
        aus = gameObject.GetComponent<AudioSource>();
    }
	
    void Update()
    {
        mytime -= Time.deltaTime;
        if (mytime < -3)
        {
            poision();
            ani.Play("poision");
            ani.Play("poision_static");
            mytime = 1.0f;
			flag = true;
        }
		if (timer <= 0 && flag) 
		{
			aus.Stop ();
			flag = false;
			timer = 4.0f;
		}
		if (flag)
			timer -= Time.deltaTime;
        //if (attackTimer > 0)
        //{
        //    attackTimer -= Time.deltaTime;
        //    if (attackTimer == 3) {
        //        ani.SetBool("IsBegin", false);
        //    }
        //}
        //if (attackTimer < 0)
        //    attackTimer = 0;
        //if (attackTimer == 0)
        //{
        //    ani.SetBool("IsBegin", true);
        //    attackTimer = attackTime;
        //}
        //if (Time.frameCount % 60 == 0)
        //{
        //    ani.SetBool("IsBegin", true);
        //}
        //if (Time.frameCount % 100 == 0) {
        //    ani.SetBool("IsBegin", false);
        //}
    }

	private void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player"){
			col.SendMessage ("PlayerDecreaseHP",harm);
		}
	}

    void poision()
    {
        AudioClip clip = (AudioClip)Resources.Load("Audios/coe/场景二/蒸汽", typeof(AudioClip));
        aus.clip = clip;
        aus.Play();
    }
}
