using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Controller : MonoBehaviour {

    public float move_Step;
    public float OriginY;
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
    void Return()
    {
        //Vector3 OriginPos;
        //OriginPos = transform.position;
        //OriginPos.y = OriginY + -69.04f;
        //transform.position = OriginPos;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player" || collision.collider.tag == "hammer_in_attack")
        {
            Debug.Log("蜘蛛蜇人");
            //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
            GameObject.Find("Player").SendMessage("PlayerDecreaseHP", 10f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Hands")
        {
            Debug.Log("蜘蛛蜇人");
            //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
            GameObject.Find("Player").SendMessage("PlayerDecreaseHP", 10f);
        }
    }
}
