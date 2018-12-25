using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltMove : MonoBehaviour
{
	//移动距离
    public float dis;
    //移动速度
    public float speed;
    //水平移动为true 竖直移动为false
    public bool flag;
    //移动方向
    public float dir;
    //起始位置
    float start_x;
    float start_y;
    //起始坐标
    Vector3 ori;
    //终止坐标
    Vector3 des;

    void Start()
    {
        ori = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (flag)
        {
            //水平移动
            des = new Vector3(transform.position.x + dir * dis, transform.position.y, transform.position.z);
        }
        else
        {
            //垂直移动
            des = new Vector3(transform.position.x, transform.position.y + dir * dis, transform.position.z);
        }
        start_x = transform.position.x;//水平移动的起点
        start_y = transform.position.y;//竖直移动的起点
    }

    void Update()
    {
        float distance = Mathf.PingPong(Time.time * speed, Vector3.Distance(ori, des));
        //每帧都给游戏物体一个新的坐标
        if (flag)
        {
            transform.position = new Vector3(start_x-dir*distance, transform.position.y, transform.position.z);
            //transform.Translate(Vector2.right * dir * speed * Time.deltaTime);
            //if (System.Math.Abs(transform.position.x - start_x) <= 0.1f || System.Math.Abs(transform.position.x - start_x) >= dis) { dir = -dir; }
        }
        else {
            transform.position = new Vector3(transform.position.x, start_y + distance, transform.position.z);
            //transform.Translate(Vector2.up * dir * speed * Time.deltaTime);
            //if (System.Math.Abs(transform.position.y - start_y) <= 0.1f || System.Math.Abs(transform.position.y - start_y) >= dis) { dir = -dir; }
        }
    }

	public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "Feet") {
			GameObject.Find("Player").SendMessage ("SetBeltFlag",flag);
			GameObject.Find("Player").SendMessage ("SetBeltdir",dir);
		}
	}

	public void OnCollisionStay2D(Collision2D col){
		if (col.collider.tag == "Feet") {
			GameObject.Find("Player").SendMessage ("SetBeltFlag",flag);
			GameObject.Find("Player").SendMessage ("SetBeltdir",dir);
		}
	}

	public void OnCollisionExit2D(Collision2D col){
		if (col.collider.tag == "Feet") {
			GameObject.Find("Player").SendMessage ("SetBeltFlag",flag);
			GameObject.Find("Player").SendMessage ("SetBeltdir",0.0f);
		}
	}
}
