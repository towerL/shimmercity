using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    //方向
    private int direction = 1;

    // Use this for initialization
    void Start () {
        direction = -1;
    }

    // Update is called once per frame
    void Update()
    {
        //移动
        transform.Translate(Vector2.right * direction * 2f * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //transform.Rotate(Vector3.up * 180);
        //direction = -direction;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //transform.Rotate(Vector3.up * 180);
        if(collision.tag == "board_edge")
        {
            transform.Rotate(Vector3.up * 180);
        }
        //direction = direction * -1;
    }
}
