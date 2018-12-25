using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_dark_cycle : MonoBehaviour {
    public Sprite lightImage;
    public Sprite darkImage;
    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator WaitAndPrint2()
    {
        yield return new WaitForSeconds(1.5f);
    }
    IEnumerator Start()
    {
        yield return StartCoroutine("WaitAndPrint2");
        gameObject.GetComponent<SpriteRenderer>().sprite = darkImage;
        yield return StartCoroutine("WaitAndPrint");
        gameObject.GetComponent<SpriteRenderer>().sprite = lightImage;
        yield return StartCoroutine("WaitAndPrint");
        gameObject.GetComponent<SpriteRenderer>().sprite = darkImage;
        yield return StartCoroutine("WaitAndPrint");
        gameObject.GetComponent<SpriteRenderer>().sprite = lightImage;
        yield return StartCoroutine("WaitAndPrint");
        gameObject.GetComponent<SpriteRenderer>().sprite = darkImage;
    }

    //void Start () {
    //    darkImage = gameObject.GetComponent<SpriteRenderer>().sprite;
    //    gameObject.GetComponent<SpriteRenderer>().sprite = lightImage;
    //    gameObject.GetComponent<SpriteRenderer>().sprite = darkImage;
		
    //}
	
	// Update is called once per frame
	void Update () {
		
	}
}
