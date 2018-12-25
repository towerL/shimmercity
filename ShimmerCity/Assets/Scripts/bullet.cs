using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {


    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, 8);
	}
	
	// Update is called once per frame
	void Update () {
	  // Instantiate()
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            player.SendMessage("PlayerDecreaseHP", 5);
            Destroy(gameObject);
        }
        else
            return;
    }
}
