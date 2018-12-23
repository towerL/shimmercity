using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class passpart4 : MonoBehaviour {

    bool isdooropen = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var obj = GameObject.Find("door_01");
        isdooropen = obj.GetComponent<Animator>().GetBool("IsOpen");

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (isdooropen && col.tag == "Hands")
        {
            SceneManager.LoadScene("TriumphScene");
        }
    }
}
