using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            var door = GameObject.Find("door2");
            //bool isdooropen = door.GetComponent<Animator>().GetBool("IsDoorOpen");
            //if (isdooropen) {
            //    SceneManager.LoadScene("Part2_1");
            //}
            door.GetComponent<Animator>().SetBool("IsDoorOpen", true);
            SceneManager.LoadScene("Part2_1");
        }
    }
}
