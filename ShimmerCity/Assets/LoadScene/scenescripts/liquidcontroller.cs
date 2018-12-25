using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class liquidcontroller : MonoBehaviour {

    //判断是否阅读过说明书
    bool hasRead = false;
    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(3.0f);
        //print("WaitAndPrint " + Time.time);
    }
    void Start()
    {

    }

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
    public void AddEventTrigger(Transform insObject, EventTriggerType eventType, UnityEngine.Events.UnityAction<BaseEventData> myFunction)//泛型委托
    {
        EventTrigger trigger = insObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventType;
        entry.callback.AddListener(myFunction);
        trigger.triggers.Add(entry);
    }
    void Update()
    {

    }
    IEnumerator OnTriggerEnter2D(Collider2D col)
    {
        if (!hasRead && col.tag == "Hands")
        {
            var bg3_4 = GameObject.Find("S3-4_1bg_box");
            var words3_4 = GameObject.Find("S3-4_2words1");
            var words3_4_2 = GameObject.Find("S3-4_2words2");
            var push_ani = GameObject.Find("push");
            var frozen_ani = GameObject.Find("frozen");

            bg3_4.AddComponent<fadein_out>();
            setPara(bg3_4, 2.0f, 0.0f, true);

            words3_4.AddComponent<fadein_out>();
            setPara(words3_4, 2.0f, 0.3f, true);
            push_ani.AddComponent<fadein_out>();
            setPara(push_ani, 2.0f, 0.3f, true);

            words3_4_2.AddComponent<fadein_out>();
            setPara(words3_4_2, 2.0f, 0.8f, true);
            frozen_ani.AddComponent<fadein_out>();
            setPara(frozen_ani, 2.0f, 0.8f, true);

            yield return StartCoroutine("WaitAndPrint");

            bg3_4.AddComponent<remove>();
            setPara2(bg3_4, 2.5f);

            words3_4.AddComponent<remove>();
            setPara2(words3_4, 2.5f);

            words3_4_2.AddComponent<remove>();
            setPara2(words3_4_2, 2.5f);

            push_ani.AddComponent<remove>();
            setPara2(push_ani, 2.5f);

            frozen_ani.AddComponent<remove>();
            setPara2(frozen_ani, 2.5f);

            hasRead = true;
        }
    }
}
