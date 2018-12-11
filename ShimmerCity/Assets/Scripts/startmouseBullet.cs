using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startmouseBullet : MonoBehaviour {


    private SpriteRenderer render;

    private Vector2 _Direction;

    
    public float Bullet_FlyTime;
    // Use this for initialization
    void Start () {
        render = GetComponent<SpriteRenderer>();
        render.sortingOrder = 5;
        Invoke("DestroyBullet", Bullet_FlyTime);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 temp_pos;
        temp_pos.x = transform.position.x + (0.05f * _Direction.x);
        temp_pos.y = transform.position.y;
        temp_pos.z = transform.position.z;
        transform.position = temp_pos;
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("进入碰撞");
            DestroyBullet();
        }
    }
    void SetDirection(Vector2 dire)
    {
        _Direction = dire;
    }
    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
