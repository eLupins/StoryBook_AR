using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;

[System.Serializable]
public class StoryBookAR : EditorWindow {

    private Canvas canvas;
    private GameObject media;
    private GameObject text;
    private Image img;
    private Material mat;

    [SerializeField]
    private bool applyTypewriter = false;
    private bool applyFadein = false;
    private bool applyFadeout = false;

    [MenuItem("Window/StoryBook AR")]
    public static void CreateWizard()
    {
        EditorWindow.GetWindow(typeof(StoryBookAR));       
    }


    private void OnGUI()
    {
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.Space();

        /*
        * 
        * ALL IMAGE RELATED STUFF HANDLED BELOW THE CUT
        *The user will simply choose the shader of their choice, drop it into the object field and use the button to assign the shader.
        *Using toggles to choose between different shaders proved to not be a useful way to assign shaders to game objects.
        * Scripts to handle the shader animation during game mode... leave the user to add the script component themselves?
        * Or add toggles to have the user choose the proper script?
        * 
        */

        EditorGUILayout.LabelField("Image effects", EditorStyles.boldLabel);

        EditorGUILayout.HelpBox("To apply shader effects to your image or game object, please put it in the appropriate field below. Then select a shader material and put it in the appropriate field below. Pre-made shaders will also come with a script. Imported or custom shaders will not have scripts applied since there aren't any pre-made scripts available.", MessageType.Info);
        EditorGUILayout.Space();
        img = (Image)EditorGUILayout.ObjectField("Image content", img, typeof(Image), true);
        media = (GameObject)EditorGUILayout.ObjectField("Media content", media, typeof(GameObject), true);
        mat = (Material)EditorGUILayout.ObjectField("Material", mat, typeof(Material), true);
        EditorGUILayout.Space();
        if (GUILayout.Button("Apply shader"))
        {    
            /*
             * 
             * This section handles shaders for image objects
             * 
             */

            if (img)
            {
                img.material = mat;
                GameObject go = img.gameObject;

                if (mat.name == "bubble")
                {
                    if (go.GetComponent<bubbleScript>() == null)
                    {
                        go.AddComponent<bubbleScript>();
                    }
                }

                else if (mat.name == "checkerboard")
                {
                    if (go.GetComponent<checkerboardScript>() == null)
                    {
                        go.AddComponent<checkerboardScript>();
                    }
                }

                else if (mat.name == "corrode")
                {
                    if (go.GetComponent<corrodeScript>() == null)
                    {
                        go.AddComponent<corrodeScript>(); 
                    }
                }

                else if (mat.name == "dissolve1")
                {
                    if (go.GetComponent<dissolve1Script>() == null)
                    {
                        go.AddComponent<dissolve1Script>();
                    }
                }

                else if (mat.name == "Dissolve2")
                {
                    if (go.GetComponent<dissolve2Script>() == null)
                    {
                        go.AddComponent<dissolve2Script>();
                    }
                }

                else if (mat.name == "frost")
                {
                    if (go.GetComponent<frostScript>() == null)
                    {
                        go.AddComponent<frostScript>();
                    }
                }

                else if (mat.name == "lines")
                {
                    if (go.GetComponent<linesScript>() == null)
                    {
                        go.AddComponent<linesScript>();
                    }
                }

                else
                {
                    return;
                }

                EditorUtility.SetDirty(img);
            }

            /*
             * 
             * This section handles shaders for other applicable gameobjects
             * 
             */

            if (media)
            {
                Renderer rend = media.GetComponent<Renderer>();
                rend.material = mat;

                if (mat.name == "bubble")
                {
                    if (media.GetComponent<bubbleScript>() == null)
                    {
                        media.AddComponent<bubbleScript>();
                    }
                }

                else if (mat.name == "checkerboard")
                {
                    if (media.GetComponent<checkerboardScript>() == null)
                    {
                        media.AddComponent<checkerboardScript>();
                    }
                }

                else if (mat.name == "corrode")
                {
                    if (media.GetComponent<corrodeScript>() == null)
                    {
                        media.AddComponent<corrodeScript>();
                    }
                }

                else if (mat.name == "dissolve1")
                {
                    if (media.GetComponent<dissolve1Script>() == null)
                    {
                        media.AddComponent<dissolve1Script>();
                    }
                }

                else if (mat.name == "Dissolve2")
                {
                    if (media.GetComponent<dissolve2Script>() == null)
                    {
                        media.AddComponent<dissolve2Script>();
                    }
                }

                else if (mat.name == "frost")
                {
                    if (media.GetComponent<frostScript>() == null)
                    {
                        media.AddComponent<frostScript>();
                    }
                }

                else if (mat.name == "lines")
                {
                    if (media.GetComponent<linesScript>() == null)
                    {
                        media.AddComponent<linesScript>();
                    }
                }

                else
                {
                    return;
                }
                EditorUtility.SetDirty(media);
            }
        }

        /*
        * 
        * TEXT IMAGE RELATED STUFF HANDLED BELOW THE CUT
        * The user will simply use toggles to assign scripts to their text UI.
        * Toggles will be added to the window as additional effects are produced. 
        * 
        */

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Text UI", EditorStyles.boldLabel);
        EditorGUILayout.HelpBox("This section handles applying visual effects to text objects. Drop the text object that you'd like to apply a visual effect to below. To apply effects, use the toggles.", MessageType.Info);
        EditorGUILayout.Space();
        text = (GameObject)EditorGUILayout.ObjectField("Text", text, typeof(GameObject), true);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Text effects", EditorStyles.boldLabel);


        /////////////////////////// TYPEWRITER FX ////////////////////////////   
        applyTypewriter = EditorGUILayout.ToggleLeft("Apply typewriter", applyTypewriter);
        if (text)
        {
            if (applyTypewriter == true)
            {
                try
                {
                    if (text.GetComponent<TypewriterEffect>() == null)
                    {
                        text.AddComponent<TypewriterEffect>();
                        EditorUtility.SetDirty(text);
                    }
                }
                catch (UnassignedReferenceException e)
                {

                }
            }

            if (applyTypewriter == false)
            {
                try
                {
                    TypewriterEffect removing = text.GetComponent<TypewriterEffect>();
                    DestroyImmediate(removing);
                    EditorUtility.SetDirty(text);
                }
                catch (UnassignedReferenceException e)
                {

                }
            }
        }

        /////////////////////////// FADE-IN FX ////////////////////////////  

        applyFadein = EditorGUILayout.ToggleLeft("Apply fade-in", applyFadein);
        if (text)
        {
            if (applyFadein == true)
            {
                if (text.GetComponent<FadeInEffect>() == null)
                {
                    text.AddComponent<FadeInEffect>();
                    EditorUtility.SetDirty(text);
                }
            }

            if (applyFadein == false)
            {
                try
                {
                    FadeInEffect removing = text.GetComponent<FadeInEffect>();
                    DestroyImmediate(removing);
                    EditorUtility.SetDirty(text);
                }
                catch (UnassignedReferenceException e)
                {

                }
            }
        }

        /////////////////////////// FADE-OUT FX ////////////////////////////  

        applyFadeout = EditorGUILayout.ToggleLeft("Apply fade-out", applyFadeout);
        if (text)
        {
            if (applyFadeout == true)
            {
                if (text.GetComponent<FadeOutEffect>() == null)
                {
                    text.AddComponent<FadeOutEffect>();
                    EditorUtility.SetDirty(text);
                }
            }
            if (applyFadeout == false)
            {
                try
                {
                    FadeOutEffect removing = text.GetComponent<FadeOutEffect>();
                    DestroyImmediate(removing);
                    EditorUtility.SetDirty(text);
                }
                catch (UnassignedReferenceException e)
                {

                }
            }
        }
    }

    private void OnWizardCreate()
    {
        GameObject go = new GameObject("TextObj");
        Text txt = go.AddComponent<Text>();
    }
}
