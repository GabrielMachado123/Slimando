using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExpSystem : MonoBehaviour
{
    public TextMeshProUGUI currentPlayerLevelText, expJointText;
    private int currentExp, goalExp, playerLevel;
    public Slider expSlider;
    public GameObject levelUpPanel;
    public bool isLevelUpPanelOpen;

    public PlayerHealth hp;
    public HealthBar hpBar;

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
        goalExp = 100;
        playerLevel = 1;
        currentPlayerLevelText.text = "Level: " + playerLevel.ToString();
        expJointText.text = currentExp.ToString() + " / " + goalExp.ToString();

        expSlider.value = currentExp;
        expSlider.maxValue = goalExp;

    }

    public void GainExp(int exp)
    {
        if (isLevelUpPanelOpen == false)
        {
            currentExp += exp;
        }

        if (currentExp >= goalExp)
        {
            currentExp -= goalExp;
            playerLevel++;
            hp.currentHealth = hp.maxHealth;
            hpBar.SetHealth(hp.maxHealth);
            goalExp += goalExp / 20;
            ShowLevelUpPanel();
            currentPlayerLevelText.text = "Level: " + playerLevel.ToString();

            expSlider.maxValue = goalExp;
        }

        expSlider.value = currentExp;
        expJointText.text = currentExp.ToString() + " / " + expSlider.maxValue;
    }

    public void ShowLevelUpPanel()
    {
        Time.timeScale = 0;
        isLevelUpPanelOpen = true;

        if (isLevelUpPanelOpen == true)
            levelUpPanel.SetActive(true);
    }

    public void CloseLevelUpPanel()
    {
        Time.timeScale = 1;
        isLevelUpPanelOpen = false;

        if (isLevelUpPanelOpen == false)
            levelUpPanel.SetActive(false);
    }
}
