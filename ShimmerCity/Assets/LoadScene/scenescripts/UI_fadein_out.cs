using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_fadein_out : MonoBehaviour
{
    private float alpha = 0.0f;
    private float alphaSpeed = 2.0f;

    private CanvasGroup cg;

    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(3);
        print("WaitAndPrint " + Time.time);
    }
    IEnumerator Start()
    {
        yield return StartCoroutine("WaitAndPrint");

        cg = this.transform.GetComponent<CanvasGroup>();
        Show();
        Change();
    }


    public void Change() {
        while (alpha != cg.alpha)
        {
            cg.alpha = Mathf.Lerp(cg.alpha, alpha, alphaSpeed * Time.deltaTime);
            if (Mathf.Abs(alpha - cg.alpha) <= 0.01)
            {
                cg.alpha = alpha;
            }
        }
    }

    void Update()
    {

    }

    public void Show()
    {
        alpha = 1;

        cg.blocksRaycasts = true;//可以和该UI对象交互
    }

    public void Hide()
    {
        alpha = 0;

        cg.blocksRaycasts = false;//不可以和该UI对象交互
    }

}
