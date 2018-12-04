using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fpbar_controller : MonoBehaviour {

    public Sprite[] frames;
    private int frameNumber;
    public static bool bisAcquire_sister;
    public Transform target;
    public Transform Camera_pos;
    private Animator animator;
    public static Fpbar_controller Instance;

    private SpriteRenderer render;
    // Use this for initialization
    void Start () {
        bisAcquire_sister = false;
        frameNumber = 2;
        animator = GetComponent<Animator>();
        this.GetComponent<SpriteRenderer>().sortingOrder = -5;
        Instance = this;
        render = gameObject.GetComponent<SpriteRenderer>();

        render.sprite = frames[frameNumber];
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(frames.Length.ToString());
        if (bisAcquire_sister == true)
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = 5;
            //Texture2D img = frames[5];
            //Sprite _NewSprite = Sprite.Create(img, new Rect(0, 0, img.width, img.height), new Vector2(0.5f, 0.5f));
            //render.sprite = _NewSprite;
            Texture2D img = (Texture2D)Resources.Load("fp(5)");
            Sprite _NewSprite = Sprite.Create(img, render.sprite.textureRect, new Vector2(0.5f, 0.5f));
            render.sprite = _NewSprite;
        }
        if (frameNumber >= 8)
        {
            animator.SetTrigger("SetFull");
        }
        Vector3 _pos;
        _pos.x = target.transform.position.x + 14.2f;
        _pos.y = target.transform.position.y + 8f;
        _pos.z = target.transform.position.z + 1;

        this.transform.position = _pos;
    }
    public void Freame_Increase()
    {
        frameNumber++;
        if(frameNumber >= 8)
        {
            animator.SetTrigger("SetFull");
        }
    }
    private void ReleaseSkill()
    {
        frameNumber = 0;
        animator.SetTrigger("SetNull");
    }
}
