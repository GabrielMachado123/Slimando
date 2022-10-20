using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Score
{
    public string name;
    public float time;

    public Score (string name, float time)
    {
        this.name = name;
        this.time = time;
    }
}
