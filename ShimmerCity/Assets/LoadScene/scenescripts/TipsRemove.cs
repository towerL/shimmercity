using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsRemove : MonoBehaviour {
    //等待时间
    public float WaitTime;
    //移动距离
    public float dis;
    //移动速度
    public float speed;
    //1：上 2：左 3：右
    public int flag;
    //目标位置
    Vector3 target;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (WaitTime >= 0)
        {
            WaitTime -= 0.01f;
            if (flag == 1)
                target = new Vector3(transform.position.x, transform.position.y + dis, transform.position.z);
            else if (flag == 2)
                target = new Vector3(transform.position.x - dis, transform.position.y, transform.position.z);
            else if (flag == 3)
                target = new Vector3(transform.position.x + dis, transform.position.y, transform.position.z);
            else if (flag == 4)
                target = new Vector3(transform.position.x, transform.position.y - dis, transform.position.z);
        }
        if (WaitTime < 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
	}
}
