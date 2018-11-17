using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{

    private Animator door_ani;

    void Update()
    {

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            var door = GameObject.Find("door1");
            door.GetComponent<Animator>().SetBool("IsDoorOpen", false);
        }
    }
}
