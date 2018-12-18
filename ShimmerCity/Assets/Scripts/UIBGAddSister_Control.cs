using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIBGAddSister_Control : MonoBehaviour {

    public static UIBGAddSister_Control Instance;
    // Use this for initialization
    void Start () {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }

        Instance = this;
    }
	
	// Update is called once per frame
	void Update () {
		if(Fpbar_controller.bisAcquire_sister == true)
        {
            gameObject.SetActive(true);
        }
        //gameObject.SetActive(true);
    }
    public void setActive()
    {
        gameObject.SetActive(true);
    }
}
