using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHp_Control : MonoBehaviour {
    public static float Player_Hp;
	// Use this for initialization
	void Start () {
        Player_Hp = player_move.player_health;

    }
    	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            Player_Hp = player_move.player_health;
        }
        else if (SceneManager.GetActiveScene().name == "Part2_1")
        {
            Player_Hp = player_move2.player_health;
        }
        else if (SceneManager.GetActiveScene().name == "Part3")
        {
            Player_Hp = player_move3.player_health;
        }
        //else if (SceneManager.GetActiveScene().name == "Part2_1")
        //{

        //}
        GetComponent<Slider>().value = Player_Hp;
    }

    private void OnGUI()
    {

    }
}
