using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SwitchScene : MonoBehaviour {

    //有无锤子
    bool hasHammer;

    //有无妹妹
    bool hasSister;

    //是否第一次进入
    bool hasEnter = true;
    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(1.5f);
        print("WaitAndPrint " + Time.time);
    }

	// Use this for initialization
	void Start () {
        var player = GameObject.Find("Player");
        hasHammer = player.GetComponent<Animator>().GetBool("isHammer");
        hasSister = player.GetComponent<Animator>().GetBool("isSister");
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
        var OK = GameObject.Find("S1-7_4thinking");
        OK.GetComponent<onclickdestroy>().MouseClick();
    }

    void myfun2(BaseEventData eventData)
    {
        var OK = GameObject.Find("S1-7_4thinking");
        OK.GetComponent<onclickdestroy>().MouseEnter();
    }
    void myfun3(BaseEventData eventData)
    {
        var OK = GameObject.Find("S1-7_4thinking");
        OK.GetComponent<onclickdestroy>().MouseExit();
    }
    void myfun4(BaseEventData eventData)
    {
        var OK = GameObject.Find("S1-7_5confirm");
        OK.GetComponent<onclickdestroy>().MouseClick();

        var door = GameObject.Find("door2");
        door.GetComponent<Animator>().SetBool("IsDoorOpen", true);
        
    }

    void myfun5(BaseEventData eventData)
    {
        var OK = GameObject.Find("S1-7_5confirm");
        OK.GetComponent<onclickdestroy>().MouseEnter();
    }
    void myfun6(BaseEventData eventData)
    {
        var OK = GameObject.Find("S1-7_5confirm");
        OK.GetComponent<onclickdestroy>().MouseExit();
    }
    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (!hasEnter)
            {
                var door = GameObject.Find("door2");
                door.GetComponent<Animator>().SetBool("IsDoorOpen", true);
                SceneManager.LoadScene("Part2_1");
            }

            if (!hasSister && hasHammer && hasEnter) {
                var bg1_6 = GameObject.Find("S1-6_1bg_box");
                var purple1_6 = GameObject.Find("S1-6_2purple");
                var words1_6 = GameObject.Find("S1-6_3words");
               
                bg1_6.AddComponent<fadein_out>();
                setPara(bg1_6, 2.0f, 0.0f, true);

                purple1_6.AddComponent<fadein_out>();
                setPara(purple1_6, 2.0f, 0.3f, true);

                words1_6.AddComponent<fadein_out>();
                setPara(words1_6, 2.0f, 0.8f, true);

                yield return StartCoroutine("WaitAndPrint");

                bg1_6.AddComponent<remove>();
                setPara2(bg1_6, 2.0f);

                purple1_6.AddComponent<remove>();
                setPara2(purple1_6, 2.0f);

                words1_6.AddComponent<remove>();
                setPara2(words1_6, 2.0f);
            }
            if (!hasSister && !hasHammer && hasEnter) {
                var bg1_7 = GameObject.Find("S1-7_1bg_box");
                var mayor1_7 = GameObject.Find("S1-7_2mayor_box");
                var words1_7 = GameObject.Find("S1-7_3words");
                var thinking1_7 = GameObject.Find("S1-7_4thinking");
                var confirm1_7 = GameObject.Find("S1-7_5confirm");

                bg1_7.AddComponent<fadein_out>();
                setPara(bg1_7, 2.0f, 0.0f, true);

                mayor1_7.AddComponent<fadein_out>();
                setPara(mayor1_7, 2.0f, 0.3f, true);

                words1_7.AddComponent<fadein_out>();
                setPara(words1_7, 2.0f, 0.8f, true);

                thinking1_7.AddComponent<fadein_out>();
                setPara(thinking1_7, 2.0f, 1.1f, true);

                confirm1_7.AddComponent<fadein_out>();
                setPara(confirm1_7, 2.0f, 1.1f, true);

                var btn_thinking = GameObject.Find("Button_thinking");
                EventTrigger trigger = btn_thinking.GetComponent<EventTrigger>();
                AddEventTrigger(btn_thinking.transform, EventTriggerType.PointerClick, myfun);
                AddEventTrigger(btn_thinking.transform, EventTriggerType.PointerEnter, myfun2);
                AddEventTrigger(btn_thinking.transform, EventTriggerType.PointerExit, myfun3);

                var btn_confirm = GameObject.Find("Button_confirm");
                EventTrigger trigger2 = btn_thinking.GetComponent<EventTrigger>();
                AddEventTrigger(btn_confirm.transform, EventTriggerType.PointerClick, myfun4);
                AddEventTrigger(btn_confirm.transform, EventTriggerType.PointerEnter, myfun5);
                AddEventTrigger(btn_confirm.transform, EventTriggerType.PointerExit, myfun6);
            }
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.tag == "Player") { 
            hasEnter = false;
        }
    }
}
