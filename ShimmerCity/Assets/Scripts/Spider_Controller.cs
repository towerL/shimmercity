using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Controller : MonoBehaviour {

    public float move_Step;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Spider_Down()
    {
        foreach(Transform child in transform)
        {
            //Debug.Log("Spider down");
            Vector3 _pos = child.position;
            _pos.y += move_Step;
            child.transform.position = _pos;
        }
    }
    void Spider_Up()
    {
        foreach (Transform child in transform)
        {
            //Debug.Log("Spider up");
            Vector3 _pos = child.position;
            _pos.y -= move_Step;
            child.transform.position = _pos;
        }
    }
}
