using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startmouse_Controller : MonoBehaviour {

    public GameObject bulletPrefab;
    public float _HP;
    public Vector2 direction;
    // Use this for initialization
    void Start () {
        InvokeRepeating("loadBullet",0,2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void loadBullet()
    {
        GameObject mPrefab = (MonoBehaviour.Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity) as GameObject);
        mPrefab.GetComponent<SpriteRenderer>().sortingOrder = 5;
        mPrefab.transform.position = transform.position;
        mPrefab.SendMessage("SetDirection", direction);
    }
}
