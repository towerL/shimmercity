using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newslidein : MonoBehaviour {

    //移动距离
    public float dis;
    //移动速度
    public float speed;
    //向左移动为true 向右移动为false
    public bool flag;
    //等待时间
    public float WaitTime;
    //y方向的间隔
    public float delty;
    //目标位置
    Vector3 target;

    // Use this for initialization
    void Start()
    {
        if (flag)
            target = new Vector3(transform.position.x - dis, transform.position.y+delty, transform.position.z);
        else
            target = new Vector3(transform.position.x + dis, transform.position.y+delty, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (WaitTime >= 0)
        {
            WaitTime -= 0.01f;
        }
        //向左移动
        if (WaitTime < 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

    }
}
