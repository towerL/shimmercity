using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Attack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" )
        {
            Debug.Log("蜘蛛蜇人");
            //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
            GameObject.Find("Player").SendMessage("PlayerDecreaseHP", 3f);
        }
        if (collision.collider.tag == "deerbug" || collision.collider.tag == "Deerbug_long" || collision.collider.tag == "Start_mouse" || collision.collider.tag == "Spider")
        {
            Physics2D.IgnoreCollision(collision.collider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
