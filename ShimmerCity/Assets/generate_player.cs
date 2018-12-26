using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_player : MonoBehaviour {

    private bool generator = false;

	void Update () {
        if (generator){
            GameObject newplayer = Instantiate(Resources.Load("Prefabs/player_clone"), transform.position, transform.rotation) as GameObject;
            newplayer.SendMessage("SetBossShow");
            generator = false;
        }
    }
    
    void SetPlayer()
    {
        generator = true;
    }
}
