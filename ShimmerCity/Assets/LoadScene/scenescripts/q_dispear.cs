using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class q_dispear : MonoBehaviour {

    public Sprite newImage;
    public string objectName;
    public string objectName2;
    Sprite oldImage;
    Color c;
    Color c2;

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

        var d_object2 = GameObject.Find(objectName2);
        c2 = d_object2.GetComponent<SpriteRenderer>().color;
        c2.a = 0.0f;
        d_object2.gameObject.GetComponent<SpriteRenderer>().color = c2;

        Destroy(d_object.GetComponent<fadein_out>());
        Destroy(d_object2.GetComponent<fadein_out>());
    }
}
