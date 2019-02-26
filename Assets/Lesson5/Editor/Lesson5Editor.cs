using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Lesson5))]
public class Lesson5Editor : Editor
{
    bool isButtonPressed;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var les5 = (Lesson5)target;

        if (GUILayout.Button("Спаун объектов", EditorStyles.miniButton))
        {
            les5.CreatObj();
            isButtonPressed = true;
        }

        if (isButtonPressed)
        {
            EditorGUILayout.HelpBox("Кнопка нажата", MessageType.Warning);
        }
    }
}
