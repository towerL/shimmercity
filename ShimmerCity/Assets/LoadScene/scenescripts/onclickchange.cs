using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onclickchange : MonoBehaviour {
    public Sprite newImage;
    Sprite oldImage;
	void Start () {
        oldImage = gameObject.GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MouseClick()
    {
        if (gameObject.GetComponent<SpriteRenderer>().sprite == oldImage)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = newImage;
        }
        else {
            gameObject.GetComponent<SpriteRenderer>().sprite = oldImage;
        }
    }
}
