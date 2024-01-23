using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    [SerializeField] private int HighScore;
    void Awake()
    {
        DataStore.HighScore = HighScore;
    }

    // Update is called once per frame
    void OnPreCull()
    {
        HighScore = DataStore.HighScore;
    }
}
