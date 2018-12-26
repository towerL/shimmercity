using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class declarewarController : MonoBehaviour {
    bool flag = true;
    bool tmp = true;
	// Use this for initialization
	void Start () {
		
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
        var OK = GameObject.Find("Y-3_03icon");
        OK.GetComponent<onclickdestroy>().MouseClick();
    }

    void myfun2(BaseEventData eventData)
    {
        var OK = GameObject.Find("Y-3_03icon");
        OK.GetComponent<onclickdestroy>().MouseEnter();
    }
    void myfun3(BaseEventData eventData)
    {
        var OK = GameObject.Find("Y-3_03icon");
        OK.GetComponent<onclickdestroy>().MouseExit();
    }
	// Update is called once per frame
	void Update () {
        //var boss = GameObject.Find("boss");
        flag = gameObject.GetComponent<Animator>().GetBool("HasShown");
        if (!flag && tmp) {
            var bg4 = GameObject.Find("Y-3_01bg");
            var box = GameObject.Find("Y-3_02box");
            var icon = GameObject.Find("Y-3_03icon");

            bg4.AddComponent<fadein_out>();
            setPara(bg4, 3.0f, 0.0f, true);

            box.AddComponent<fadein_out>();
            setPara(box, 3.0f, 0.3f, true);

            icon.AddComponent<fadein_out>();
            setPara(icon, 3.0f, 0.5f, true);

            var btn = GameObject.Find("Button_pk");
            EventTrigger trigger = btn.GetComponent<EventTrigger>();
            AddEventTrigger(btn.transform, EventTriggerType.PointerClick, myfun);
            AddEventTrigger(btn.transform, EventTriggerType.PointerEnter, myfun2);
            AddEventTrigger(btn.transform, EventTriggerType.PointerExit, myfun3);
            tmp = false;
        }
	}
}
