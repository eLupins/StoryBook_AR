using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dissolve2Script : MediaEffect
{


    public float delayTimer;
    public float delta;
    IEnumerator cr;
    //public Material shader;

    public GameObject media; //for sprites, 3d models, whatevers
    public Image img; //for UI images


    // Use this for initialization
    void Start()
    {
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


            while (timer > 0)
            {
                img.material.SetFloat("Vector1_1FB51D88", Mathf.Lerp(0.0f, 1.0f, timer / delayTimer));
                yield return new WaitForSeconds(delta);
                timer -= delta;
            }
        }

        if (media)
        {
            Renderer rend = media.GetComponent<Renderer>();

            while (timer > 0)
            {
                rend.material.SetFloat("Vector1_1FB51D88", Mathf.Lerp(0.0f, 1.0f, timer / delayTimer));
                yield return new WaitForSeconds(delta);
                timer -= delta;
            }
        }
    }
}