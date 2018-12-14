using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadein_out : MonoBehaviour {
    //渐入渐出速度
    public float FadeSpeed;
    //等待时间
    public float WaitTime;
    //当前透明度
    Color c;
    //渐入(T)OR渐出(F)
    public bool flag;

	void Start () {
        c = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void Update () {
        if (WaitTime >= 0) {
            WaitTime -= 0.01f;
        }
        if (WaitTime < 0 && flag && c.a < 1)
        {
            c.a += FadeSpeed * Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = c;
        }
        else if (WaitTime < 0 && !flag && c.a > 0)
        {
            c.a -= FadeSpeed * Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = c;
        }
	}
}
