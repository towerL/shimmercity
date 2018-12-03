using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour {
    //移动初始位置
    float h0;
    public float speed;
    float mytime = 10.0f;

	void Start () {
        h0 = transform.position.y;
	}
	
	void Update () {
        mytime-=Time.deltaTime;
        if (System.Math.Abs(transform.position.y - h0) <= 15.0f) {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }      
        if (mytime<0)
        {
            var v = transform.position;
            v.y = h0;
            transform.position = v;
            mytime = 10.0f;
        }
	}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.tag == "Ground")
    //    {
    //        var v = transform.position;
    //        v.y = h0;
    //        transform.position = v;
    //    }
    //}
}
