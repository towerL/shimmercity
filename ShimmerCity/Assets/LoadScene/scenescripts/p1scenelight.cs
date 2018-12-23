using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1scenelight : MonoBehaviour {
    //渐入渐出速度
    public float FadeSpeed;
    bool flag = true;
    Color c;
	// Use this for initialization
	void Start () {
        c = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	// Update is called once per frame
	void Update () {
        if (flag && gameObject.GetComponent<SpriteRenderer>().color.a > 0)
        {
            c.a -= FadeSpeed * Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = c;
            //if (gameObject.GetComponent<SpriteRenderer>().color.a <= 0) {
            //    while(gameObject.GetComponent<SpriteRenderer>().color.a < 1) {
            //        c.a += FadeSpeed * Time.deltaTime;
            //        gameObject.GetComponent<SpriteRenderer>().color = c;
            //    }
            //}
        }
        if (gameObject.GetComponent<SpriteRenderer>().color.a <= 0.0f) { flag = false; }
        if (!flag && gameObject.GetComponent<SpriteRenderer>().color.a < 1)
        {
            c.a += FadeSpeed * Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = c;
        }
        if (gameObject.GetComponent<SpriteRenderer>().color.a >= 0.9f) { flag = true; }
	}
}
