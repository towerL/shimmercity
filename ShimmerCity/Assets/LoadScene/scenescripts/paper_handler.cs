﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class paper_handler : MonoBehaviour {

    //是否第一次进入
    bool hasEnter = true;

    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(1.0f);
        print("WaitAndPrint " + Time.time);
    }


    //fade脚本
    void setPara(GameObject Object, float speed, float time, bool f)
    {
        Object.GetComponent<fadein_out>().FadeSpeed = speed;
        Object.GetComponent<fadein_out>().WaitTime = time;
        Object.GetComponent<fadein_out>().flag = f;
    }

    //remove脚本
    void setPara2(GameObject Object, float time)
    {
        Object.GetComponent<remove>().WaitTime = time;
    }

    //slideup脚本
    void setPara3(GameObject Object, float dis, float speed, bool flag, float time)
    {
        Object.GetComponent<slideup>().dis = dis;
        Object.GetComponent<slideup>().speed = speed;
        Object.GetComponent<slideup>().flag = flag;
        Object.GetComponent<slideup>().WaitTime = time;
    }

    //slidein脚本
    void setPara4(GameObject Object, float dis, float speed, bool flag, float time,float delty)
    {
        Object.GetComponent<newslidein>().dis = dis;
        Object.GetComponent<newslidein>().speed = speed;
        Object.GetComponent<newslidein>().flag = flag;
        Object.GetComponent<newslidein>().WaitTime = time;
        Object.GetComponent<newslidein>().delty = delty;
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    void Update()
    {
        var word2 = GameObject.Find("S6_6word2");
        if (word2.GetComponent<SpriteRenderer>().color.a >= 0.99) {
            SceneManager.LoadScene("connectScene2");
        }
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Hands" && hasEnter)
        {
            Debug.Log("玩家进入");
            var bg6_1 = GameObject.Find("S6_1bg");
            var hero1 = GameObject.Find("S6_1hero");
            var paper6_1 = GameObject.Find("S6_1paper");

            var word1 = GameObject.Find("S6_2word");

            var giveup = GameObject.Find("S6_3giveup");
            var manual = GameObject.Find("S6_3manual");

            var hero2 = GameObject.Find("S6_4hero2");
            var flashes = GameObject.Find("S6_5flashes");
            var word2 = GameObject.Find("S6_6word2");

            //第一组淡入
            bg6_1.AddComponent<fadein_out>();
            setPara(bg6_1, 2.0f, 0.0f, true);
            hero1.AddComponent<fadein_out>();
            setPara(hero1, 2.0f, 0.0f, true);
            paper6_1.AddComponent<fadein_out>();
            setPara(paper6_1, 2.0f, 0.0f, true);
            paper6_1.AddComponent<remove>();
            setPara2(paper6_1,1.0f);

            word1.AddComponent<fadein_out>();
            setPara(word1, 2.0f, 1.0f, true);
            word1.AddComponent<remove>();
            setPara2(word1,2.0f);

            //第二组滑入
            giveup.AddComponent<slideup>();
            setPara3(giveup, 6.0f, 5.0f, true,3.0f);
            manual.AddComponent<slideup>();
            setPara3(manual, 6.0f, 5.0f, true, 3.0f);

            giveup.AddComponent<newslidein>();
            setPara4(giveup, 5.2f, 8.0f, true, 3.5f,6.0f);

            //第三组淡入
            hero2.AddComponent<fadein_out>();
            setPara(hero2, 2.0f, 4.5f, true);
            flashes.AddComponent<fadein_out>();
            setPara(flashes, 10.0f, 4.8f, true);
            word2.AddComponent<fadein_out>();
            setPara(word2, 2.0f, 5.3f, true);



            //Debug.Log("test");

            //hasEnter = false;
            //Destroy(this.gameObject);

        }
    }
}
