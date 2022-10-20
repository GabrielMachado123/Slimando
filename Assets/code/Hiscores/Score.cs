using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Score
{
    public int level;
    public float time;

    public Score (int level, float time)
    {
        this.level = level;
        this.time = time;
    }
}
