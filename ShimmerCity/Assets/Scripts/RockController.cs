using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour {
    //移动初始位置
    public float h0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //var v = transform.position;
        //v.y = Mathf.PingPong(h0, -13);
        if (transform.position.y < -8.0f)
        {
            var v = transform.position;
            v.y = h0;
            transform.position = v;
        }
	}
}
