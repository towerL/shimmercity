using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRandMove : MonoBehaviour {

    float stopTime;//暂停时间
    float moveTime;//移动时间
    float vel_x, vel_y, vel_z;//速度
    /// <summary>
    /// 最大、最小飞行界限
    /// </summary>
    float maxPos_x = 10;
    float maxPos_y = 6;
    float minPos_x = -10;
    float minPos_y = -6;   
    float timeCounter1;//移动的计时器
    float timeCounter2;//暂停的计时器
    void Start()
    {
        Change();
    }
    // Update is called once per frame
    void Update()
    {
        var tmp = GameObject.Find("Y-5_06word3");
        if (tmp.GetComponent<SpriteRenderer>().color.a >= 0.99) {
            timeCounter1 += Time.deltaTime;
            //如果移动的计时器小于移动时间，则进行移动，否则暂停计时器累加，当暂停计时器大于暂停时间时，重置
            if (timeCounter1 < moveTime)
            {
                transform.Translate(vel_x, vel_y, 0, Space.Self);
            }
            else
            {
                timeCounter2 += Time.deltaTime;
                if (timeCounter2 > stopTime)
                {
                    Change();
                    timeCounter1 = 0;
                    timeCounter2 = 0;
                }
            }
            Check();
        }
    }
    //对参数赋值
    void Change()
    {
        stopTime = Random.Range(1, 5);
        moveTime = Random.Range(1, 20);
        vel_x = 0.15f;
        vel_y = 0.15f;
    }
    //判断是否达到边界，达到边界则将速度改为负的
    void Check()
    {
        //如果到达预设的界限位置值，调换速度方向并让它当前的坐标位置等于这个临界边的位置值
        if (transform.localPosition.x > maxPos_x)
        {
            vel_x = -vel_x;
            transform.localPosition = new Vector3(maxPos_x, transform.localPosition.y, 0);
        }
        if (transform.localPosition.x < minPos_x)
        {
            vel_x = -vel_x;
            transform.localPosition = new Vector3(minPos_x, transform.localPosition.y, 0);
        }
        if (transform.localPosition.y > maxPos_y)
        {
            vel_y = -vel_y;
            transform.localPosition = new Vector3(transform.localPosition.x, maxPos_y, 0);
        }
        if (transform.localPosition.y < minPos_y)
        {
            vel_y = -vel_y;
            transform.localPosition = new Vector3(transform.localPosition.x, minPos_y, 0);
        }
    }
}
