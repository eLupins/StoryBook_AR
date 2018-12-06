using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TypewriterEffect))]
public class TypewriterEditor : Editor  {

    TypewriterEffect text;
    public float delayTime;

    private void OnEnable()
    {
        text = (TypewriterEffect)target;       
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck(); //monitors changes made to gui                          
        //matf.max caps the range of values so the user cannot input a negative value
        float writingSpeed = Mathf.Max(0, EditorGUILayout.FloatField("Effect speed", text.delayTimer));
        float effectDuration = Mathf.Max(0, EditorGUILayout.FloatField("Effect duration", text.delta));

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Change type speed value");
            text.delayTimer = writingSpeed;
            text.delta = effectDuration;
            EditorUtility.SetDirty(target); //dirty means that the component has been modified 
        }
    }
}

