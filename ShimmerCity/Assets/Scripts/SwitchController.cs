using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public GameObject objPrefab;
    private Animator door_ani;
    private bool cancel;
    public static bool bIsgetHammer;
    private void Start()
    {
        bIsgetHammer = false;
        cancel = false;
        //InvokeRepeating("AddDeerbugPrefab",0,5.0f);
    }

    void Update()
    {
        if(bIsgetHammer == true)
        {
            //Invoke("AddDeerbugPrefab", 10.0f);
            bIsgetHammer = false;
            Deerbug_attackbox.bisGethammer = true;
            this.InvokeRepeating("AddDeerbugPrefab",0,10.0f); 
        }
        if(cancel == true)
        {
            this.CancelInvoke("AddDeerbugPrefab");
            cancel = false;
            
        }
    }
    private void AddDeerbugPrefab()
    {
        //GameObject deerbug_attackElectricbox = (GameObject)Resources.Load("Prefabs/deerbug_short_forElectricBox");
        GameObject mPrefab = (MonoBehaviour.Instantiate(objPrefab, Vector3.zero, Quaternion.identity) as GameObject);
        mPrefab.transform.position = transform.position;
        mPrefab.GetComponent<SpriteRenderer>().sortingOrder = 2;
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            var door = GameObject.Find("door1");
            door.GetComponent<Animator>().SetBool("IsDoorOpen", false);
            
            Debug.Log("取消出现怪物");
            cancel = true;


        }
    }
}
