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
    // Use this for initialization
    void Start () {
        bisAcquire_sister = false;
        frameNumber = 0;
    }
	
	// Update is called once per frame
	void Update () {

        if(bisAcquire_sister == true)
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = 5;
            gameObject.GetComponent<SpriteRenderer>().sprite = frames[frameNumber];
        }
        Vector3 _pos;
        _pos.x = target.transform.position.x + 14.2f;
        _pos.y = target.transform.position.y + 8f;
        _pos.z = target.transform.position.z + 1;

        //if (_pos.x >= Camera_pos.position.x + 14)
        //{
        //    _pos.x = Camera_pos.position.x + 14;
        //}
        //if (_pos.y >= Camera_pos.position.y + 8)
        //{
        //    _pos.y = Camera_pos.position.y + 8;
        //}


        this.transform.position = _pos;
    }
}
