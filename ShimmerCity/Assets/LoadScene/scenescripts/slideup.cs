using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideup : MonoBehaviour {
    //移动距离
    public float dis;
    //移动速度
    public float speed;
    //向上移动为true 向下移动为false
    public bool flag;
    //等待时间
    public float WaitTime;
    //目标位置
    Vector3 target;

    // Use this for initialization
    void Start()
    {
        if (flag)
            target = new Vector3(transform.position.x, transform.position.y + dis, transform.position.z);
        else
            target = new Vector3(transform.position.x, transform.position.y - dis, transform.position.z);
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
