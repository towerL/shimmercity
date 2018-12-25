using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LuckFish_Control : MonoBehaviour {
    Vector3 first_Pos;
    private int direction;
    public float move_Step;
    public float cdTime;
    private bool bisCd;
    private float firstY;
    SpriteRenderer render;
	// Use this for initialization
	void Start () {
        InvokeRepeating("FishUp_Down",0,cdTime);
        bisCd = false;
        direction = 1;
        firstY = transform.position.y;
        //Debug.Log(firstY.ToString());
        render = GetComponent<SpriteRenderer>();
        render.sortingOrder = -10;
        if (SceneManager.GetActiveScene().name == "Part2_1")
        {
            Vector3 scale = new Vector3(0.95f, 0.95f, 1);
            transform.localScale = scale;
        }
    }
	private void FishUp_Down()
    {
        bisCd = false;
        Vector3 _temp;
        _temp.y = firstY;
        _temp.x = transform.position.x;
        _temp.z = transform.position.z;
        transform.position = _temp;
    }
	// Update is called once per frame
	void Update () {

        if (transform.position.y >= firstY + 10.0f)
        {
            direction = -direction;
            transform.Rotate(new Vector3(0, 1, 0), 180);
        }
        else if (transform.position.y <= firstY - 1)
        {
            //Debug.Log("进入函数");
            if(bisCd != true)
            {
                render.sortingOrder = -10;
                transform.Rotate(new Vector3(0, 1, 0), 180);
                direction = -direction;
                bisCd = true;
                Vector3 _temp;
                _temp.y = firstY;
                _temp.x = transform.position.x;
                _temp.z = transform.position.z;
                transform.position = _temp;
            }
            else
            {
                
            }
            //direction = -direction;
            //transform.Rotate(new Vector3(0, 1, 0), 180);

        }
        if (bisCd == false)
        {
            render.sortingOrder = 5;
            Vector3 _pos = transform.position;
            _pos.y += direction * move_Step;
            transform.position = _pos;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("Player").SendMessage("PlayerDecreaseHP", 10f);
    }
}
