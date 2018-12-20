using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class connectcontroller2 : MonoBehaviour {
    float WaitTime = 2.0f;
    private Vector3[] directions = { new Vector3(3.48f, 0.95f, 0.0f), new Vector3(2.66f, 1.09f, 0.0f), new Vector3(2.02f, 1.18f, 0.0f), new Vector3(1.36f, 1.37f, 0.0f), new Vector3(0.4f, 1.65f, 0.0f), new Vector3(-0.26f, 2.03f, 0.0f) };
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
        for (int i = 0; i < 6; i++)
        {
            transform.Translate(directions[i] * Time.deltaTime);
            gameObject.transform.localPosition = Vector3.MoveTowards(transform.position, directions[i], 80.0f * Time.deltaTime);
            yield return StartCoroutine("WaitAndPrint");
            transform.position = directions[i];
        }
    }


    void Update()
    {
        if (WaitTime >= 0)
        {
            WaitTime -= 0.01f;
        }
        if (WaitTime < 0)
        {
            SceneManager.LoadScene("Part3");
        }
    }
}
