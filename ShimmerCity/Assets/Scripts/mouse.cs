using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour {

    Vector3 screenPosition;//将物体从世界坐标转换为屏幕坐标
    Vector3 mousePositionOnScreen;//获取到点击屏幕的屏幕坐标
    Vector3 mousePositionInWorld;//将点击屏幕的屏幕坐标转换为世界坐标
    Animator an;
    AudioSource aus;
    float timer = 0;
    void Start()
    {
        Cursor.visible = false;
        an = this.GetComponent<Animator>();
        aus = this.GetComponent<AudioSource>();
    }
    void Update()
    {
        Cursor.visible = false;
        MouseFollow();
        if(Input.GetMouseButtonDown(0))
        {
            mouseclick();
            an.SetBool("click", true);
            timer = 0.03f;
        }
   
        if (timer > 0)
            timer -= Time.deltaTime;
        else
        {
            an.SetBool("click", false);
            timer = 0;
        }
        

    }
    void MouseFollow()
    {
        //获取鼠标在相机中（世界中）的位置，转换为屏幕坐标；
        screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        //获取鼠标在场景中坐标
        mousePositionOnScreen = Input.mousePosition;
        //让场景中的Z=鼠标坐标的Z
        mousePositionOnScreen.z = screenPosition.z;
        //将相机中的坐标转化为世界坐标
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
        //物体跟随鼠标移动
        //transform.position = mousePositionInWorld;
        //物体跟随鼠标X轴移动
        transform.position = new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, transform.position.z);
    }

    void mouseclick()
    {
        AudioClip clip = (AudioClip)Resources.Load(("Audios/coe/通用/click4"), typeof(AudioClip));
        aus.clip = clip;
        aus.Play();
    }

}
