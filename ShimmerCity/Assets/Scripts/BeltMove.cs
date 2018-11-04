//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BeltMove : MonoBehaviour {
//    //目标位置
//    public Transform target;
//    //移动距离
//    public float dis;

//    void Start () {
//        dis = Vector2.Distance(transform.position, target.position);
//    }

//    void Update()
//    {
//        transform.position = Vector2.MoveTowards(transform.position, target.position, (dis / 3f) * Time.deltaTime);
//    }
//}
