using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_head : MonoBehaviour {

    public float HP = 120f;
    float attack_in = 2.0f;
    GameObject player;
    GameObject bossbody;
    float mintracedis = 5.0f;
    float min_trackingrate = 0.5f;
    float movevx = 0.5f;
    float movevy = 0.5f;
    float maxspeed = 2.0f;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        float x_e = this.transform.position.x;
        float x_p = player.transform.position.x;
        if (x_p > x_e)
            this.transform.localEulerAngles = new Vector3(0, -180, 0);
        else
            this.transform.localEulerAngles = new Vector3(0, 0, 0);
        if (attack_in <= 0)
        {
            
        }
        else
            attack_in = attack_in - Time.deltaTime;
            headmove();


	}
    void headmove()
    {
        float vx = player.transform.position.x - this.transform.position.x;
        float vy = player.transform.position.y - this.transform.position.y;
        float dis = Vector2.Distance(this.transform.position, player.transform.position);
        if (dis < mintracedis)
        {
            vx = min_trackingrate * vx / dis;
            vy = min_trackingrate * vy / dis;
            movevx += vx;
            movevy += vy;
            if (Random.Range(1, 10) == 1)
            {
                vx = Random.Range(-1, 1);
                vy = Random.Range(-1, 1);
                movevx += vx;
                movevy += vy;
            }
            dis = pointdistance(movevx, movevy);
            if (dis > maxspeed)
            {
                movevx = movevx * 0.75f;
                movevy = movevx * 0.75f;
            }
        }
        else
        {
            if (Random.Range(1, 10) == 1)
            {
                vx = Random.Range(-2, 2);
                vy = Random.Range(-2, 2);
                movevx += vx;
                movevy += vy;
            }
            dis = pointdistance(movevx, movevy);
            if (dis > maxspeed)
            {
                movevx = movevx * 0.75f;
                movevy = movevx * 0.75f;
            }
        }
        this.transform.position = this.transform.position+ new Vector3(movevx * Time.deltaTime, movevy * Time.deltaTime, 0);
    }
    float pointdistance(float x, float y)
    {
        float result = Mathf.Sqrt(x * x + y * y);
        return result;
    }

    
}
