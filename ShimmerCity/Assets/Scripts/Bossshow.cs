using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossshow : MonoBehaviour {

    Animator bs_an;
    GameObject boss;
    bool hasshown = false;
    float timer = 1.0f;
	// Use this for initialization
	void Start () {
        bs_an = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasshown)
        {
            bs_an.SetBool("HasShown", false);
            if (timer <= -0.45f)
            {
                Vector3 new_position = this.transform.position + new Vector3(1, -5.5f, 0);
                boss = Instantiate(Resources.Load("prefabs/boss1_1"), new_position, Quaternion.Euler(new Vector3(0, 0f, 0))) as GameObject;
                hasshown = true;
            }
        }
        if(timer<=-2.0f)
        {
            bs_an.SetBool("HasShown", true);
        }
        timer -= Time.deltaTime;
	}
}
