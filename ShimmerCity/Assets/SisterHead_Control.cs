using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SisterHead_Control : MonoBehaviour {
    public static SisterHead_Control Instance;

    public Texture2D[] Frames;

    private int frameNum;
    // Use this for initialization
    void Start () {
        Instance = this;
        frameNum = 0;
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnGUI()
    {
        this.GetComponent<Image>().sprite = Sprite.Create(Frames[frameNum], new Rect(0, 0, Frames[frameNum].width, Frames[frameNum].height), new Vector2(0, 0));
    }
    public void Fpbaradd()
    {
        if(frameNum >= Frames.Length)
        {
            return;
        }
        frameNum++;
    }
    public void Active()
    {
        this.gameObject.SetActive(true);
    }
}
