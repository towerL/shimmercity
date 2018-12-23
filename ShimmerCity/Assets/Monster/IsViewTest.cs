using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsViewTest : MonoBehaviour {
    public GameObject[] SpriteArray;
    public Vector3[] PositionArray;
    // Use this for initialization
    void Start () {
        for(int i = 0;i<SpriteArray.Length;i++)
        {
            PositionArray = new Vector3[SpriteArray.Length];
            PositionArray[i] = SpriteArray[i].transform.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
        //GameObject[] deerbugs = GameObject.FindGameObjectsWithTag("deerbug");
        //Debug.Log(deerbugs.Length.ToString());
        //foreach (GameObject deerbug in deerbugs)
        //{
        //    if(IsInView(deerbug.transform.position) == true)
        //    {
        //        deerbug.SetActive(true);
        //    }
        //}
        foreach (GameObject gameobject in SpriteArray)
        {
            if (IsInView(gameobject.transform.position) == true)
            {
                gameobject.SetActive(true);
            }
            else
            {
                gameobject.SetActive(false);
            }
        }
    }

    public bool IsInView(Vector3 worldPos)
    {
        Transform camTransform = Camera.main.transform;
        Vector2 viewPos = Camera.main.WorldToViewportPoint(worldPos);
        Vector3 dir = (worldPos - camTransform.position).normalized;

        //Debug.Log(this.gameObject.name + ":" + viewPos);
        float dot = Vector3.Dot(camTransform.forward, dir);//判断物体是否在相机前面
                                                           //if (dot > 0 && viewPos.x >= 0 && viewPos.x <= Camera.main.pixelWidth && viewPos.y >= 0 && viewPos.y <= Camera.main.pixelHeight)
                                                           //    return true;
        if (dot > 0 && viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1)
            return true;
        else
            return false;
    }
}
