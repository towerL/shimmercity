using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsView : MonoBehaviour {
    public GameObject Instance;
    public Vector3 OriginPosition;
    private Spider_Controller _Spider_Controller;
    private EnemyController _EnemyController;
    private Startmouse_Controller _Startmouse_Controller;
    private void Start()
    {
        this.gameObject.SetActive(false);
        //Instance = this.gameObject;
        //OriginPosition = this.gameObject.transform.position;
        //this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        //Destroy(this.gameObject.GetComponent<Rigidbody2D>());
        //this.gameObject.GetComponent<Animation>().enabled = false;
        //this.gameObject.GetComponent<SpiderCollider_Controller>().enabled = false;
        //this.gameObject.GetComponent<EnemyController>().enabled = false;
        //this.gameObject.GetComponent<Startmouse_Controller>().enabled = false;
        //this.gameObject.GetComponent<Spider_Controller>().enabled = false;
    }

    private void Update()
    {
        //Vector2 vec2 = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
        //if (IsInView(OriginPosition))
        //{
        //    //this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        //    //this.gameObject.GetComponent<Collider2D>().enabled = true;
        //    //this.gameObject.GetComponent<Spider_Controller>().enabled = true;
        //}
        //else
        //{
        //    //this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //    //this.gameObject.GetComponent<Collider2D>().enabled = false;
        //    //this.gameObject.GetComponent<Spider_Controller>().enabled = false;
        //}
    }
    public bool IsInView(Vector3 worldPos)
    {
        Transform camTransform = Camera.main.transform;
        Vector2 viewPos = Camera.main.WorldToViewportPoint(worldPos);
        Vector3 dir = (worldPos - camTransform.position).normalized;

        Debug.Log(this.gameObject.name + ":" + viewPos);
        float dot = Vector3.Dot(camTransform.forward, dir);//判断物体是否在相机前面
        if (dot > 0 && viewPos.x >= 0 && viewPos.x <= Camera.main.pixelWidth && viewPos.y >= 0 && viewPos.y <= Camera.main.pixelHeight)
            return true;
        else
            return false;
    }


    //public Transform camTransform;
    // Use this for initialization
    //public GameObject Instance;
    //public Vector3 OriginPos;
    //private void Start()
    //{
    //    this.gameObject.SetActive(false);
    //    Instance = this.gameObject;
    //    OriginPos = Instance.transform.position;
    //}
    //// Update is called once per frame
    //void Update () {
    //    //if(GetComponent<SpriteRenderer>().isVisible == true)
    //    //{
    //    //    this.gameObject.SetActive(true);
    //    //}
    //    //else
    //    //{
    //    //    this.gameObject.SetActive(false);
    //    //}

    //}


    //private void OnBecameVisible()
    //{
    //    //Debug.Log(gameObject.name);
    //    //GetComponent<SpriteRenderer>().enabled = true;
    //    //Instance.SetActive(true);
    //}
    //private void OnBecameInvisible()
    //{
    //    //GetComponent<SpriteRenderer>().enabled = false;
    //    //this.gameObject.SetActive(false);
    //}
}
