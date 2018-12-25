using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class onclickpause : MonoBehaviour {
    public Sprite newImage;
    public string objectName;
    Sprite oldImage;
    Vector3 UI_Pos;
    Vector3 CamerPos;

	// Use this for initialization
	void Start () {
        oldImage = gameObject.GetComponent<SpriteRenderer>().sprite;
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            UI_Pos.x = -17.13199f;
            UI_Pos.y = -35.34001f;
            UI_Pos.z = -10;
        }
        else if (SceneManager.GetActiveScene().name == "Part2_1")
        {
            UI_Pos.x = -20.06f;
            UI_Pos.y = -85.73f;
            UI_Pos.z = -10;
        }
        else if (SceneManager.GetActiveScene().name == "Part3")
        {
            UI_Pos.x = 2.996008f;
            UI_Pos.y = -13.28501f;
            UI_Pos.z = -10;
        }
        else if (SceneManager.GetActiveScene().name == "Part3_boss")
        {
            UI_Pos.x = 2.86f;
            UI_Pos.y = -12.8f;
            UI_Pos.z = -10;
        }
        else if (SceneManager.GetActiveScene().name == "Part4")
        {
            UI_Pos.x = -0.8f;
            UI_Pos.y = -17.8f;
            UI_Pos.z = -10;
        }

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
        //GameObject.Find("Main Camera").gameObject.transform.position = CamerPos;
        //follow_player.bisPause = false;
    }

    public void MouseClick()
    {
        Time.timeScale = 0;
        //转换相机视角到暂停界面
        follow_player.bisPause = true;
        CamerPos = GameObject.Find("Main Camera").gameObject.transform.position;
        GameObject.Find("Main Camera").gameObject.transform.position = UI_Pos;
    }
}
