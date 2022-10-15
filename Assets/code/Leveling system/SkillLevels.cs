using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillLevels : MonoBehaviour
{
    private int damageLevel, healthLevel, splitandoLevel, grenandoLevel, dashandoLevel, multiplandoLevel;
    private int damageNextLevel, healthNextLevel, splitandoNextLevel, grenandoNextLevel, dashandoNextLevel, multiplandoNextLevel;
    public TextMeshProUGUI damageLevelText, healthLevelText, splitandoLevelText, grenandoLevelText, dashandoLevelText, multiplandoLevelText;
    private bool isDashUnlocked, isGrenandoUnlocked, isMultiplandoUnlocked;

    public GameObject unlockDashButton, unlockGrenandoButton, unlockMultiplando;

    public HealthBar hpBar;
    public PlayerHealth hp;

    private void Start()
    {
        damageLevel = 1;
        healthLevel = 1;
        splitandoLevel = 1;
        grenandoLevel = 0;
        dashandoLevel = 0;
        multiplandoLevel = 0;

        damageNextLevel = 2;
        healthNextLevel = 2;
        splitandoNextLevel = 2;
        grenandoNextLevel = 1;
        dashandoNextLevel = 1;
        multiplandoNextLevel = 1;

        damageLevelText.text = "Level\n" + damageLevel.ToString() + " --> " + damageNextLevel.ToString();
        healthLevelText.text = "Level\n" + healthLevel.ToString() + " --> " + healthNextLevel.ToString();
        splitandoLevelText.text = "Level\n" + splitandoLevel.ToString() + " --> " + splitandoNextLevel.ToString();
        grenandoLevelText.text = "Level\n" + grenandoLevel.ToString() + " --> " + grenandoNextLevel.ToString();
        dashandoLevelText.text = "Level\n" + dashandoLevel.ToString() + " --> " + dashandoNextLevel.ToString();
        multiplandoLevelText.text = "Level\n" + multiplandoLevel.ToString() + " --> " + multiplandoNextLevel.ToString();
    }

    public void UnlockDashando()
    {
        if (isDashUnlocked == false)
        {
            isDashUnlocked = true;
            dashandoLevel = 1;
            unlockDashButton.SetActive(false);
            dashandoNextLevel = 2;
            dashandoLevelText.text = "Level\n" + dashandoLevel.ToString() + " --> " + dashandoNextLevel.ToString();
        }
    }

    public void UnlockGrenado()
    {
        if (isGrenandoUnlocked == false)
        {
            isGrenandoUnlocked = true;
            grenandoLevel = 1;
            unlockGrenandoButton.SetActive(false);
            grenandoNextLevel = 2;
            grenandoLevelText.text = "Level\n" + grenandoLevel.ToString() + " --> " + grenandoNextLevel.ToString();
        }
    }

    public void UnlockMultiplando()
    {
        if (isMultiplandoUnlocked == false) 
        { 
            isMultiplandoUnlocked = true;
            multiplandoLevel = 1;
            unlockMultiplando.SetActive(false);
            multiplandoNextLevel = 2;
            multiplandoLevelText.text = "Level\n" + multiplandoLevel.ToString() + " --> " + multiplandoNextLevel.ToString();
        }
    }

    public void LevelUpDamage()
    {
        damageLevel++;
        damageNextLevel = damageLevel + 1;

        damageLevelText.text = "Level\n" + damageLevel.ToString() + " --> " + damageNextLevel.ToString();
    }

    public void LevelUpHealth()
    {
        healthLevel++;
        healthNextLevel = healthLevel + 1;
        hp.P_IncreaseMaxHP(15f);
        hpBar.SetMaxHealth(hp.maxHealth += 15);
        hpBar.SetHealth(hp.currentHealth += 15);
        healthLevelText.text = "Level\n" + healthLevel.ToString() + " --> " + healthNextLevel.ToString();
    }

    public void LevelUpSplitando()
    {
        splitandoLevel++;
        splitandoNextLevel = splitandoLevel + 1;

        splitandoLevelText.text = "Level\n" + splitandoLevel.ToString() + " --> " + splitandoNextLevel.ToString();
    }

    public void LevelUpGrenando()
    {
        if (isGrenandoUnlocked == true)
        {
            grenandoLevel++;
            grenandoNextLevel = grenandoLevel + 1;

            grenandoLevelText.text = "Level\n" + grenandoLevel.ToString() + " --> " + grenandoNextLevel.ToString();
        }

    }

    public void LevelUpDashando()
    {
        if (isDashUnlocked == true)
        {
            dashandoLevel++;
            dashandoNextLevel = dashandoLevel + 1;

            dashandoLevelText.text = "Level\n" + dashandoLevel.ToString() + " --> " + dashandoNextLevel.ToString();
        }

    }

    public void LevelUpMultiplando()
    {
        if (isMultiplandoUnlocked == true)
        {
            multiplandoLevel++;
            multiplandoNextLevel = multiplandoLevel + 1;

            multiplandoLevelText.text = "Level\n" + multiplandoLevel.ToString() + " --> " + multiplandoNextLevel.ToString();
        }
    }
}
