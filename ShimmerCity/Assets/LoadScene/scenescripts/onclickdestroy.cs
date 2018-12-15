using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onclickdestroy : MonoBehaviour {
    public Sprite newImage;
    public string objectName;
    Sprite oldImage;

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
        Destroy(d_object);
    }
}
