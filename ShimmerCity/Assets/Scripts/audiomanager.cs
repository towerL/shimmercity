using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour {

    static audiomanager _instance;
    public int part = 0;
    // Use this for initialization
    void Start()
    {
        
    }
    public static audiomanager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<audiomanager>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    void Awake()
    {
        /*
         var pl = GameObject.FindGameObjectWithTag("Player");
        //此脚本永不消毁，并且每次进入初始场景时进行判断，若存在重复的则销毁
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != _instance)
        {
            Destroy(gameObject);
        }
        */
        _instance = this;
        DontDestroyOnLoad(this);
    }
    // Update is called once per frame
    void Update()
    {
        if (part == 0)
        {
            var pl = GameObject.Find("stop");
            if (pl)
                Destroy(gameObject);
        }
        if(part ==1)
        {
            var pl = GameObject.Find("stop1");
            if (pl)
                Destroy(gameObject);
        }
    }
}
