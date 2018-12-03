using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenStoneController : MonoBehaviour {
    public string stone_name;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Stone")
    //    {
    //        var falling_stone = GameObject.Find(stone_name);
    //        falling_stone.GetComponent<SpriteRenderer>().enabled = false;
    //        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    //    }
    //}
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Stone")
        {
            var falling_stone = GameObject.Find(stone_name);
            falling_stone.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            falling_stone.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
