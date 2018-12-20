using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerbugLong_congtroller : MonoBehaviour {
    public GameObject bulletPrefab;
    public LayerMask RayLayer;
    public float ray_Distance;
    //方向
    private int direction = 1;

    public Transform target;

    public float _HP;

    public float Attack_Distance;

    private Animator animator;

    private Vector2 ray_direction;

    private bool bisAttacking;

    private bool bisAttack_CD;

    public float AttackCD;

    //public GameObject Bullet;
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
        bisAttack_CD = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (_HP <= 0)
        {
            animator.SetTrigger("SetDie");
            this.Invoke("Destroy_monster", 0.8f);
        }
        //Debug.Log(ray_direction);
        //移动
        if (bisAttacking == false)
        {
            transform.Translate(Vector2.right * direction * 2f * Time.deltaTime);
        }
        if (Ray_toPlayer()) //射线检测到主角
        {
            float distance = (transform.position - target.position).sqrMagnitude;
            
            if (distance <= Attack_Distance)
            {
                if (bisAttack_CD == false)
                {
                    bisAttack_CD = true;
                    bisAttacking = true;  //怪物停止移动
                    animator.SetTrigger("SetAttack");//切换为攻击动画
                    Invoke("SetBullet", 1.0f);//1秒后发射子弹
                    Invoke("SetMove", 2.0f /* * Time.deltaTime*/);// 2秒后切回移动动画
                    Invoke("SetAttackCD", AttackCD);//CD时间
                }
            }
        }
    }
    private void SetBullet()
    {
        bisAttacking = true;
        GameObject mPrefab = (MonoBehaviour.Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity) as GameObject);
        mPrefab.GetComponent<SpriteRenderer>().sortingOrder = 5;
        mPrefab.transform.position = transform.position;
        mPrefab.SendMessage("SetBulletOrigin", this.transform);
        mPrefab.SendMessage("SetDirection", ray_direction);
    }
    private void SetMove()
    {
        animator.SetTrigger("SetAttackEnd");
        bisAttacking = false;
    }

    private void SetAttackCD()
    {
        bisAttack_CD = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //transform.Rotate(Vector3.up * 180);
        if (collision.tag == "board_edge" || collision.tag == "SceneEdge" || collision.tag == "deerbug" || collision.tag == "Pipe")
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
    private void decreaseHp()
    {
        _HP--;
    }
    private void Destroy_monster()
    {
        Destroy(this.gameObject);
    }
}
