using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class passpart3 : MonoBehaviour {

    bool isdooropen = false;
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        var obj = GameObject.Find("door_01");
        isdooropen = obj.GetComponent<Animator>().GetBool("haskey");
        if(player.transform.position.x<16&& player.transform.position.x > 13)
        {
            if (player.transform.position.y < 10 && player.transform.position.y > 6)
            {
                if(isdooropen)
                    SceneManager.LoadScene("ParaScene");
            }
        }
		
	}
    /*
    void OnCollisionEnter2D(Collision2D col)
    {
        if ((isdooropen && col.gameObject.tag == "Player") || (isdooropen && col.gameObject.tag == "hammer_in_attack"))
        {
            Debug.Log("!");
            SceneManager.LoadScene("ParaScene");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (isdooropen && col.tag == "Player")
        {
            Debug.Log("!");
            SceneManager.LoadScene("ParaScene");
        }
    }
    */
}
