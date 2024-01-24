using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[Serializable]
public class Saver : MonoBehaviour
{
    [SerializeField] private int HighScore;
    void Awake()
    {
        if (DataStore.Unloaded)
        {
            StreamReader reader = new StreamReader(Application.persistentDataPath+ "/save.json");
            JsonUtility.FromJsonOverwrite(reader.ReadToEnd(), this);
            reader.Close();
            DataStore.HighScore = HighScore;
            DataStore.Unloaded = false;
        }
    }

    // Update is called once per frame
    void OnDestroy()
    {
        Debug.Log("ran");
        HighScore = DataStore.HighScore;
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/save.json");
        writer.WriteLine(JsonUtility.ToJson(this));
        writer.Close();
    }
}
