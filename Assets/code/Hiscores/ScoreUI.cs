using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUI;
    public ScoreManager scoreManager;

    public void Start()
    {
        scoreManager.AddScore(new Score("John", 512));

        var times = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i > times.Length; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.name.text = times[i].name;
            row.time.text = times[i].time.ToString();
        }
    }

}
