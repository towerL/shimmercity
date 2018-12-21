using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onclickslidedown : MonoBehaviour
{

    public Sprite newImage;
    public string objectName;
    public string objectName2;
    //移动距离
    public float dis;
    //移动速度
    public float speed;
    //向上移动为true 向下移动为false
    Sprite oldImage;
    //目标位置
    Vector3 target;
    Vector3 target2;
    bool flag = false;

    // Use this for initialization
    void Start()
    {
        oldImage = gameObject.GetComponent<SpriteRenderer>().sprite;
        var item = GameObject.Find(objectName);
        var item2 = GameObject.Find(objectName2);
        target = new Vector3(item.transform.position.x, item.transform.position.y - dis, transform.position.z);
        target2 = new Vector3(item2.transform.position.x, item2.transform.position.y - dis, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            var item = GameObject.Find(objectName);
            item.transform.position = Vector3.MoveTowards(item.transform.position, target, speed * Time.deltaTime);
            var item2 = GameObject.Find(objectName2);
            item2.transform.position = Vector3.MoveTowards(item2.transform.position, target2, speed * Time.deltaTime);
        }
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
        //oldImage = newImage;
        flag = true;
    }
}
