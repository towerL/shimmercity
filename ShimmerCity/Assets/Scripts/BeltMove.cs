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
    float dir = 1;
    //起始位置
    float start_x;
    float start_y;

    void Start()
    {
        start_x = transform.position.x;//水平移动的起点
        start_y = transform.position.y;//竖直移动的起点
    }

    void Update()
    {
        //gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, target.position, (dis / 3f) * Time.deltaTime);
        //移动
        //竖直移动
        if (flag)
        {
            transform.Translate(Vector2.right * dir * speed * Time.deltaTime);
            if (System.Math.Abs(transform.position.x - start_x) <= 0.1f || System.Math.Abs(transform.position.x - start_x) >= dis) { dir = -dir; }
        }
        //水平移动
        else {
            transform.Translate(Vector2.up * dir * speed * Time.deltaTime);
            if (System.Math.Abs(transform.position.y - start_y) <= 0.1f || System.Math.Abs(transform.position.y - start_y) >= dis) { dir = -dir; }
        }
    }

}
