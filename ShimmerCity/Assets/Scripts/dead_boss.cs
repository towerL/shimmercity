using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dead_boss : MonoBehaviour {


    float e_timer = 1.2f;
    Animator e_an;
    GameObject eyes;
    GameObject door;
    GameObject door_tag;
    bool isshow = false;
	// Use this for initialization
	void Start () {
        e_an = this.GetComponent<Animator>();
        door = GameObject.Find("door_01");
        door_tag = GameObject.Find("door_tag");
	}
	
	// Update is called once per frame
	void Update () {
        if (e_timer >= 0)
            e_timer = e_timer - Time.deltaTime;
        else
        {
            e_an.speed = 0;
            door.SendMessage("bossdie");
            door_tag.SendMessage("bossdie");
            if (!isshow)
            {
                Vector3 new_position = this.transform.position;
                eyes =  Instantiate(Resources.Load("prefabs/Bosseyes"), new_position, Quaternion.Euler(new Vector3(0, 0f, 0))) as GameObject;
                isshow = true;
            }
        }
	}
}
