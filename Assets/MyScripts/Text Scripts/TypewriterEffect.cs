using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;


public class TypewriterEffect : TextEffect
{
    public float delayTimer;
    public Text text;
    string entry;
    IEnumerator cr;
    public float delta;

    public void Start()
    {
        text = GetComponent<Text>();
        entry = text.text;
        text.text = "";
        cr = null;
    }

    public override void RunEffect()
    {
        if(cr != null)
        {
            StopCoroutine(cr);
        }
        cr = WriteText();
        StartCoroutine(cr);
    }

    IEnumerator WriteText()
    {
        while (delayTimer > 0)
        {
            foreach (char i in entry)
            {
                Debug.Log("Starting Typewriter coroutine");
                text.text += i;
                yield return new WaitForSeconds(delta);
                delayTimer -= delta;


            }
        }
    }
}
