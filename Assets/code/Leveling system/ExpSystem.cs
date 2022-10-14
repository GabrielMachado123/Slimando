using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExpSystem : MonoBehaviour
{
    public TextMeshProUGUI currentExpText, expGoalText, currentPlayerLevelText;
    public int currentExp, goalExp, playerLevel;

    public static ExpSystem instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        currentExpText.text = "EXP: " + currentExp.ToString();
        expGoalText.text = "EXP GOAL: " + goalExp.ToString();
        currentPlayerLevelText.text = "Level: " + playerLevel.ToString();

    }

    public void GainExp(int exp)
    {
        currentExp += exp;

        if (currentExp >= goalExp)
        {
            currentExp -= goalExp;
            playerLevel++;
            goalExp += goalExp / 20;

            currentPlayerLevelText.text = "Level: " + playerLevel.ToString();
            expGoalText.text = "EXP GOAL: " + goalExp.ToString();
        }

        currentExpText.text = "EXP: " + currentExp.ToString();
    }
}
