using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class onclickshow : MonoBehaviour {
    public Sprite newImage;
    Sprite oldImage;

    //fade脚本
    void setPara(GameObject Object, float speed, float time, bool f)
    {
        Object.GetComponent<fadein_out>().FadeSpeed = speed;
        Object.GetComponent<fadein_out>().WaitTime = time;
        Object.GetComponent<fadein_out>().flag = f;
    }

    void myfun(BaseEventData eventData)
    {
        var OK = GameObject.Find("restart");
        OK.GetComponent<switchscene_click>().MouseClick();
    }

    void myfun2(BaseEventData eventData)
    {
        var OK = GameObject.Find("restart");
        OK.GetComponent<switchscene_click>().MouseEnter();
    }
    void myfun3(BaseEventData eventData)
    {
        var OK = GameObject.Find("restart");
        OK.GetComponent<switchscene_click>().MouseExit();
    }

    void myfun4(BaseEventData eventData)
    {
        var OK = GameObject.Find("back");
        OK.GetComponent<switchscene_click>().MouseClick();
    }

    void myfun5(BaseEventData eventData)
    {
        var OK = GameObject.Find("back");
        OK.GetComponent<switchscene_click>().MouseEnter();
    }
    void myfun6(BaseEventData eventData)
    {
        var OK = GameObject.Find("back");
        OK.GetComponent<switchscene_click>().MouseExit();
    }

    public void AddEventTrigger(Transform insObject, EventTriggerType eventType, UnityEngine.Events.UnityAction<BaseEventData> myFunction)//泛型委托
    {
        EventTrigger trigger = insObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventType;
        entry.callback.AddListener(myFunction);
        trigger.triggers.Add(entry);
    }
    // Use this for initialization
    void Start()
    {
        oldImage = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MouseEnter()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = newImage;
    }

    public void MouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = oldImage;
    }

    public void MouseClick()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = newImage;
        oldImage = newImage;

        var bg = GameObject.Find("uibg");
        var continue1 = GameObject.Find("continue");
        var restart = GameObject.Find("restart");
        var setting = GameObject.Find("setting");
        var back = GameObject.Find("back");
        bg.AddComponent<fadein_out>();
        setPara(bg, 2.0f, 0.0f, true);

        continue1.AddComponent<fadein_out>();
        setPara(continue1, 2.0f, 0.3f, true);

        setting.AddComponent<fadein_out>();
        setPara(restart, 2.0f, 0.8f, true);

        back.AddComponent<fadein_out>();
        setPara(back, 2.0f, 1.1f, true);

        var btn = GameObject.Find("restartbtn");
        EventTrigger trigger = btn.GetComponent<EventTrigger>();
        AddEventTrigger(btn.transform, EventTriggerType.PointerClick, myfun);
        AddEventTrigger(btn.transform, EventTriggerType.PointerEnter, myfun2);
        AddEventTrigger(btn.transform, EventTriggerType.PointerExit, myfun3);

        var btn2 = GameObject.Find("backbtn");
        EventTrigger trigger2 = btn2.GetComponent<EventTrigger>();
        AddEventTrigger(btn2.transform, EventTriggerType.PointerClick, myfun4);
        AddEventTrigger(btn2.transform, EventTriggerType.PointerEnter, myfun5);
        AddEventTrigger(btn2.transform, EventTriggerType.PointerExit, myfun6);

    }
}
