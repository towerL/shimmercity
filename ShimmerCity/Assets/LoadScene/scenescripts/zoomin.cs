using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomin : MonoBehaviour {
    Vector3 start;
    Vector3 end;
	// Use this for initialization
	void Start () {
        start = gameObject.GetComponent<SpriteRenderer>().transform.localScale;
        end = new Vector3(1.0f, 1.0f, 1.0f);
	}

	
	// Update is called once per frame
    void Update()
    {
        start = Vector3.Slerp(start, end, Time.smoothDeltaTime * start.x * 1.0f);
        gameObject.GetComponent<SpriteRenderer>().transform.localScale = start;
    }
}
