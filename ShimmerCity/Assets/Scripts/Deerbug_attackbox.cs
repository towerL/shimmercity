using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deerbug_attackbox : MonoBehaviour {

    //方向
    private int direction = 1;

    public Transform target;

    private GameObject curTraget, lastTraget;

    public float Distance_Threshold;

    private Animator animator;

    private bool bisAttacking;

    public float velocity;

    public static bool bisGethammer;
    // Use this for initialization
    void Start()
    {
        direction = -1;
        animator = GetComponent<Animator>();
        bisGethammer = false;
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sortingOrder = -2;
        if(bisGethammer == true)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        //移动
        if (bisAttacking == false && bisGethammer == true)
        {
            transform.Translate(Vector2.right * direction * velocity * Time.deltaTime);
        }
        float distance = (transform.position - target.position).sqrMagnitude;
        //Debug.Log(distance);
        if (distance <= Distance_Threshold * 10)
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
        if (collision.collider.tag == "deerbug" || collision.collider.tag == "box" )
        {
            transform.Rotate(Vector3.up * 180);
        }
        //transform.Rotate(Vector3.up * 180);
        //direction = -direction;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //transform.Rotate(Vector3.up * 180);
        if (collision.tag == "board_edge")
        {
            transform.Rotate(Vector3.up * 180);
        }
        //direction = direction * -1;
    }
}
