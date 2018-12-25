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
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var obj = GameObject.Find("door_01");
        isdooropen = obj.GetComponent<Animator>().GetBool("haskey");
        if (player.transform.position.x < 16 && player.transform.position.x > 13)
        {
            if (player.transform.position.y < 10 && player.transform.position.y > 6)
            {
                if (isdooropen)
                    SceneManager.LoadScene("TriumphScene");
            }
        }

    }
}
