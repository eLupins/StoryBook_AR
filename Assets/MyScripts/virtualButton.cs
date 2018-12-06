using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;


public class virtualButton : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject vButton;
    public Text text;
    public ParticleSystem tap;
    IEnumerator cr;


    // Use this for initialization
    void Start() {
        vButton = GameObject.Find("v_Button");
        vButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        text.enabled = false;
        tap.Stop();
        cr = null;
        
    }

    // Update is called once per frame
    void Update() {

    }

    public void ButtonInteraction()
    {
        if (cr != null)
        {
            StopCoroutine(cr);
        }
        cr = TapEffect();
        StartCoroutine(cr);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (tap)
        {
            ButtonInteraction();
        }
        Debug.Log("Button press");
    }


    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

        text.enabled = false;
        Debug.Log("Button release");
    }

    IEnumerator TapEffect()
    {
        tap.Play();
        yield return new WaitForSeconds(0.46f);
        if (text.enabled == true)
        {
            text.enabled = false;
        }
        else if (text.enabled == false){
            text.enabled = true;
        }
    }
}
