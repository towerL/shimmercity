using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AItips : MonoBehaviour {
    int count = 0;
    //fade脚本
    void setPara(GameObject Object, float speed, float time, bool f)
    {
        Object.GetComponent<fadein_out>().FadeSpeed = speed;
        Object.GetComponent<fadein_out>().WaitTime = time;
        Object.GetComponent<fadein_out>().flag = f;
    }
    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(1.5f);
        print("WaitAndPrint " + Time.time);
    }
    IEnumerator receiveMsg()
    {
        count += 1;
        if(count==1){
            var tips1 = GameObject.Find("Y-4_01tips1");  
            tips1.AddComponent<fadein_out>();
            setPara(tips1, 2.0f, 0.0f, true);       
            yield return StartCoroutine("WaitAndPrint");
            tips1.GetComponent<SpriteRenderer>().enabled = false;
        }
        if(count==2){
            var tips2 = GameObject.Find("Y-4_02tips2");  
            tips2.AddComponent<fadein_out>();
            setPara(tips2, 2.0f, 0.0f, true);
            yield return StartCoroutine("WaitAndPrint");
            tips2.GetComponent<SpriteRenderer>().enabled = false;
        }
        if(count==3){
            var tips3 = GameObject.Find("Y-4_02tips3");  
            tips3.AddComponent<fadein_out>();
            setPara(tips3, 2.0f, 0.0f, true);
            yield return StartCoroutine("WaitAndPrint");
            tips3.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("count"+"sdahjh"+count);
	}

}
