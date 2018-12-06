using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ImageShift : MediaEffect {

    public GameObject target;
    public Material[] images;
    public Renderer rend;
    public Material startMat;
    public float delayTimer;
    public float delta;
    public float speakingTime;
    IEnumerator cr;
    float timer = 0.0f;
    public float tester;
    private void Start()
    {

        rend = GetComponent<Renderer>();
        StartCoroutine(Shift());
          
    }

    public override void RunShader()
    {
        Debug.Log("Running imageShift script");
        if (cr != null)
        {
            StopCoroutine(cr);
        }
        cr = Shift();
        StartCoroutine(cr);
    }

    IEnumerator Shift()
    {
        Debug.Log("Running Shift");
        

        foreach (Material img in images)
        {
            Debug.Log("Running foreach loop");
            
            timer = 0.0f;
            while (timer < 1)
            {
                tester = timer / delayTimer;

                Debug.Log("Whileloop");
                rend.material.Lerp(rend.material, img, timer/delayTimer);
                Debug.Log(tester);
                timer += delta;
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
