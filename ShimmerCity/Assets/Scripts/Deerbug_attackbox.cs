using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deerbug_attackbox : MonoBehaviour {

    //方向
    private int direction = 1;

    private Transform target;
    private Transform Player;

    private GameObject curTraget, lastTraget;

    public float Distance_Threshold;

    private Animator animator;

    private bool bisAttacking;

    public float velocity;

    public static bool bisGethammer;
    
    private float _HP;
    // Use this for initialization
    void Start()
    {
        direction = -1;
        animator = GetComponent<Animator>();
        bisGethammer = true;
        target = GameObject.Find("ElectricBox").transform ;
        Player = GameObject.Find("Player").transform;
        _HP = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if(_HP <= 0)
        {
            animator.SetTrigger("Isdie");
            bisAttacking = true;
            
            this.Invoke("Destroy_monster", 1.0f);
        }
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
        float distance_Player = (transform.position - Player.position).sqrMagnitude;
        float distance = (transform.position - target.position).sqrMagnitude;
        //Debug.Log(distance);
        if (distance <= Distance_Threshold * 10 || distance_Player <= Distance_Threshold * 10)
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
        if (collision.collider.tag == "hammer_in_attack" || collision.collider.tag == "Skill_L")
        {
            decreaseHp();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "board_edge" || collision.tag == "SceneEdge" || collision.tag == "Box")
        {
            Debug.Log("进入trigger");
            transform.Rotate(Vector3.up * 180);
        }
        if(collision.tag == "deerbug")
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            Destroy(GetComponent<Rigidbody2D>());
            GameObject.Find("Deerbug_Number").SendMessage("AddNumber");
            GameObject.Find("Deerbug_Number").SendMessage("Active");
        }
        if (collision.tag == "hammer_in_attack" /*|| collision.collider.tag == "Player"*/)
        {
            decreaseHp();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "deerbug")
        {
            GetComponent<PolygonCollider2D>().enabled = true;
            this.gameObject.AddComponent<Rigidbody2D>();
        }
    }


    private void Destroy_monster()
    {
        Destroy(this.gameObject);
        //Fpbar_controller.Instance.Freame_Increase();
        GameObject.Find("Fp_bar").SendMessage("Freame_Increase");
        try
        {
            GameObject.Find("Sister_Head").SendMessage("Fpbaradd");
        }
        catch
        {
            return;
        }
        
    }
    private void decreaseHp()
    {
        _HP--;
    }

}
