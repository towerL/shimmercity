using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottle_handler : MonoBehaviour {

    public bool isground = false;
    GameObject icebottle;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isground)
        {
            Vector3 new_position = this.transform.position+new Vector3(2,2,0);
            icebottle = Instantiate(Resources.Load("prefabs/ice_bottle_1"), new_position, Quaternion.Euler(new Vector3(0, 0f, 0))) as GameObject;
            Destroy(gameObject);
        }
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="Ground")
        {
            isground = true;
        }
    }
}
