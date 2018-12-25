using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deerbugBullet_control : MonoBehaviour {

    private SpriteRenderer render;

    public bool SetAttack;

    public Transform Deerbug;

    private Vector2 Direction;

    public float Bullet_FlyTime;
	// Use this for initialization
	void Start () {
        render = GetComponent<SpriteRenderer>();
        render.sortingOrder = 5;
        Invoke("DestroyBullet", Bullet_FlyTime);
    }
	
	// Update is called once per frame
	void Update () {
        render.sortingOrder = 5;
        Vector3 pos;
        pos.x = transform.position.x + 0.08f * Direction.x;
        pos.y = transform.position.y;
        pos.z = transform.position.z;
        transform.position = pos;
	}
    private void SetBulletOrigin(Transform deerbug)
    {
        //render.sortingOrder = 5;
        transform.position = deerbug.position;
        
    }
    private void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }
    private void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
    
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "Pipe" || collision.tag == "Player")
    //    {
    //        Debug.Log("子弹进入碰撞体");
    //        DestroyBullet();
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.Find("Player").SendMessage("PlayerDecreaseHP", 3f);
            DestroyBullet();
        }
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Pipe" || collision.tag == "Player")
    //    {
    //        Debug.Log("子弹进入碰撞体");
    //        DestroyBullet();
    //    }
    //}
}
