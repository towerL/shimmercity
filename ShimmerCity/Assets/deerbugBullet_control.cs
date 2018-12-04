using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deerbugBullet_control : MonoBehaviour {

    private SpriteRenderer render;

    public bool SetAttack;

    public Transform Deerbug;

    private Vector2 Direction;

	// Use this for initialization
	void Start () {
        render = GetComponent<SpriteRenderer>();
        render.sortingOrder = -2;
        SetAttack = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(SetAttack == true)
        {
            if(render.sortingOrder == -2)
            {
                transform.position = Deerbug.transform.position;
            }
            render.sortingOrder = 2;
            Vector3 pos;
            pos.x = transform.position.x + 0.05f * Direction.x;
            pos.y = transform.position.y;
            pos.z = transform.position.z;
            transform.position = pos;
            Invoke("SetBulletOrigin",3.0f);
            //SetAttack = false;
        }
        else
        {
            render.sortingOrder = -2;
            transform.position = Deerbug.transform.position;
        }
	}

    private void SetDirection(Vector2 direction)
    {
        Direction = direction;
        SetAttack = true;
    }
    private void SetBulletOrigin()
    {
        SetAttack = false;
        render.sortingOrder = -2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pipe" || collision.tag == "Player")
        {
            Debug.Log("子弹进入碰撞体");
            render.sortingOrder = -2;
            SetAttack = false;
        }
    }
}
