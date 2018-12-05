using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public LayerMask RayLayer;
    public float ray_Distance;
    //方向
    private int direction = 1;

    public Transform target;

    public float _HP;

    public float Attack_Distance;

    private Animator animator;

    private bool bisAttacking;

    private Vector2 ray_direction;

    bool Ray_toPlayer()
    {
        Vector2 position = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(position, ray_direction, ray_Distance, RayLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    // Use this for initialization
    void Start () {
        _HP = 1;
        direction = -1;
        ray_direction = Vector2.left;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_HP <= 0)
        {
            animator.SetTrigger("Isdie");
            bisAttacking = true;
            
            //Destroy(gameObject.GetComponent<Collider2D>());
            this.Invoke("Destroy_monster", 1.0f);
        }
        //移动
        if (bisAttacking == false)
        {
            transform.Translate(Vector2.right * direction * 2f * Time.deltaTime);
        }

        if (Ray_toPlayer()) //射线检测到主角
        {
            float distance = (transform.position - target.position).sqrMagnitude;
            //Debug.Log(distance);
            if (distance <= Attack_Distance * 10)
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
        else
        {
            animator.SetBool("Isattack", false);
            bisAttacking = false;
        }

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "hammer_in_attack" || collision.collider.tag == "Player")
        {
            decreaseHp();
            
        }
    }

    private void Destroy_monster()
    {
        Destroy(this.gameObject);
        Fpbar_controller.Instance.Freame_Increase();
    }
    private void decreaseHp()
    {
        _HP--;
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.tag == "board_edge" || collision.tag == "SceneEdge" || collision.tag == "deerbug" || collision.tag == "Pipe")
        {
            transform.Rotate(Vector3.up * 180);
            if (ray_direction == Vector2.left)
            {
                ray_direction = Vector2.right;
            }
            else
            {
                ray_direction = Vector2.left;
            }
        }
        //direction = direction * -1;
    }
}
