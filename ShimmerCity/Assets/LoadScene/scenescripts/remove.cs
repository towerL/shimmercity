using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remove : MonoBehaviour {

    //等待时间
    public float WaitTime;
    //当前透明度
    Color c;

    void Start()
    {
        c = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        if (WaitTime >= 0)
        {
            WaitTime -= 0.01f;
        }
        if (WaitTime < 0)
        {
            Destroy(gameObject);
        }
    }
}
