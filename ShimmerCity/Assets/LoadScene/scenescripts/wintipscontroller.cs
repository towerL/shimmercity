using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wintipscontroller : MonoBehaviour {

    void setPara(GameObject Object, float speed, float time, bool f)
    {
        Object.GetComponent<fadein_out>().FadeSpeed = speed;
        Object.GetComponent<fadein_out>().WaitTime = time;
        Object.GetComponent<fadein_out>().flag = f;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //flag = gameObject.GetComponent<Animator>().GetBool("HasShown");
        //if (!flag && tmp)
        //{
        //    var tip1 = GameObject.Find("Y-4_01tips1");
        //    var tip2 = GameObject.Find("Y-4_02tips2");
        //    var tip3 = GameObject.Find("Y-4_02tips3");

        //    tip1.AddComponent<fadein_out>();
        //    setPara(tip1, 3.0f, 0.0f, true);

        //    tip2.AddComponent<fadein_out>();
        //    setPara(tip2, 3.0f, 0.3f, true);

        //    tip3.AddComponent<fadein_out>();
        //    setPara(tip3, 3.0f, 0.6f, true);
        //    tmp = false;
        //}
	}
}
