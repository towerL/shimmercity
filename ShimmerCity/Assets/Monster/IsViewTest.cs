using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsViewTest : MonoBehaviour {
    public GameObject[] SpriteArray;
    public Vector3[] PositionArray;
    public static IsViewTest Instance;
    // Use this for initialization
    void Start () {
        Instance = this;
        for (int i = 0;i<SpriteArray.Length;i++)
        {
            PositionArray = new Vector3[SpriteArray.Length];
            //PositionArray[i] = SpriteArray[i].transform.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject gameobject in SpriteArray)
        {
            try
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
            catch
            {
                continue;
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
