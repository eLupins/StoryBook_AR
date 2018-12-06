using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(FadeInEffect))]
public class FadeInEditor : Editor {

    FadeInEffect text;
    public float delayTime;

    private void OnEnable()
    {
        text = (FadeInEffect)target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();
        float writingSpeed = Mathf.Max(0, EditorGUILayout.FloatField("Effect duration", text.delayTimer));
        float effectDuration = Mathf.Max(0, EditorGUILayout.FloatField("Effect speed", text.delta));
        
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Change effect speed value");
            text.delayTimer = writingSpeed;
            text.delta = effectDuration;
            EditorUtility.SetDirty(target);
        }
    }
}
