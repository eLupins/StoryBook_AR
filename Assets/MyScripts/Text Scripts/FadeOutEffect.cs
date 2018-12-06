using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeOutEffect : TextEffect {
  
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
        cr = FadeOutText();
        StartCoroutine(cr);
    }

    IEnumerator FadeOutText()
    {
        float timer = delayTimer; 
        while(timer>0)
        {
            text.color = Color.Lerp(invisibleText, fullText, timer/delayTimer);
            yield return new WaitForSeconds(delta);
            timer -= delta;
        }
    }
}
