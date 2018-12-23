using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_body : MonoBehaviour {


    GameObject player;
    GameObject boss_head;
    GameObject dead_boss;
    Renderer rd;
    Animator e_animator;
    Color cl;
    AudioSource aus;
    public float HP = 120f;
    float walk_run_dis = 0.1f;
    float speed_hang = 0.07f;
    bool change_dir = false;
    float timer = 5.0f;
    float changecolor = 0.1f;
    bool isattacked = false;
    float anispeed;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        boss_head = GameObject.FindGameObjectWithTag("Boss_head");
        rd = gameObject.GetComponent<Renderer>();
        e_animator = gameObject.GetComponent<Animator>();
        aus = gameObject.GetComponent<AudioSource>();
        cl = rd.material.color;
    }
	
	// Update is called once per frame
	void Update () {
        if (HP > 0)
        {
            if (isattacked)
            {
                isattack();
                if (changecolor <= 0)
                {
                    e_animator.speed = anispeed;
                    rd.material.color = cl;
                    changecolor = 0.1f;
                    isattacked = false;
                }
                changecolor -= Time.deltaTime;
            }
            else
            {
                Vector3 new_position;
                if (this.transform.localEulerAngles.y == 0)
                    new_position = this.transform.position + new Vector3(-2, 0, 0);
                else
                    new_position = this.transform.position + new Vector3(2, 0, 0);

                if (timer <= 0)
                {
                    setbullet();
                    GameObject bullet;
                    if (this.transform.localEulerAngles.y == 0)
                        bullet = Instantiate(Resources.Load("prefabs/bullet_2"), new_position, Quaternion.Euler(new Vector3(0, 0f, 0))) as GameObject;
                    else
                        bullet = Instantiate(Resources.Load("prefabs/bullet_2"), new_position, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
                    timer = 5.0f;
                }
                timer = timer - Time.deltaTime;
                move();
            }
        }
        else
        {
            Vector3 new_position;
            new_position = this.transform.position;
            if (this.transform.localEulerAngles.y == 0)
                dead_boss = Instantiate(Resources.Load("prefabs/dead_boss_1"), new_position, Quaternion.Euler(new Vector3(0, 0f, 0))) as GameObject;
            else
                dead_boss = Instantiate(Resources.Load("prefabs/dead_boss_1"), new_position, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
            Destroy(boss_head);
            Destroy(gameObject);
        }
    }
    void move()
    {
        Vector3 newposition = Vector3.zero;
        Vector3 velocity = Vector3.zero;
        if (change_dir)
        {
            Vector3 dir;
            if (this.transform.localEulerAngles.y == 0)
                dir = new Vector3(0, -180, 0);
            else
                dir = new Vector3(0, 0, 0);
            this.transform.localEulerAngles = dir;
            change_dir = false;
        }
        if (this.transform.localEulerAngles.y == 0)
            newposition = this.transform.position + new Vector3(-walk_run_dis, 0, 0);
        else
            newposition = this.transform.position + new Vector3(walk_run_dis, 0, 0);
        this.transform.position = Vector3.SmoothDamp(this.transform.position, newposition, ref velocity, speed_hang);
        if (this.transform.position.x <= -6.85f)
            change_dir = true;
        if (this.transform.position.x >= 19.09869f)
            change_dir = true;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "hammer_body")
        {
            if (this.transform.localEulerAngles.y == -180)
                this.transform.position = this.transform.position + new Vector3(0.1f, 0, 0);
            else
                this.transform.position = this.transform.position + new Vector3(-0.1f, 0, 0);
            anispeed = e_animator.speed;
            isattacked = true;
            rd.material.color = Color.red;
            HP -= 5;
        }
        if (col.gameObject.tag == "hammer_in_attack")
        {
            if (this.transform.localEulerAngles.y == -180)
                this.transform.position = this.transform.position + new Vector3(0.1f, 0, 0);
            else
                this.transform.position = this.transform.position + new Vector3(-0.1f, 0, 0);
            anispeed = e_animator.speed;
            isattacked = true;
            rd.material.color = Color.red;
            HP -= 10;
        }
    }
    void isattack()
    {
       e_animator.speed = 0f;
    }
    void setbullet()
    {
        AudioClip clip = (AudioClip)Resources.Load("Audios/coe/场景三/boss发射导弹", typeof(AudioClip));
        aus.clip = clip;
        aus.Play();
    }
}
