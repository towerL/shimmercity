using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onclick3 : MonoBehaviour {
    public Sprite newImage;
    //public Sprite newImage2;
    public string objectName;
    //public string objectName2;
    //移动距离
    //public float dis;
    //移动速度
    //public float speed;
    Sprite oldImage;
    //void setPara(GameObject Object, Sprite img, string name, float distance, float s)
    //{
    //    Object.GetComponent<onclickslideup>().newImage = img;
    //    Object.GetComponent<onclickslideup>().objectName = name;
    //    Object.GetComponent<onclickslideup>().dis = distance;
    //    Object.GetComponent<onclickslideup>().speed = s;
    //}

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
        var item = GameObject.Find(objectName);
        //Destroy(item.GetComponent("onclickslideup"));
        item.GetComponent<onclickslidedown>().hasclick = true;
        //item.AddComponent<onclickslideup>();
        //setPara(item, newImage2, objectName2, dis, speed);
    }
}
