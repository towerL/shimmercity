using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_body : MonoBehaviour {


    GameObject player;
    GameObject boss_head;
    public float HP = 120f;
    bool head_connect = false;
    bool pl_isground = false;
    float walk_run_dis = 0.1f;
    float speed_hang = 0.07f;
    bool change_dir = false;
    float timer = 5.0f;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        boss_head = GameObject.FindGameObjectWithTag("Boss_head");
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 new_position;
        if (this.transform.localEulerAngles.y == 0)
            new_position = this.transform.position + new Vector3(-2, 0, 0);
        else
            new_position = this.transform.position + new Vector3(2, 0, 0);

        if (timer <= 0)
        {
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
        if (this.transform.position.x <= -7.63f)
            change_dir = true;
        if (this.transform.position.x >= 7.63f)
            change_dir = true;
    }
}
