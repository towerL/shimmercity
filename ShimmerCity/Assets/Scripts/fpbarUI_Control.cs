using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class fpbarUI_Control : MonoBehaviour {
    public static fpbarUI_Control Instance;
    // Use this for initialization
    void Start () {
        //Debug.Log(SceneManager.GetActiveScene().name);
        Instance = this;
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            this.gameObject.SetActive(false);
        }
        if(Fpbar_controller.bisAcquire_sister != true)
        {
            this.gameObject.SetActive(false);
        }
        
	}
	public void setActive()
    {
        this.gameObject.SetActive(true);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
