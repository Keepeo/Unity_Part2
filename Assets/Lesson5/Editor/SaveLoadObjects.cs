using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class SaveLoadObjects
{
    [MenuItem("GeekBrains/Save Level Objects")]
    private static void SaveObjects()
    {
        var path = EditorUtility.SaveFilePanel("Select file", Application.dataPath, "LevelData", "xml");

        var objs = Object.FindObjectsOfType<GameObject>();
        var objsList = new List<SerializableGameObject>();

        foreach (var o in objs)
        {
            objsList.Add(new SerializableGameObject
            {
                PrefabName = o.name,
                Pos = o.transform.position,
                Rot = o.transform.rotation,
                Scale = o.transform.localScale
            });            
        }
        XMLSerializator.Save(objsList.ToArray(), path);
    }

    [MenuItem("GeekBrains/Load Level Objects")]
    private static void LoadObjects()
    {
        var path = EditorUtility.OpenFilePanel("Select file", Application.dataPath, "xml");
        var objs = XMLSerializator.Load(path);

        foreach (var o in objs)
        {
            var prefab = Resources.Load<GameObject>(o.PrefabName);
            var tempObj = Object.Instantiate(prefab, o.Pos, o.Rot);
            tempObj.transform.localScale = o.Scale;
            tempObj.name = o.PrefabName;
        }
    }
}
