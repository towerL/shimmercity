using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Deerbug_attackbox : MonoBehaviour {

    public LayerMask RayLayer;
    private Vector2 ray_direction;
    public float ray_Distance;

    private Transform Player;

    //方向
    private int direction = 1;

    private Transform target;

    private GameObject curTraget, lastTraget;

    public float Distance_Threshold;

    private Animator animator;

    private bool bisAttacking;

    public float velocity;

    public static bool bisGethammer;
    
    private float _HP;

    private bool bisAttackElectrictBox;


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
    void Start()
    {
        direction = -1;
        ray_direction = Vector2.left;
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
        if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            if(transform.position.x > 30)
            {
                transform.Rotate(Vector3.up * 180);
                ray_direction = -ray_direction;
            }
        }
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
        if (distance <= Distance_Threshold * 10 || (distance_Player <= 10 && Ray_toPlayer()))
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
            ray_direction = -ray_direction;
        }
        if (collision.tag == "deerbug" || collision.tag == "Deerbug_long" || collision.tag == "Start_mouse" || collision.tag == "Spider")
        {
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), GetComponent<Collider2D>());
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

        try
        {
            if (bisAttackElectrictBox == true)
            {
                GameObject.Find("Deerbug_Number").SendMessage("DecreaseNumber");
                bisAttackElectrictBox = false;
            }
            //Fpbar_controller.Instance.Freame_Increase();
            if (Fpbar_controller.bisAcquire_sister == true)
            {
                GameObject.Find("Fp_bar").SendMessage("Freame_Increase");
                GameObject.Find("Sister_Head").SendMessage("Fpbaradd");
            }
        }
        catch
        {
        }
        Destroy(this.gameObject);

    }
    private void decreaseHp()
    {
        _HP--;
    }

}
