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

    private bool bisAttackElectrictBox;

    // Use this for initialization
    void Start()
    {
        direction = -1;
        animator = GetComponent<Animator>();
        bisGethammer = true;
        target = GameObject.Find("ElectricBox").transform ;
        Player = GameObject.Find("Player").transform;
        _HP = 1;
        bisAttackElectrictBox = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (_HP <= 0)
        {
            animator.SetTrigger("Isdie");
            bisAttacking = true;
            this.Invoke("Destroy_monster", 1.0f);

        }
        GetComponent<SpriteRenderer>().sortingOrder = -2;
        if (bisGethammer == true)
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

        if (distance <= Distance_Threshold * 10)
        {
            //GetComponent<PolygonCollider2D>().enabled = false;
            //Destroy(GetComponent<Rigidbody2D>());
            if(bisAttackElectrictBox == false)
            {
                GameObject.Find("Deerbug_Number").SendMessage("AddNumber");
                bisAttackElectrictBox = true;
            }
            
            GameObject.Find("Deerbug_Number").SendMessage("Active");
        }

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
        //if ((collision.collider.tag == "hammer_in_attack" || collision.collider.tag == "Skill_L"))
        //{
        //    decreaseHp();
        //}
        if(collision.collider.tag == "deerbug" && bisAttackElectrictBox == true)
        {
            Physics2D.IgnoreCollision(GetComponent<PolygonCollider2D>(), collision.collider);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "board_edge" || collision.tag == "SceneEdge" || collision.tag == "Box")
        {
           // Debug.Log("进入trigger");
            transform.Rotate(Vector3.up * 180);
        }
        //if (collision.tag == "hammer_in_attack" && bisAttackElectrictBox == true)
        //{
        //    decreaseHp();
        //    Debug.Log("普攻");
        //}
        //怪物碰撞体去掉后 大招锤不死
        //if ((collision.tag == "Skill_L") && bisAttackElectrictBox == true)
        //{
        //    Debug.Log("技能");
        //    decreaseHp();
        //}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
    }
    private void Destroy_monster()
    {
        if (bisAttackElectrictBox == true)
        {
            GameObject.Find("Deerbug_Number").SendMessage("DecreaseNumber");
            bisAttackElectrictBox = false;
        }
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
