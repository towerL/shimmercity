using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class connectcontroller : MonoBehaviour {
    float WaitTime = 2.0f;
    private Vector3[] directions = { new Vector3(3.79f, -1.03f, 0.0f), new Vector3(4.01f, -0.56f, 0.0f), new Vector3(4.29f, 0.03f, 0.0f), new Vector3(4.33f, 0.33f, 0.0f), new Vector3(4.28f, 0.76f, 0.0f) };
    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(0.05f);
        print("WaitAndPrint " + Time.time);
    }
    IEnumerator WaitAndPrint2()
    {
        yield return new WaitForSeconds(1.0f);
        print("WaitAndPrint " + Time.time);
    }
    IEnumerator Start()
    {
        yield return StartCoroutine("WaitAndPrint2");
        for (int i = 0; i < 5; i++) {
            transform.Translate(directions[i] * Time.deltaTime);
            gameObject.transform.localPosition = Vector3.MoveTowards(transform.position, directions[i], 80.0f * Time.deltaTime);
            yield return StartCoroutine("WaitAndPrint");
            transform.position = directions[i];
        }
	}


	void Update () {
        if (WaitTime >= 0) {
            WaitTime -= 0.01f;
        }
        if (WaitTime < 0)
        {
            SceneManager.LoadScene("Part2_1");
        }
	}
}
