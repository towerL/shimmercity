using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_2 : MonoBehaviour {

    float mintracedis = 20.0f;
    float min_trackingrate = 0.5f;
    float movevx = 0.5f;
    float movevy = 0.5f;
    float maxspeed = 2.0f;
    GameObject player;
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
        bulletmove();
        //lookattarget();
        //this.transform.LookAt(player.transform);
        Destroy(gameObject, 8);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(gameObject);
        }
        else
            return;
    }

    void lookattarget()
    {
        float zAngles;
        if (movevy == 0)
        {
            zAngles = movevx >= 0 ? -90 : 90;
        }
        zAngles = Mathf.Atan(movevx / movevy) * (-180 / Mathf.PI);
        if (movevy < 0)
        {
            zAngles = zAngles - 180;
        }
        Vector3 tempAngles = new Vector3(0, 0, zAngles);
        Quaternion tempQua = this.transform.rotation;
        tempQua.eulerAngles = tempAngles;
        this.transform.rotation = tempQua;
    }
    void bulletmove()
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
        this.transform.position = this.transform.position + new Vector3(movevx * Time.deltaTime, movevy * Time.deltaTime, 0);
    }
    float pointdistance(float x, float y)
    {
        float result = Mathf.Sqrt(x * x + y * y);
        return result;
    }

}
