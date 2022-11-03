using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(InfinaDEMO))]
[CanEditMultipleObjects]

/**
 * ------------------------------------------------------------
 * Editor Panel for InfinadeckCore.
 * https://github.com/Infinadeck/InfinadeckUnityPlugin
 * Created by Griffin Brunner @ Infinadeck, 2019-2022
 * Attribution required.
 * ------------------------------------------------------------
 */

public class InfinaDEMOEditor : Editor
{
    SerializedProperty pluginVersion;

    SerializedProperty demoTime;
    SerializedProperty demoTimeRemaining;

    SerializedProperty holder;
    SerializedProperty DTRTextN;
    SerializedProperty DTRTextE;
    SerializedProperty DTRTextS;
    SerializedProperty DTRTextW;

    SerializedProperty keybinds;
    SerializedProperty myKeys;
    SerializedProperty keybindNames;
    SerializedProperty myTimerKeys;
    SerializedProperty keybindTimerNames;

    void OnEnable()
    {
        pluginVersion = serializedObject.FindProperty("pluginVersion");

        demoTime = serializedObject.FindProperty("demoTime");
        demoTimeRemaining = serializedObject.FindProperty("demoTimeRemaining");

        holder = serializedObject.FindProperty("holder");
        DTRTextN = serializedObject.FindProperty("DTRTextN");
        DTRTextE = serializedObject.FindProperty("DTRTextE");
        DTRTextS = serializedObject.FindProperty("DTRTextS");
        DTRTextW = serializedObject.FindProperty("DTRTextW");

        keybinds = serializedObject.FindProperty("keybinds");
        myKeys = serializedObject.FindProperty("myKeys");
        keybindNames = serializedObject.FindProperty("keybindNames");
        myTimerKeys = serializedObject.FindProperty("myTimerKeys");
        keybindTimerNames = serializedObject.FindProperty("keybindTimerNames");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.LabelField("Plugin Version " + pluginVersion.stringValue);
        if (holder.objectReferenceValue)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Key References");
        }
        EditorGUILayout.PropertyField(holder);

        if (holder.objectReferenceValue)
        {
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Optional Settings");
            EditorGUILayout.PropertyField(demoTime);
            EditorGUILayout.PropertyField(demoTimeRemaining);

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Advanced Settings");
            EditorGUILayout.PropertyField(DTRTextN);
            EditorGUILayout.PropertyField(DTRTextE);
            EditorGUILayout.PropertyField(DTRTextS);
            EditorGUILayout.PropertyField(DTRTextW);

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Keybind Settings");
            EditorGUILayout.PropertyField(keybinds);
            for (int b = 0; b < myKeys.arraySize; b++)
            {
                if (keybindNames.GetArrayElementAtIndex(b).stringValue != "")
                {
                    KeyCode key = (KeyCode)myKeys.GetArrayElementAtIndex(b).intValue;
                    EditorGUILayout.LabelField(key.ToString() + " to " + keybindNames.GetArrayElementAtIndex(b).stringValue);
                }
            }
            for (int b = 0; b < myTimerKeys.arraySize; b++)
            {
                if (keybindTimerNames.GetArrayElementAtIndex(b).stringValue != "")
                {
                    KeyCode key = (KeyCode)myTimerKeys.GetArrayElementAtIndex(b).intValue;
                    EditorGUILayout.LabelField(key.ToString() + " to " + keybindTimerNames.GetArrayElementAtIndex(b).stringValue);
                }
            }
        }
            
        serializedObject.ApplyModifiedProperties();
    }
}