using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIBGAddSister_Control : MonoBehaviour {

    public static UIBGAddSister_Control Instance;
    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
        Instance = this;
    }
	
	// Update is called once per frame
	void Update () {
		if(Fpbar_controller.bisAcquire_sister == true)
        {
            gameObject.SetActive(true);
        }
        gameObject.SetActive(true);
    }
    public void setActive()
    {
        gameObject.SetActive(true);
    }
}
