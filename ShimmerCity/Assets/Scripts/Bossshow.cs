using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossshow : MonoBehaviour {

    Animator bs_an;
    GameObject boss;
    AudioSource aus;
    bool hasshown = false;
    public int part;
    public float timer = 1.0f;
	GameObject player;
	// Use this for initialization
	void Start () {
        bs_an = this.GetComponent<Animator>();
        aus = gameObject.GetComponent<AudioSource>();
        GameObject newplayer = Instantiate(Resources.Load("Prefabs/player_clone"), new Vector3(-0.113f, 7.14f,0.0f), Quaternion.identity) as GameObject;
        player = GameObject.Find("player_clone(Clone)");
    }
	
	// Update is called once per frame
	void Update () {
        var ui = GameObject.Find("boss");
        if (part == 3)
        {
            Debug.Log("?");
            if (!ui)
            {
                if (!hasshown)
                {


                    show();
                    bs_an.SetBool("HasShown", false);
                    if (timer <= -0.45f)
                    {
                            Vector3 new_position = this.transform.position + new Vector3(1, -5f, 0);
                            boss = Instantiate(Resources.Load("prefabs/boss1_1"), new_position, Quaternion.Euler(new Vector3(0, 0f, 0))) as GameObject;
                            hasshown = true;
                    }
                }
                if (timer <= -2.0f)
                {
                    bs_an.SetBool("HasShown", true);
                }
                timer -= Time.deltaTime;
            }
        }
        if(part==4)
        {
            Debug.Log("!");
            if (!hasshown)
            {
                show();
                bs_an.SetBool("HasShown", false);
                if (timer <= -0.45f)
                {
                        Vector3 new_position = this.transform.position + new Vector3(1, -5f, 0);
                        boss = Instantiate(Resources.Load("prefabs/pl_boss"), new_position, Quaternion.Euler(new Vector3(0, 0f, 0))) as GameObject;
                        hasshown = true;
                        player.SendMessage ("SetBossShow");
                }
            }
            if (timer <= -2.0f)
            {
				
                bs_an.SetBool("HasShown", true);
            }
            timer -= Time.deltaTime;
        }
	}
    void show()
    {
        AudioClip clip = (AudioClip)Resources.Load("Audios/coe/场景三/bossai登场", typeof(AudioClip));
        aus.clip = clip;
        aus.Play();
    }
}
