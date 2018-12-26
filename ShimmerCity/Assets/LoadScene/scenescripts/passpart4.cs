using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class passpart4 : MonoBehaviour {

    bool isdooropen = false;
    GameObject player;
    // Use this for initialization
    void Start()
    {
		player = GameObject.Find("player_clone(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
		
        var obj = GameObject.Find("door_01");
        isdooropen = obj.GetComponent<Animator>().GetBool("haskey");
		Debug.Log (isdooropen);
        if (player.transform.position.x < 17 && player.transform.position.x > 12)
        {
            if (player.transform.position.y < 10 && player.transform.position.y > 6)
            {
				Debug.Log ("!!!!");
                if (isdooropen)
                    SceneManager.LoadScene("TriumphScene");
            }
        }

    }
}
