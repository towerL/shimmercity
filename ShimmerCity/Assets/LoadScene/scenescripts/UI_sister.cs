using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UI_sister : MonoBehaviour {
    public Sprite newpic;
    public string name;
 	// Use this for initialization
    private Camera theCamera;
    private float upperDistance = 8.5f;
    private float lowerDistance=12.0f;
    private Transform tx;
    Vector3 sister_postion;
    bool visible = true;
    void Start()
    {
        if (!theCamera)
        {
            theCamera = Camera.main;
        }
        tx = theCamera.transform;
    }

	public void OnBecameVisible()
    {

    }

    //fade脚本
    void setPara(GameObject Object, float speed, float time, bool f) {
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

	// Update is called once per frame
	void Update () {
        sister_postion = gameObject.transform.position;
        if (visible && sister_postion.x >= tx.position.x - 16 && sister_postion.x <= tx.position.x + 16
            && sister_postion.y >= tx.position.y - 10 && sister_postion.y >= tx.position.y - 10)
        {
            var bg = GameObject.Find("S1-3_1bg_box");
            var sister_box = GameObject.Find("S1-3_2sister_box");
            var words = GameObject.Find("S1-3_3words");
            var OK = GameObject.Find("S1-3_4OK");
            bg.AddComponent<fadein_out>();
            setPara(bg, 2.0f, 0.0f, true);
            //bg.AddComponent<remove>();
            //setPara2(bg, 2.0f);

            sister_box.AddComponent<fadein_out>();
            setPara(sister_box, 2.0f, 0.3f, true);
            //sister_box.AddComponent<remove>();
            //setPara2(sister_box, 2.0f);

            words.AddComponent<fadein_out>();
            setPara(words, 2.0f, 0.8f, true);
            //words.AddComponent<remove>();
            //setPara2(words, 2.0f);

            OK.AddComponent<fadein_out>();
            setPara(OK, 2.0f, 1.1f, true);
            //OK.AddComponent<remove>();
            //setPara2(OK, 2.0f);
            //OK.AddComponent<onclickdestroy>();
            //setPara3(OK, newpic, name);

            var btn = GameObject.Find("Button_ok");
            EventTrigger trigger = btn.GetComponent<EventTrigger>();
            AddEventTrigger(btn.transform, EventTriggerType.PointerClick, myfun);
            AddEventTrigger(btn.transform, EventTriggerType.PointerEnter, myfun2);
            AddEventTrigger(btn.transform, EventTriggerType.PointerExit, myfun3);

            visible = false;
        }
	}

}
