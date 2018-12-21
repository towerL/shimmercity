using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liightning : MonoBehaviour {
    float maxPos_x = 20.51f;
    float maxPos_y = 11.79f;
    float minPos_x = -7.22f;
    float minPos_y = -3.4f;
    public float vel_x=1.0f;
    public float vel_y=1.0f;
    public float starttime;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (starttime <= 0)
        {
            this.transform.position = this.transform.position + new Vector3(vel_x * Time.deltaTime, vel_y * Time.deltaTime, 0);
            Check();
        }
        else
            starttime = starttime - Time.deltaTime;
    }
    void Check()
    {
        if (this.transform.position.x > maxPos_x)
            vel_x = -vel_x;

        if (this.transform.position.x < minPos_x)
            vel_x = -vel_x;

        if (this.transform.position.y > maxPos_y)
            vel_y = -vel_y;

        if (this.transform.position.y < minPos_y)
            vel_y = -vel_y;

    }
}
