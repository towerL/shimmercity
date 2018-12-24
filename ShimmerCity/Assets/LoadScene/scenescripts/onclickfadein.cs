using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class onclickfadein : MonoBehaviour {
    public Sprite newImage;
    Sprite oldImage;
    AudioSource aus;
	// Use this for initialization
	void Start () {
        oldImage = gameObject.GetComponent<SpriteRenderer>().sprite;
        aus = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //fade脚本
    void setPara(GameObject Object, float speed, float time, bool f)
    {
        Object.GetComponent<fadein_out>().FadeSpeed = speed;
        Object.GetComponent<fadein_out>().WaitTime = time;
        Object.GetComponent<fadein_out>().flag = f;
    }

    public void AddEventTrigger(Transform insObject, EventTriggerType eventType, UnityEngine.Events.UnityAction<BaseEventData> myFunction)//泛型委托
    {
        EventTrigger trigger = insObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventType;
        entry.callback.AddListener(myFunction);
        trigger.triggers.Add(entry);
    }

    void myfun(BaseEventData eventData)
    {
        var OK = GameObject.Find("S1-3_4OK");
        OK.GetComponent<onclickdestroy>().MouseClick();
    }

    void myfun2(BaseEventData eventData)
    {
        var OK = GameObject.Find("S1-3_4OK");
        OK.GetComponent<onclickdestroy>().MouseEnter();
    }
    void myfun3(BaseEventData eventData)
    {
        var OK = GameObject.Find("S1-3_4OK");
        OK.GetComponent<onclickdestroy>().MouseExit();
    }

    public void MouseEnter()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = newImage;
        mouse_touch();
    }

    public void MouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = oldImage;
    }

    public void MouseClick()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = newImage;
        //oldImage = newImage;
        var bg = GameObject.Find("1q_bg");
        var q_x = GameObject.Find("2q_x");

        bg.AddComponent<fadein_out>();
        setPara(bg, 2.0f, 0.0f, true);

        q_x.AddComponent<fadein_out>();
        setPara(q_x, 2.3f, 0.0f, true);
    }
    void mouse_touch()
    {
        AudioClip clip = (AudioClip)Resources.Load("Audios/coe/通用/鼠标接触", typeof(AudioClip));
        aus.clip = clip;
        aus.Play();
    }
}
