using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_head_1 : MonoBehaviour {
    GameObject player;
    GameObject bossbody;
    GameObject dead_boss;
    public float HP = 120f;
    public float maxPos_x = 20.5f;
    public float maxPos_y = 9.69f;
    public float minPos_x = -7.13f;
    public float minPos_y = -3.98f;
    float attack_in = 2.0f;
    // float timeCounter1;
    //  float timeCounter2;
    float stopTime;
    float moveTime;
    float vel_x=1.0f, vel_y=1.0f;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bossbody = GameObject.FindGameObjectWithTag("Boss_body");
    }
        // Update is called once per frame
        void Update ()
    {
        if (HP > 0)
        {
            float x_e = this.transform.position.x;
            float x_p = player.transform.position.x;
            if (x_p > x_e)
                this.transform.localEulerAngles = new Vector3(0, -180, 0);
            else
                this.transform.localEulerAngles = new Vector3(0, 0, 0);
            this.transform.position = this.transform.position + new Vector3(vel_x * Time.deltaTime, vel_y * Time.deltaTime, 0);
            Check();
            if (attack_in <= 0)
            {
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
                attack_in = 2.0f;
            }
            attack_in = attack_in - Time.deltaTime;
        }
        else
        {
            Vector3 new_position;
            new_position = bossbody.transform.position;
            if (bossbody.transform.localEulerAngles.y == 0)
                dead_boss = Instantiate(Resources.Load("prefabs/dead_boss_1"), new_position, Quaternion.Euler(new Vector3(0, 0f, 0))) as GameObject;
            else
                dead_boss = Instantiate(Resources.Load("prefabs/dead_boss_1"), new_position, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
            Destroy(bossbody);
            Destroy(gameObject);
        }
	}
    void Check()
    {
        if (this.transform.position.x > maxPos_x)
            vel_x = -vel_x;
           
        if (this.transform.position.x < minPos_x)
            vel_x = -vel_x;

        if (this.transform.position.y > maxPos_y)
            vel_y = -vel_y;

        if (this.transform.position.y < minPos_y)
            vel_y = -vel_y;

    }  
}
