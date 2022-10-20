using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUI;
    public ScoreManager scoreManager;

    void Start()
    {
        scoreManager.AddScore(new Score(67, 512));
        scoreManager.AddScore(new Score(10, 125));
        scoreManager.AddScore(new Score(1, 3));

        var times = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i > times.Length; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.level.text = times[i].level.ToString();
            row.time.text = times[i].time.ToString();
        }
    }
}
