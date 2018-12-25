using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Fpbar_controller : MonoBehaviour {

    public Sprite[] frames;
    private int Pre_freamNumber;
    public static int Current_frameNumber;
    public static bool bisAcquire_sister;
    public Transform target;
    private Animator animator;
    public static Fpbar_controller Instance;
    private bool bisShow;
    private SpriteRenderer render;

    public bool bisFull;
    public bool bisReleasing;

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
        bisFull = false;
        bisReleasing = false;
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
        if(SceneManager.GetActiveScene().name == "Part3" || SceneManager.GetActiveScene().name == "Part3_boss" || SceneManager.GetActiveScene().name == "Part4")
        {
            bisAcquire_sister = true;
        }
        if (bisAcquire_sister == true)
        {
            SisterHead_Control.Instance.Active();
            UIBGAddSister_Control.Instance.setActive();
        }
        if (Current_frameNumber >= 8 && bisShow == false)
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = 10;
            bisFull = true;
            Invoke("Hide", 3);
            //animator.SetTrigger("SetFull");
        }
        if(bisReleasing == true)
        {
            fpbarUI_Control.Instance.GetComponent<Slider>().value -= Time.deltaTime * 1.0f;
        }
        try
        {
            if (fpbarUI_Control.Instance.GetComponent<Slider>().value == 0)
            {
                CancelInvoke("SisterHead_decrease");
                bisReleasing = false;
                bisFull = false;
                bisShow = false;
            }
        }
        catch
        {

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
        if(bisAcquire_sister == false)
        {
            return;
        }
        if (bisReleasing == true)
            return;
        fpbarUI_Control.Instance.GetComponent<Slider>().value += 2.5f;
        if (bisAcquire_sister != true)
            return;
        //Pre_freamNumber = Current_frameNumber;
        Current_frameNumber++;
    }
    public void ReleaseSkill()
    {
        if (bisAcquire_sister == false)
            return;
        //if (bisReleasing == true)
        //    return;
        Current_frameNumber = 0;
        Pre_freamNumber = 0;
        //fpbarUI_Control.Instance.GetComponent<Slider>().value = 0;
        //animator.SetTrigger("SetNull");
        //bisShow = false;
        bisReleasing = true;
        InvokeRepeating("SisterHead_decrease", 0, 2.5f);
    }
    private void SisterHead_decrease()
    {
        GameObject.Find("Sister_Head").SendMessage("Fpbardecrease");
    }
}
