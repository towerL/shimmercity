using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fpbar_controller : MonoBehaviour {

    public Sprite[] frames;
    private int Pre_freamNumber;
    private int Current_frameNumber;
    public static bool bisAcquire_sister;
    public Transform target;
    public Transform Camera_pos;
    private Animator animator;
    public static Fpbar_controller Instance;
    private bool bisShow;
    private SpriteRenderer render;
    // Use this for initialization
    void Start () {
        bisAcquire_sister = false;
        animator = GetComponent<Animator>();
        this.GetComponent<SpriteRenderer>().sortingOrder = -10;
        Instance = this;
        render = gameObject.GetComponent<SpriteRenderer>();
        Pre_freamNumber = 0;
        Current_frameNumber = 0;
        bisShow = false;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(frames.Length.ToString());
        //if (bisAcquire_sister == true)
        //{
        //    this.GetComponent<SpriteRenderer>().sortingOrder = 10;
        //}
        //if(Pre_freamNumber != Current_frameNumber)
        //{
        //    animator.speed = 1;
        //    Pre_freamNumber = Current_frameNumber;
        //}

        if (Current_frameNumber >= 8 && bisShow == false)
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = 10;
            Invoke("Hide", 3);
            //animator.SetTrigger("SetFull");
        }
        Vector3 _pos;
        _pos.x = target.transform.position.x + 3.0f;
        _pos.y = target.transform.position.y;
        _pos.z = target.transform.position.z;
        this.transform.position = _pos;
    }
    void Hide()
    {
        render.sortingOrder = -10;
        bisShow = true;
    }
    private void Animation_Event_Function()
    {
        animator.speed = 0;
    }
    public void Freame_Increase()
    {
        if (bisAcquire_sister != true)
            return;
        Pre_freamNumber = Current_frameNumber;
        Current_frameNumber++;
    }
    private void ReleaseSkill()
    {
        Current_frameNumber = 0;
        Pre_freamNumber = 0;
        animator.SetTrigger("SetNull");
        bisShow = false;
    }
}
