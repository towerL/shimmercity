using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_control : MonoBehaviour {

    public int Boss_health = 200;
    float walk_run_dis = 0.3f;
    float speed_hang = 0.10f;
    float timer_1 = 0;
    int count = 0;
    GameObject bosshead;
    GameObject bossbody;
    Animator ea;
    // Use this for initialization
    void Start () {
        ea = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    { 
        if(Input.GetKey(KeyCode.D))
        {
            count=1;
            Vector3 velocity = Vector3.zero;
            Vector3 newposition = Vector3.zero;
            this.transform.localEulerAngles = new Vector3(0, 180, 0);
            newposition = this.transform.position + new Vector3(walk_run_dis, 0, 0);
            this.transform.position = Vector3.SmoothDamp(this.transform.position, newposition, ref velocity, speed_hang);
        }
        if (Input.GetKeyUp(KeyCode.D))
            count = 0;
        if (Input.GetKey(KeyCode.A))
        {
            count = 1;
            Vector3 velocity = Vector3.zero;
            Vector3 newposition = Vector3.zero;
            this.transform.localEulerAngles = new Vector3(0, 0, 0);
            newposition = this.transform.position + new Vector3(-walk_run_dis, 0, 0);
            this.transform.position = Vector3.SmoothDamp(this.transform.position, newposition, ref velocity, speed_hang);
        }
        if (Input.GetKeyUp(KeyCode.A))
            count = 0;
        if (Input.GetKeyDown(KeyCode.J) && count == 0)
        {
            count = 1;
            ea.SetTrigger("attack_near_1");
        }
        if(Input.GetKeyUp(KeyCode.J))
        {
            count = 0;
            ea.ResetTrigger("attack_near_1");
            ea.SetTrigger("stay");
        }
         if (Input.GetKeyDown(KeyCode.K) && count == 0)
        {
            count = 1;
            ea.SetTrigger("attack_near_2");
        }
         if (Input.GetKeyUp(KeyCode.K))
        {
            count = 0;
            ea.ResetTrigger("attack_near_2");
            ea.SetTrigger("stay");
        }
        if (Input.GetKeyDown(KeyCode.L) && count == 0)
        {
            Vector3 new_position = this.transform.position;
            Vector3 new_position_1 = new Vector3(0, 3, 0) + this.transform.position;
            if (this.transform.localEulerAngles.y == 0)
            {
                bosshead = Instantiate(Resources.Load("Prefabs/pl_head"), new_position_1, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                bossbody = Instantiate(Resources.Load("Prefabs/pl_body"), new_position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;

                bossbody.SendMessage("setHP", Boss_health);
                bosshead.SendMessage("setHP", Boss_health);
                Destroy(gameObject);
            }
            else
            {
                bosshead = Instantiate(Resources.Load("Prefabs/pl_head"), new_position_1, Quaternion.Euler(new Vector3(0, 180f, 0))) as GameObject;
                bossbody = Instantiate(Resources.Load("Prefabs/pl_body"), new_position, Quaternion.Euler(new Vector3(0, 180f, 0))) as GameObject;

                bossbody.SendMessage("setHP", Boss_health);
                bosshead.SendMessage("setHP", Boss_health);
                Destroy(gameObject);
            }
        }
    }
    void giveHP(int i)
    {
        Boss_health = i;
    }
}
