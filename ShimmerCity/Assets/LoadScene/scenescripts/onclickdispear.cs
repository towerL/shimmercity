using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onclickdispear : MonoBehaviour {
    public Sprite newImage;
    public string objectName;
    Sprite oldImage;
    Color c;

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
        var d_object = GameObject.Find(objectName);
        c = d_object.GetComponent<SpriteRenderer>().color;
        c.a = 0.0f;
        d_object.gameObject.GetComponent<SpriteRenderer>().color = c;
    }
}
