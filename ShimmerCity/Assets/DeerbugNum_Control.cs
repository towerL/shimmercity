using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeerbugNum_Control : MonoBehaviour {
    Text text;
    public static float Number;
	// Use this for initialization
	void Start () {
        Number = 0;
    }
	private void AddNumber()
    {
        Number+= 1f;
    }
    private void DecreaseNumber()
    {
        Number--;
    }
    private void Active()
    {
        this.gameObject.SetActive(true);
    }
	// Update is called once per frame
	void Update () {
		if(Number == 0)
        {
            //this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
            this.GetComponent<Text>().text = "Deerbug✖" + Number.ToString();
        }

	}
}
