using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkerboardScript : MediaEffect {

    public float delayTimer;
    public float delta;
    IEnumerator cr;

    public GameObject media;
    public Image img;


	// Use this for initialization
	void Start () {
        cr = null;	
	}

    public override void RunShader()
    {
        if (cr != null)
        {
            StopCoroutine(cr);
        }

        cr = shaderEffect();
        StartCoroutine(cr);
    }

    IEnumerator shaderEffect()
    {
        float timer = delayTimer;

        if (img)
        {
            while(timer > 0)
            {
                img.material.SetFloat("Vector1_8F9F926E", Mathf.Lerp(0.0f, 1.0f, timer / delayTimer));
                yield return new WaitForSeconds(delta);
                timer -= delta;
            }
        }

        if (media)
        {
            Renderer rend = media.GetComponent<Renderer>();

            while(timer > 0)
            {
                rend.material.SetFloat("Vector1_8F9F926E", Mathf.Lerp(0.0f, 1.0f, timer / delayTimer));
                yield return new WaitForSeconds(delta);
                timer -= delta;
            }
        }
    }
}
