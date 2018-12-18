using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_sister : MonoBehaviour {
	public void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player" ) {
            //Debug.Log ("get the sister!");
            Fpbar_controller.bisAcquire_sister = true;
            col.SendMessage ("SetSister",true);
            UIBGAddSister_Control.Instance.setActive();
            SisterHead_Control.Instance.Active();
            //Destroy(this.gameObject);
        }
	}

}

