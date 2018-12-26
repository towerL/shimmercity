using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mayorlaugh : MonoBehaviour {

    AudioSource aus;
    float wait_time = 2.65f;
    bool hasplay = false;
    // Use this for initialization
    void Start () {
        aus = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (wait_time <= 0 && !hasplay)
        {
            AudioClip clip = (AudioClip)Resources.Load("Audios/coe/场景三/市长淫笑", typeof(AudioClip));
            aus.clip = clip;
            aus.Play();
            hasplay = true;
            Debug.Log("haslaugh");
        }
        else
            wait_time -= Time.deltaTime;
	}
}
