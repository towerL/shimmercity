using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p3_door : MonoBehaviour {

    Animator do_an;
    bool isdead = false;
    bool isgeteyes = false;
    float timer = 0;
    int count = 0;
    AudioSource aus;
	// Use this for initialization
	void Start () {
        do_an = this.GetComponent<Animator>();
        aus = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!isdead)
        {
            do_an.SetBool("IsOpen", true);
            if(timer==0)
            {
                Vector3 new_position = this.transform.position;
                var lightning = Instantiate(Resources.Load("prefabs/lightning"), new_position, Quaternion.Euler(new Vector3(0, 0f, 0))) as GameObject;
                lightning.SendMessage("setspeedx", 1.0f);
                lightning.SendMessage("setspeedy", 1.0f);
                lightning_1();
                count++;
            }
            if(timer>=30&&count==1)
            {
                Vector3 new_position = this.transform.position;
                var lightning = Instantiate(Resources.Load("prefabs/lightning"), new_position, Quaternion.Euler(new Vector3(0, 0f, 0))) as GameObject;
                lightning.SendMessage("setspeedx", 2.0f);
                lightning.SendMessage("setspeedy", 1.0f);
                lightning_1();
                count++;
            }
            if (timer >= 60 && count == 2)
            {
                Vector3 new_position = this.transform.position;
                var lightning = Instantiate(Resources.Load("prefabs/lightning"), new_position, Quaternion.Euler(new Vector3(0, 0f, 0))) as GameObject;
                lightning.SendMessage("setspeedx", 1.0f);
                lightning.SendMessage("setspeedy", 2.0f);
                lightning_1();
                count++;
            }
            if (timer >= 90 && count == 3)
            {
                Vector3 new_position = this.transform.position;
                var lightning = Instantiate(Resources.Load("prefabs/lightning"), new_position, Quaternion.Euler(new Vector3(0, 0f, 0))) as GameObject;
                lightning.SendMessage("setspeedx", -1.0f);
                lightning.SendMessage("setspeedy", 1.0f);
                count++;
            }
            if (timer >= 120 && count == 4)
            {
                Vector3 new_position = this.transform.position;
                var lightning = Instantiate(Resources.Load("prefabs/lightning"), new_position, Quaternion.Euler(new Vector3(0, 0f, 0))) as GameObject;
                lightning.SendMessage("setspeedx", 1.0f);
                lightning.SendMessage("setspeedy", -1.0f);
                lightning_1();
                count++;
            }
            timer += Time.deltaTime;
        }
        else if(isdead&& !isgeteyes)
        {
            do_an.SetBool("IsOpen", false);
            do_an.SetBool("needkey", true);
        }
        else if(isdead&&isgeteyes)
        {
            do_an.SetBool("IsOpen", false);
            do_an.SetBool("needkey", false);
            do_an.SetBool("haskey", true);
        }
	}

    void lightning_1()
    {
        AudioClip clip;
        clip = (AudioClip)Resources.Load("Audios/coe/场景三/放闪电", typeof(AudioClip));
        aus.clip = clip;
        aus.Play();
    }


    void bossdie()
    {
        isdead = true;
    }

    void getkey()
    {
        isgeteyes = true;
    }
}
