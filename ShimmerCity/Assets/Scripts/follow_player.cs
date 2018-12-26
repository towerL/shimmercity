using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class follow_player : MonoBehaviour {

	public Transform target;
    //边界
    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;

    public static follow_player Instance;

	private GameObject shield_prefabs;
	private bool flag1;
	private bool flag2;
	private float begin_timer;
	public float period;
	private float now_timer;
	private bool shield;


    public static bool bisPause;

    private void Start()
    {
        Instance = this;
		flag1 = false;
		flag2 = false;
		shield = false;
        bisPause = false;

    }
    void Update () {
        if(bisPause == false)
        {
            if (SceneManager.GetActiveScene().name == "Part2_1")
            {
                Vector3 pos = transform.position;
                pos.z = -10;
                pos.x = target.position.x;
                pos.y = -66.78f;
                if (pos.x > MaxX) pos.x = MaxX;
                else if (pos.x < MinX) pos.x = MinX;
                if (pos.y > MaxY) pos.y = MaxY;
                else if (pos.y < MinY) pos.y = MinY;
                transform.position = pos;
            }
            else if (SceneManager.GetActiveScene().name == "Part3_boss")
            {
                Vector3 pos = transform.position;
                pos.x = target.position.x;
                pos.y = target.position.y - 2.5f;
                if (pos.x > MaxX) pos.x = MaxX;
                else if (pos.x < MinX) pos.x = MinX;
                if (pos.y > MaxY) pos.y = MaxY;
                else if (pos.y < MinY) pos.y = MinY;
                pos.z = -10;
                transform.position = pos;
            }
            else
            {
                Vector3 pos = transform.position;
                pos.x = target.position.x;
                pos.y = target.position.y;
                if (pos.x > MaxX) pos.x = MaxX;
                else if (pos.x < MinX) pos.x = MinX;
                if (pos.y > MaxY) pos.y = MaxY;
                else if (pos.y < MinY) pos.y = MinY;
                pos.z = -10;
                transform.position = pos;
            }

        }
        

		if (flag1 && flag2) {
			begin_timer = Time.time;
			flag1 = false;
			flag2 = false;
			shield = true;
		}
		if (shield) {
			now_timer = Time.time;
			if (Time.time - begin_timer >= period) {
				shield_prefabs=Instantiate (Resources.Load ("prefabs/shield_10s")) as GameObject;
				shield = false;
			}
		}

	}

	void SetShieldFlag1(bool flag){
		flag1 = true;
	}
	void SetShieldFlag2(bool flag){
		flag2 = true;
	}
}
