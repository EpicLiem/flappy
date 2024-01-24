using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public static class DataStore
{
    public static int HighScore { get; set; } = 0;
    public static bool Unloaded { get; set; } = true;
}
