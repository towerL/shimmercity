using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour {
    //移动初始位置
    float h0;
    public float speed;
    public string stone_name;
    float mytime = 10.0f;

    void Start()
    {
        h0 = transform.position.y;
    }

    void Update()
    {
        mytime -= Time.deltaTime;
        if (System.Math.Abs(transform.position.y - h0) <= 15.0f)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if (mytime < 0)
        {
            var v = transform.position;
            v.y = h0;
            transform.position = v;
            mytime = 10.0f;
            var fallen_stone = GameObject.Find(stone_name);
            fallen_stone.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Stone")
        {
            var fallen_stone = GameObject.Find(stone_name);
            fallen_stone.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
