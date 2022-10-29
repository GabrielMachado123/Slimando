using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timer;
    public int currentTime;

    public TextMeshProUGUI currentTimer;

    void Update()
    {
        timer += Time.deltaTime;
        currentTime = Mathf.RoundToInt(timer);
        currentTimer.text = currentTime.ToString();
    }
}