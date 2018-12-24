using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Startmouse_Controller : MonoBehaviour {

    public GameObject bulletPrefab;
    public float _HP;
    public Vector2 direction;
    public float V;
    // Use this for initialization
    void Start () {
        InvokeRepeating("loadBullet1", 0, 2);
        InvokeRepeating("loadBullet2", 0, 2);
    }
	
	// Update is called once per frame
	void Update () {
		if(_HP <= 0)
        {
            GetComponent<Animator>().SetTrigger("SetDie");
            Invoke("SetDie", 1f);
        }
        Vector3 _pos = transform.position;
        _pos.x += direction.x * V;
        transform.position = _pos;
    }
    private void SetDie()
    {

        try
        {
            if (Fpbar_controller.bisAcquire_sister != false)
                Fpbar_controller.Instance.Freame_Increase();
            GameObject.Find("Fp_bar").SendMessage("Freame_Increase");
            GameObject.Find("Sister_Head").SendMessage("Fpbaradd");
        }
        catch
        {

        }
        //if (SceneManager.GetActiveScene().name == "Part2_1")
        //{
        //    foreach (GameObject obj in IsViewTest.Instance.SpriteArray)
        //    {
        //        if (this.gameObject.GetInstanceID() == obj.GetInstanceID())
        //        {
        //            IsViewTest.Instance.SpriteArray = null;
        //        }
        //    }

        //}
        Destroy(this.gameObject);
        //this.gameObject.SetActive(false);
    }
    void loadBullet1()
    {
        GameObject mPrefab = (MonoBehaviour.Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity) as GameObject);
        mPrefab.GetComponent<SpriteRenderer>().sortingOrder = 5;
        Vector3 _pos = transform.position;
        _pos.y += 0.5f;
        mPrefab.transform.position = _pos;
        //mPrefab.transform.position = transform.position;
        mPrefab.SendMessage("SetDirection", direction);
    }
    void loadBullet2()
    {
        GameObject mPrefab2 = (MonoBehaviour.Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity) as GameObject);
        mPrefab2.GetComponent<SpriteRenderer>().sortingOrder = 5;
        Vector3 _pos = transform.position;
        _pos.y -= 1.0f;
        mPrefab2.transform.position = _pos;
        mPrefab2.SendMessage("SetDirection", direction);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.collider.tag == "Pipe")
        //{
        //    direction.x = -direction.x;
        //    transform.Rotate(new Vector3(0, 180.0f, 0));
        //}
        if (collision.collider.tag == "deerbug" || collision.collider.tag == "Deerbug_long" || collision.collider.tag == "Start_mouse" || collision.collider.tag == "Spider")
        {
            //direction.x = -direction.x;
            //transform.Rotate(new Vector3(0, 180.0f, 0));
            Physics2D.IgnoreCollision(collision.collider.GetComponent<PolygonCollider2D>(), GetComponent<PolygonCollider2D>());
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pipe")
        {
            direction.x = -direction.x;
            transform.Rotate(new Vector3(0, 180.0f, 0));
        }
        //if (collision.tag == "deerbug" || collision.tag == "Deerbug_long" || collision.tag == "Start_mouse" || collision.tag == "Spider")
        //{
        //    direction.x = -direction.x;
        //    transform.Rotate(new Vector3(0, 180.0f, 0));
        //    Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //}
    }

    private void decreaseHp()
    {
        _HP--;
    }
}
