using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ice_bottle : MonoBehaviour {

    bool flag = false;
    float timer = 5.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(timer<=0)
        {
            if (!flag)
            {
                Vector3 new_position = new Vector3(1.29f, 8.28f, 0);
                GameObject bottle = Instantiate(Resources.Load("prefabs/bottle"), new_position, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
            }
            Destroy(gameObject);
        }
        timer -= Time.deltaTime;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "boss")
        {
            flag = true;
        }
    }
}
