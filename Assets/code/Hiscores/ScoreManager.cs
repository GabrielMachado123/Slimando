using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour
{

    private ScoreData scoreData;

    void Awake()
    {
        //var json = PlayerPrefs.GetString("times", "{}");
        scoreData = new ScoreData();
        //scoreData = JsonUtility.FromJson<ScoreData>(json);
    }

    public IEnumerable<Score> GetHighScores()
    {
        return scoreData.times.OrderByDescending(x => x.time); 
    }

    public void AddScore(Score time)
    {
        scoreData.times.Add(time);
    }

    /*private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {

        var json = JsonUtility.ToJson(scoreData);
        PlayerPrefs.SetString("times", json);
    }*/
}
