using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeInEffect : TextEffect {

    public float delayTimer;
    public float delta;
    IEnumerator cr;
    Color fullText;
    Color invisibleText;
    Text text;
   
    void Start () {
        cr = null;
        text = GetComponent<Text>();
        fullText = text.color;
        invisibleText = fullText;
        invisibleText.a = 0.0f;
	}

    public override void RunEffect()
    {
        if (cr != null)
        {
            StopCoroutine(cr);
        }
        cr = FadeInText();
        StartCoroutine(cr);       
    }

    IEnumerator FadeInText()
    {
        float timer = delayTimer;

        while (timer > 0)
        {     
                text.color = Color.Lerp(fullText, invisibleText, timer / delayTimer);
                yield return new WaitForSeconds(delta);
                Debug.Log("Fade-in coroutine running");
                timer -= delta;
        }
    }
}
