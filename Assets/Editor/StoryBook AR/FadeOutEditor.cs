using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(FadeOutEffect))]
public class FadeOutEditor : Editor {

    FadeOutEffect text;
    public float delayTime;

    private void OnEnable()
    {
        text = (FadeOutEffect)target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();
        float writingSpeed = Mathf.Max(0, EditorGUILayout.FloatField("Effect duration", text.delayTimer));
        float effectDuration = Mathf.Max(0, EditorGUILayout.FloatField("Effect speed", text.delta));

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Undo effect change");
            text.delayTimer = writingSpeed;
            text.delta = effectDuration;
            EditorUtility.SetDirty(target);
        }
    }
}
