using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    //方向
    private int direction = 1;

    public Transform target;

    public GameObject curTraget,lastTraget;

    public float _distance;

    private Animator animator;

    private bool bisAttacking;
    // Use this for initialization
    void Start () {
        direction = -1;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //移动
        if (bisAttacking == false)
        {
            transform.Translate(Vector2.right * direction * 2f * Time.deltaTime);
        }
        float distance = (transform.position - target.position).sqrMagnitude;
        //Debug.Log(distance);
        if (distance <= _distance * 12)
        {
            animator.SetBool("Isattack", true);
            bisAttacking = true;
        }
        else
        {
            animator.SetBool("Isattack", false);
            bisAttacking = false;
        }
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
