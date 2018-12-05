using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGControl : MonoBehaviour {
    public static BGControl Instance;
    //获取black颜色
    Color a;
	// Use this for initialization
	void Start () {
        var bg = GameObject.Find("black");
        a = bg.GetComponent<SpriteRenderer>().color;
        Instance = this;

    }
	
	// Update is called once per frame
	void Update () {

	}
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.collider.tag == "deerbug")
        {
            var bg = GameObject.Find("black");
            a.a += 0.0001f;
            bg.GetComponent<SpriteRenderer>().color = a;
        }
    }
    private void OnCollisionExit2D(Collision2D collision) {
        var door = GameObject.Find("door1");
        bool isdooropen = door.GetComponent<Animator>().GetBool("IsDoorOpen");
        if (collision.collider.tag == "deerbug" && !isdooropen)
        {
            var bg = GameObject.Find("black");
            a.a = 0;
            bg.GetComponent<SpriteRenderer>().color = a;
        }
    }
}
