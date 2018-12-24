using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onclickpause : MonoBehaviour {
    public Sprite newImage;
    public string objectName;
    Sprite oldImage;
	// Use this for initialization
	void Start () {
        oldImage = gameObject.GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
		
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
        //转换相机视角到暂停界面
    }
}
