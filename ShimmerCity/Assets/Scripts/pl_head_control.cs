using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pl_head_control : MonoBehaviour {
    float vel_x = 2.0f;
    float vel_y = 2.0f;
    float attack_in = 2.0f;
    public int HP;
    GameObject boss;
    GameObject bossbody;
    AudioSource aus;
    Animator e_animator;
    Color cl;
    Renderer rd;
    float anispeed =1.0f;
    float changecolor = 0.1f;
    bool isattacked = false;
    // Use this for initialization
    void Start () {
        bossbody = GameObject.FindGameObjectWithTag("Boss_body");
        aus = gameObject.GetComponent<AudioSource>();
        rd = gameObject.GetComponent<Renderer>();
        e_animator = gameObject.GetComponent<Animator>();
        cl = rd.material.color;
    }
	
	// Update is called once per frame
	void Update () {
        if (HP > 0)
        {
            bossbody.SendMessage("setHP", HP);
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
                if (Input.GetKey(KeyCode.D))
                {
                    this.transform.localEulerAngles = new Vector3(0, 180, 0);
                    this.transform.position = this.transform.position + new Vector3(vel_x * Time.deltaTime, 0, 0);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    this.transform.localEulerAngles = new Vector3(0, 0, 0);
                    this.transform.position = this.transform.position + new Vector3(-vel_x * Time.deltaTime, 0, 0);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    this.transform.position = this.transform.position + new Vector3(0, -vel_y * Time.deltaTime, 0);
                }
                if (Input.GetKey(KeyCode.W))
                {
                    this.transform.position = this.transform.position + new Vector3(0, vel_y * Time.deltaTime, 0);
                }
                if (Input.GetKeyDown(KeyCode.J))
                {
                    setbullet();
                    GameObject bulletInstance_1 = Instantiate(Resources.Load("prefabs/New Prefab"), this.transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as GameObject;
                    GameObject bulletInstance_2 = Instantiate(Resources.Load("prefabs/New Prefab"), this.transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as GameObject;
                    GameObject bulletInstance_3 = Instantiate(Resources.Load("prefabs/New Prefab"), this.transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as GameObject;
                    GameObject bulletInstance_4 = Instantiate(Resources.Load("prefabs/New Prefab"), this.transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as GameObject;
                    GameObject bulletInstance_5 = Instantiate(Resources.Load("prefabs/New Prefab"), this.transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as GameObject;
                    GameObject bulletInstance_6 = Instantiate(Resources.Load("prefabs/New Prefab"), this.transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as GameObject;
                    Rigidbody2D bullet_rig_1 = bulletInstance_1.GetComponent<Rigidbody2D>();
                    Rigidbody2D bullet_rig_2 = bulletInstance_2.GetComponent<Rigidbody2D>();
                    Rigidbody2D bullet_rig_3 = bulletInstance_3.GetComponent<Rigidbody2D>();
                    Rigidbody2D bullet_rig_4 = bulletInstance_4.GetComponent<Rigidbody2D>();
                    Rigidbody2D bullet_rig_5 = bulletInstance_5.GetComponent<Rigidbody2D>();
                    Rigidbody2D bullet_rig_6 = bulletInstance_6.GetComponent<Rigidbody2D>();
                    bullet_rig_1.velocity = new Vector2(2.0f, 2.0f);
                    bullet_rig_2.velocity = new Vector2(-2.0f, -2.0f);
                    bullet_rig_3.velocity = new Vector2(0, 2.0f);
                    bullet_rig_4.velocity = new Vector2(2.0f, -2.0f);
                    bullet_rig_5.velocity = new Vector2(-2.0f, 2.0f);
                    bullet_rig_6.velocity = new Vector2(0, -2.0f);
                }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "hammer_body")
        {
            if (this.transform.localEulerAngles.y == -180)
                this.transform.position = this.transform.position + new Vector3(0.1f, 0, 0);
            else
                this.transform.position = this.transform.position + new Vector3(-0.1f, 0, 0);
          //  anispeed = e_animator.speed;
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
          //  anispeed = e_animator.speed;
            isattacked = true;
            rd.material.color = Color.red;
            HP -= 10;
        }
        if(col.gameObject.tag =="head_dect")
        {
            Vector3 new_position = bossbody.transform.position;
            if (bossbody.transform.localEulerAngles.y == 0)
                boss = Instantiate(Resources.Load("Prefabs/pl_boss"), new_position, Quaternion.Euler(new Vector3(0, 0f, 0))) as GameObject;
            else
                boss = Instantiate(Resources.Load("Prefabs/pl_boss"), new_position, Quaternion.Euler(new Vector3(0,180f, 0))) as GameObject;
            boss.SendMessage("giveHP", HP);
            Destroy(bossbody);
            Destroy(gameObject);
        }
    }
    void setHP(int i)
    {
        HP = i;
    }
    void setbullet()
    {
        AudioClip clip = (AudioClip)Resources.Load("Audios/coe/场景三/boss头放子弹", typeof(AudioClip));
        aus.clip = clip;
        aus.Play();
    }
    void isattack()
    {
        e_animator.speed = 0f;
    }
}
