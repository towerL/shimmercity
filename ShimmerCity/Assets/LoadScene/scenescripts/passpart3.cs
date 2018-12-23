using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class passpart3 : MonoBehaviour {

    bool isdooropen = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var obj = GameObject.Find("door_01");
        isdooropen = obj.GetComponent<Animator>().GetBool("haskey");
		
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (isdooropen && col.gameObject.tag == "Player")
        {
            Debug.Log("!");
            SceneManager.LoadScene("ParaScene");
        }
    }
}
