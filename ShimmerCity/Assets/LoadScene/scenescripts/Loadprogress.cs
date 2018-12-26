using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loadprogress : MonoBehaviour {
    private AsyncOperation aync;
    public Image load;//进度条的图片
    private int culload = 0;//已加载的进度
    public Text loadtext;//百分制显示进度加载情况

	IEnumerator WaitAndPrint()
	{
		yield return new WaitForSeconds(2.5f);
		print("WaitAndPrint " + Time.time);
	}
    IEnumerator Start()
    {
        yield return StartCoroutine("WaitAndPrint");

        StartCoroutine("LoadScence");
    }
	
     IEnumerator LoadScence()
    {
        aync = SceneManager.LoadSceneAsync("StartScene");//SkillCD为要跳转的场景
        aync.allowSceneActivation = false;
        yield return aync;
    }

	// Update is called once per frame
	void Update () {
		//判断是否有场景正在加载
        if (aync == null)
        {
            return;
        }
        int progrssvalue = 0;
        //当场景加载进度在90%以下时，将数值以整数百分制呈现，当资源加载到90%时就将百分制进度设置为100，
        if (aync.progress < 0.9f)
        {
            progrssvalue = (int)aync.progress * 100;
        }
        else
        {
            progrssvalue = 100;
        }
        //每帧对进度条的图片和Text百分制数据进行更改，为了实现数字的累加而不是跨越，用另一个变量来实现。
        if (culload < progrssvalue)
        {
            culload++;
            load.fillAmount = culload / 100f;
            loadtext.text = culload.ToString() + "%";
        }
        //一旦进度到达100时，开启自动场景跳转，LoadSceneAsync会加载完剩下的10%的场景资源
        if (culload == 100)
        {
            aync.allowSceneActivation = true;
        }
	}

}
