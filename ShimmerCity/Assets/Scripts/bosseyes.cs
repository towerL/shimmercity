﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bosseyes : MonoBehaviour {

	public int part;
    float radian = 0; // 弧度
    float perRadian = 0.03f; // 每次变化的弧度
    float radius = 0.2f; // 半径
    Vector3 oldPos; // 开始时候的坐标
    GameObject door;
    GameObject door_tag;
	GameObject player;
    // Use this for initialization
    void Start()
    {
        oldPos = transform.position; // 将最初的位置保存到oldPos
        door = GameObject.Find("door_01");
        door_tag = GameObject.Find("door_tag");
		if(SceneManager.GetActiveScene ().name=="Part3_boss") 
       	 	player = GameObject.Find("player_clone(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        radian += perRadian; // 弧度每次加0.03
        float dy = Mathf.Cos(radian) * radius; // dy定义的是针对y轴的变量，也可以使用sin，找到一个适合的值就可以
        transform.position = oldPos + new Vector3(0, dy, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="Player")
        {
            door.SendMessage("getkey");
            door_tag.SendMessage("getkey");
			if(SceneManager.GetActiveScene ().name=="Part3_boss") 
				player.SendMessage ("SetBossEyes");
            Destroy(gameObject);
        }
    }


}
