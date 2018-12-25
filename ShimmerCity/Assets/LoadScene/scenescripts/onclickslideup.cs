using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onclickslideup : MonoBehaviour {

    public Sprite newImage;
    public string objectName;
    //public string objectName2;
    //移动距离
    public float dis;
    //移动速度
    public float speed;
    //向上移动为true 向下移动为false
    Sprite oldImage;
    //目标位置
    Vector3 target;
    Vector3 target2;
    //Vector3 target2;
    bool flag = false;
    AudioSource aus;
    bool tmp = true;//用来判断是滑入还是滑出
    public bool hasclick;
    bool click = true;
    float start_x;
    float start_y;
    // Use this for initialization
    void Start()
    {
        oldImage = gameObject.GetComponent<SpriteRenderer>().sprite;
        var item = GameObject.Find(objectName);
        start_x = item.transform.position.x;//水平移动的起点
        start_y = item.transform.position.y;//竖直移动的起点
        //var item2 = GameObject.Find(objectName2);
        target = new Vector3(item.transform.position.x, item.transform.position.y - dis, transform.position.z);
        target2 = item.transform.position;
        //target2 = new Vector3(item2.transform.position.x, item2.transform.position.y - dis, transform.position.z);
        aus = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            var item = GameObject.Find(objectName);
            if (System.Math.Abs(item.transform.position.y - start_y) >= 0.1f && hasclick)
            {
                //var item = GameObject.Find(objectName);
                item.transform.position = Vector3.MoveTowards(item.transform.position, target2, speed * Time.deltaTime);
                click = false;
            }
            else if (System.Math.Abs(item.transform.position.y - start_y) <= dis && click) {
                //var item = GameObject.Find(objectName);
                item.transform.position = Vector3.MoveTowards(item.transform.position, target, speed * Time.deltaTime);
            }          
            //var item2 = GameObject.Find(objectName2);
            //item2.transform.position = Vector3.MoveTowards(item2.transform.position, target2, speed * Time.deltaTime);
        }
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
        flag = true;
        click = true;
        if (tmp)
        {
            hasclick = false;
            tmp = false;
        }
        else if (!tmp)
        {
            hasclick = true;
            tmp = true;
        }
    }
    void mouse_touch()
    {
        AudioClip clip = (AudioClip)Resources.Load("Audios/coe/通用/鼠标接触", typeof(AudioClip));
        aus.clip = clip;
        aus.Play();
    }
}
