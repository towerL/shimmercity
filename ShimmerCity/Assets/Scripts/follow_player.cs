using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_player : MonoBehaviour {

	public Transform target;
    //边界
    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;
	void Update () {
 		Vector3 pos = transform.position;
		pos.x = target.position.x;
		pos.y = target.position.y;
        if (pos.x > MaxX) pos.x = MaxX;
        else if (pos.x < MinX) pos.x = MinX;
        if (pos.y > MaxY) pos.y = MaxY;
        else if (pos.y < MinY) pos.y = MinY;
		transform.position = pos;
	}
}
