using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_needkey : MonoBehaviour {
    bool isdead = false;
    bool isgeteyes = false;
    Renderer rd;
    //等待时间
    float waittime = 0.4f;
    bool tmp = true;//为了实现只动态加一次脚本
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

    // Use this for initialization
    void Start () {
        rd = this.GetComponent<Renderer>();
        rd.enabled = false;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (isdead && !isgeteyes)
        {
            var tip1 = GameObject.Find("Y-4_01tips1");
            var tip2 = GameObject.Find("Y-4_02tips2");
            var tip3 = GameObject.Find("Y-4_02tips3");
            if (tmp) {
                tip1.AddComponent<fadein_out>();
                setPara(tip1, 3.0f, 0.0f, true);

                tip2.AddComponent<fadein_out>();
                setPara(tip2, 2.0f, 0.5f, true);

                tip3.AddComponent<fadein_out>();
                setPara(tip3, 2.0f, 0.8f, true);
                tmp = false;
            }
            if (waittime >= 0)
            {
                waittime -= 0.01f;
            }
            if (waittime < 0)
            {
                tip1.AddComponent<remove>();
                setPara2(tip1, 0.5f);

                tip2.AddComponent<remove>();
                setPara2(tip2, 0.5f);

                tip3.AddComponent<remove>();
                setPara2(tip3, 0.5f);
            }
            rd.enabled = true;
        }
        if (isdead && isgeteyes)
        {
            rd.enabled = false;
        }
    }
    void bossdie()
    {
        isdead = true;
    }

    void getkey()
    {
        isgeteyes = true;
    }
}
