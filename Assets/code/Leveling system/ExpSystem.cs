using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExpSystem : MonoBehaviour
{
    public TextMeshProUGUI currentPlayerLevelText, expJointText;
    public int currentExp, goalExp, playerLevel;
    public Slider expSlider;

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
        currentPlayerLevelText.text = "Level: " + playerLevel.ToString();
        expJointText.text = currentExp.ToString() + " / " + goalExp.ToString();

        expSlider.value = currentExp;
        expSlider.maxValue = goalExp;

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

            expSlider.maxValue = goalExp;
        }

        expSlider.value = currentExp;
        expJointText.text = currentExp.ToString() + " / " + expSlider.maxValue;
    }
}
