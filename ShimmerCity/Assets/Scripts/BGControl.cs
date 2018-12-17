using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BGControl : MonoBehaviour {
    public static BGControl Instance;
    //获取black颜色
    Color a;
    //有无提示过
    bool hasTips = false;

    //fade脚本
    void setPara(GameObject Object, float speed, float time, bool f)
    {
        Object.GetComponent<fadein_out>().FadeSpeed = speed;
        Object.GetComponent<fadein_out>().WaitTime = time;
        Object.GetComponent<fadein_out>().flag = f;
    }

    //remove脚本
    void setPara2(GameObject Object, float time)
    {
        Object.GetComponent<remove>().WaitTime = time;
    }

    //onclickdestroy脚本
    void setPara3(GameObject Object, Sprite img, string n)
    {
        Object.GetComponent<onclickdestroy>().newImage = img;
        Object.GetComponent<onclickdestroy>().objectName = n;
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
        var OK = GameObject.Find("S5_2OK");
        OK.GetComponent<onclickdestroy>().MouseClick();
    }

    void myfun2(BaseEventData eventData)
    {
        var OK = GameObject.Find("S5_2OK");
        OK.GetComponent<onclickdestroy>().MouseEnter();
    }
    void myfun3(BaseEventData eventData)
    {
        var OK = GameObject.Find("S5_2OK");
        OK.GetComponent<onclickdestroy>().MouseExit();
    }

	// Use this for initialization
	void Start () {
        var bg = GameObject.Find("black");
        a = bg.GetComponent<SpriteRenderer>().color;
        Instance = this;

    }
	
	// Update is called once per frame
	void Update () {
        var bg = GameObject.Find("black");
        if (!hasTips && bg.GetComponent<SpriteRenderer>().color.a > 0.15) {
            var bg5_1 = GameObject.Find("S5_1bg");
            var OK5_1 = GameObject.Find("S5_2OK");
            bg5_1.AddComponent<fadein_out>();
            setPara(bg5_1, 2.0f, 0.0f, true);

            OK5_1.AddComponent<fadein_out>();
            setPara(OK5_1, 2.0f, 0.5f, true);

            var btn = GameObject.Find("Button_ok3");
            EventTrigger trigger = btn.GetComponent<EventTrigger>();
            AddEventTrigger(btn.transform, EventTriggerType.PointerClick, myfun);
            AddEventTrigger(btn.transform, EventTriggerType.PointerEnter, myfun2);
            AddEventTrigger(btn.transform, EventTriggerType.PointerExit, myfun3);

            hasTips = true;
        }
	}
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.collider.tag == "deerbug")
        {
            var bg = GameObject.Find("black");
            a.a += 0.0001f;
            bg.GetComponent<SpriteRenderer>().color = a;
        }
    }
    private void OnCollisionExit2D(Collision2D collision) {
        var door = GameObject.Find("door1");
        bool isdooropen = door.GetComponent<Animator>().GetBool("IsDoorOpen");
        if (collision.collider.tag == "deerbug" && !isdooropen)
        {
            var bg = GameObject.Find("black");
            a.a = 0;
            bg.GetComponent<SpriteRenderer>().color = a;
        }
    }
}
