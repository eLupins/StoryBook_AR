using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapButtons : MonoBehaviour {
    public GameObject canvasA;
    // Use this for initialization
    void Start () {
        canvasA.SetActive(false);

        

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void onClick()
    {
        Debug.Log("onClick running");
        if (canvasA.activeSelf == !true)
        {
            canvasA.SetActive(true);
            Debug.Log("Canvas is on");

        }
        else
        {
            canvasA.SetActive(false);
            Debug.Log("Canvas is off");
        }
    }
}
