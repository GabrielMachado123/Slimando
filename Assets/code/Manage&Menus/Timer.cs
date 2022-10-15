using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timer, currentTime;

    public TextMeshProUGUI currentTimer;

    void Update()
    {
        timer += Time.deltaTime;
        currentTime = Mathf.Round(timer);
        currentTimer.text = currentTime.ToString();
    }
}