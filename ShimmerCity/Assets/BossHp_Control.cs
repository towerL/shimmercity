﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHp_Control : MonoBehaviour {
    private float Hp;
	// Use this for initialization
	void Start () {
        Hp = 200;
	}
	//void setHp(float _hp)
 //   {
 //       Hp = _hp;
 //   }
	// Update is called once per frame
	void Update () {
        Debug.Log(Hp);
        GetComponent<Slider>().value = Hp;
	}
    void BossDecreaseHp(float blood)
    {
        Hp -= blood;
    }
}
