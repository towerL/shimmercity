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
    // Use this for initialization
    void Start () {
        bossbody = GameObject.FindGameObjectWithTag("Boss_body");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position = this.transform.position + new Vector3(vel_x * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
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
        if(Input.GetKeyDown(KeyCode.J))
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
        }
        if(Input.GetKeyUp(KeyCode.J))
        {
            attack_in = 2.0f;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "hammer_body")
        {
            HP -= 5;
        }
        if (col.gameObject.tag == "hammer_in_attack")
        {
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
}
