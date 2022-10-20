using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ScoreData
{

    public List<Score> times;

    public ScoreData()
    {
        times = new List<Score>();
    }
}
