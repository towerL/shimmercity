using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Boss_behavior : MonoBehaviour {

    //public float bullet_speed = 2.0f;
    public int Boss_health = 200;
    public int cur_Bosshealth;
    public float walk_run_dis = 0.1f;
    public double far_attact_in = 1.0;
    public bool isdeath = false;
    public bool isfreeze = false;
    bool isblink = false;
    float dis;
    bool exist_body = false;
    bool exist_head = false;
    float bullet_speed = 2.0f;
    //int chose_act = 0;
    public float e_timer = 6.0f;
    public float e_timer_1 = 2.0f;
    public float e_timer_2 = 3.0f;
    public float e_timer_3 = 3.0f;
    public float e_timer_4 =1.0f;
    public float change_pos = 4.0f;
    Animator e_animator;
    GameObject player;
    GameObject bosshead;
    GameObject bossbody;
    GameObject bulletpre;
    //CharacterController e_cc;
    // Use this for initialization
    void Start ()
    {
        cur_Bosshealth = Boss_health;
        player = GameObject.FindGameObjectWithTag("Player");
        e_animator = GetComponent<Animator>();
       // e_cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        dis = Vector2.Distance(this.transform.position, player.transform.position);
        if(cur_Bosshealth>0)
        {
            Activity();
        }
        else if(isdeath)
        {
            e_animator.SetTrigger("die");
            isdeath = true;
        }

	}

    void Activity()
    {
        float x_e = this.transform.position.x;
        float x_p = player.transform.position.x;
        if (x_p > x_e)                                                      //不要瞬间转身
            this.transform.localEulerAngles = new Vector3(0, -180, 0);
        else
            this.transform.localEulerAngles = new Vector3(0, 0, 0);
        if (!isfreeze)
        {
            if (isblink)
            {
                //this.enabled = true;
                //e_animator.ResetTrigger("blink");
                e_animator.SetBool("blink", false);
                e_animator.ResetTrigger("attack_near_1");
                e_animator.ResetTrigger("attack_near_2");
                e_animator.ResetTrigger("move");
                e_animator.SetTrigger("stay");
                change_pos = 4.0f;
                if(e_timer_3>=0)
                {
                    if (far_attact_in <= 0)
                    {
                        e_animator.ResetTrigger("blink");
                        e_animator.ResetTrigger("attack_near_1");
                        e_animator.ResetTrigger("attack_near_2");
                        e_animator.ResetTrigger("move");
                        e_animator.SetTrigger("stay");
                        e_animator.SetTrigger("attack_far");
                        if (this.transform.localEulerAngles.y == 0)
                        {
                            Vector3 new_position = transform.position + new Vector3(-2, -0.5f, 0);
                            GameObject bulletInstance_1 = Instantiate(Resources.Load("prefabs/New Prefab"), new_position, Quaternion.Euler(new Vector3(0, 0, 180f))) as GameObject;
                            Rigidbody2D bullet_rig_1 = bulletInstance_1.GetComponent<Rigidbody2D>();
                            bullet_rig_1.velocity = new Vector2(-bullet_speed, 0);
                        }
                        else
                        {
                            Vector3 new_position = transform.position + new Vector3(2, -0.5f, 0);
                            GameObject bulletInstance_1 = Instantiate(Resources.Load("prefabs/New Prefab"), new_position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            Rigidbody2D bullet_rig_1 = bulletInstance_1.GetComponent<Rigidbody2D>();
                            bullet_rig_1.velocity = new Vector2(bullet_speed, 0);
                        }
                        far_attact_in = 1.0f;
                    }
                    else
                        far_attact_in = far_attact_in - Time.deltaTime;
                    e_timer_3 = e_timer_3 - Time.deltaTime;
                }
                else
                {
                    isblink = false;
                    e_timer_3 = 3.0f;
                }
            }
            if (cur_Bosshealth >= 120&& !isblink)
            {
                stage1_behavior();
            }
            if (cur_Bosshealth < 120 && !isblink)
            {

                   
                    Vector3 new_position = this.transform.position;
                    Vector3 new_position_1 = new Vector3(0, 2, 0) + this.transform.position;
                    if (this.transform.localEulerAngles.y == 0)
                    {
                        bossbody = Instantiate(Resources.Load("prefabs/body"), new_position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                        bosshead = Instantiate(Resources.Load("prefabs/head"), new_position_1, Quaternion.Euler(new Vector3(0, 0,0))) as GameObject;
                    }
                    else
                    {
                        bossbody = Instantiate(Resources.Load("prefabs/body"), new_position, Quaternion.Euler(new Vector3(0, 180f, 0))) as GameObject;
                        bosshead = Instantiate(Resources.Load("prefabs/head"), new_position_1, Quaternion.Euler(new Vector3(0, 180f, 0))) as GameObject;
                    }
                Destroy(gameObject);
            }
        }
    }


    void stage1_behavior()
    {
        float speed_hang = 0.07f;
        Vector3 velocity = Vector3.zero;
        Vector3 newposition = Vector3.zero;
        if (dis > 8)
        {
            change_pos = 4.0f;
            e_timer = 6.0f;
            e_timer_1 = 2.0f;
            e_timer_3 = 3.0f;
            e_timer_4 = 1.0f;
            int chose_act = 0;
            if (e_timer_2 <= 0)
            {
                chose_act = Random.Range(0, 2);
                e_timer_2 = 3.0f;
            }
            if (chose_act == 0)
            {
                e_animator.SetBool("blink", false);
                e_animator.ResetTrigger("attack_near_1");
                e_animator.ResetTrigger("attack_far");
                e_animator.ResetTrigger("attack_far_1");
                e_animator.ResetTrigger("attack_near_2");
                e_animator.SetTrigger("stay");
                e_animator.SetTrigger("move");
                // e_cc.SimpleMove();
                if (this.transform.localEulerAngles.y == 0)
                    newposition = this.transform.position + new Vector3(-walk_run_dis, 0, 0);
                else
                    newposition = this.transform.position + new Vector3(walk_run_dis, 0, 0);
                this.transform.position = Vector3.SmoothDamp(this.transform.position, newposition, ref velocity, speed_hang);
            }
            else
            {
                if (far_attact_in <= 0)
                {
                    e_animator.SetBool("blink", false);
                    e_animator.ResetTrigger("attack_near_1");
                    e_animator.ResetTrigger("attack_near_2");
                    e_animator.ResetTrigger("move");
                    e_animator.SetTrigger("stay");
                    e_animator.SetTrigger("attack_far");
                    if (this.transform.localEulerAngles.y == 0)
                    {
                        Vector3 new_position = transform.position + new Vector3(0, 0.5f, 0);
                        GameObject bulletInstance = Instantiate(Resources.Load("prefabs/New Prefab"), new_position, Quaternion.Euler(new Vector3(0, 0, 180f))) as GameObject;
                        Rigidbody2D bullet_rig = bulletInstance.GetComponent<Rigidbody2D>();
                        //int far_attack_chose = Random.Range(0, 3);
                        //  if (far_attack_chose == 0)
                        bullet_rig.velocity = new Vector2(-bullet_speed, 0);
                        //  if (far_attack_chose == 1)
                       // bullet_rig.velocity = new Vector2(-bullet_speed, 1);
                        // if (far_attack_chose == 2)
                        //bullet_rig.velocity = new Vector2(-bullet_speed, -1);
                    }
                    else
                    {
                        Vector3 new_position = transform.position + new Vector3(0, 0.5f, 0);
                        GameObject bulletInstance = Instantiate(Resources.Load("prefabs/New Prefab"), new_position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                        Rigidbody2D bullet_rig = bulletInstance.GetComponent<Rigidbody2D>();
                        //int far_attack_chose = Random.Range(0, 3);
                        //if(far_attack_chose==0)
                        bullet_rig.velocity = new Vector2(bullet_speed, 0);
                        //if(far_attack_chose==1)
                      //  bullet_rig.velocity = new Vector2(bullet_speed, 1);
                        //if(far_attack_chose==2)
                      //  bullet_rig.velocity = new Vector2(bullet_speed, -1);
                    }
                    far_attact_in = 1.0f;
                }
                else
                    far_attact_in = far_attact_in - Time.deltaTime;
            }
            e_timer_2 = e_timer_2 - Time.deltaTime;
        }
        if (dis <= 8 && dis > 5)
        {
            change_pos = 4.0f;
            e_timer_1 = 2.0f;
            e_timer_2 = 3.0f;
            e_timer_3 = 3.0f;
            e_timer_4 = 1.0f;
            e_timer -= Time.deltaTime;
            //Debug.Log(e_timer);
            //e_animator.ResetTrigger("attack_near_1");
            e_animator.SetBool("blink", false);
            e_animator.ResetTrigger("attack_far");
            e_animator.ResetTrigger("attack_near_2");
            e_animator.SetTrigger("stay");
            e_animator.SetTrigger("move");
            if (e_timer <= 6 && e_timer > 4)
            {
                if (this.transform.localEulerAngles.y == 0)
                    newposition = this.transform.position + new Vector3(-walk_run_dis, 0, 0);
                else
                    newposition = this.transform.position + new Vector3(walk_run_dis, 0, 0);
                this.transform.position = Vector3.SmoothDamp(this.transform.position, newposition, ref velocity, speed_hang);
            }
            if (e_timer <= 4 && e_timer > 2)
            {
                if (this.transform.localEulerAngles.y == 0)
                    newposition = this.transform.position + new Vector3(walk_run_dis, 0, 0);
                else
                    newposition = this.transform.position + new Vector3(-walk_run_dis, 0, 0);
                this.transform.position = Vector3.SmoothDamp(this.transform.position, newposition, ref velocity, speed_hang);
            }
            if (e_timer <= 2 && e_timer > 0)
            {
                if (this.transform.localEulerAngles.y == 0)
                    newposition = this.transform.position + new Vector3(-walk_run_dis, 0, 0);
                else
                    newposition = this.transform.position + new Vector3(walk_run_dis, 0, 0);
                this.transform.position = Vector3.SmoothDamp(this.transform.position, newposition, ref velocity, speed_hang);
            }
            if (e_timer <= 0)
            {
                e_animator.SetBool("blink", false);
                e_animator.ResetTrigger("attack_far");
                e_animator.ResetTrigger("attack_near_2");
                e_animator.ResetTrigger("move");
                e_animator.SetTrigger("stay");
                e_animator.SetTrigger("attack_near_1");
            }
            if (e_timer <= -0.25)
                e_timer = 6.0f;
        }
        if (dis <= 5)
        {
            e_timer = 6.0f;
            e_timer_2 = 3.0f;
            e_timer_3 = 3.0f;
            //e_animator.SetTrigger("idle_1");
            //e_animator.SetTrigger("skill_1");
            //e_animator.SetBool("blink", false);
            e_animator.ResetTrigger("attack_far");
            e_animator.ResetTrigger("attack_near_1");
            //  e_animator.ResetTrigger("attack_near_2");
            e_animator.ResetTrigger("move");
            e_animator.SetTrigger("stay");
            e_timer_1 = e_timer_1 - Time.deltaTime;
            change_pos = change_pos - Time.deltaTime;
            Debug.Log(e_timer_1);
            if (e_timer_1 <= 0)
            {
                e_animator.ResetTrigger("blink");
                e_animator.ResetTrigger("attack_far");
                e_animator.ResetTrigger("attack_near_1");
                e_animator.ResetTrigger("move");
                e_animator.SetTrigger("stay");
                e_animator.SetTrigger("attack_near_2");
                e_timer_1 = 2.0f;
            }
            if (change_pos <= 0)
            {
                e_animator.ResetTrigger("attack_far");
                e_animator.ResetTrigger("attack_near_1");
                e_animator.ResetTrigger("attack_near_2");
                e_animator.ResetTrigger("attack_far_1");
                e_animator.ResetTrigger("move");
                //e_animator.ReSetTrigger("stay");
                e_animator.SetBool("blink", true);
                if (e_timer_4 <= 0)
                {
                    //  this.enabled = false;
                    isblink = true;
                    if (player.transform.position.x <= 0)
                        this.transform.position = new Vector3(7.63f, -1.81f, 0);        //temp
                    else
                        this.transform.position = new Vector3(-7.88f, -1.81f, 0);       //temp
                    e_timer_4 = 1.0f; 
                }
                else
                    e_timer_4 = e_timer_4 - Time.deltaTime;
            }
        }
    }
}
