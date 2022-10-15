using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillLevels : MonoBehaviour
{
    public int damageLevel, healthLevel, splitandoLevel, grenandoLevel, dashandoLevel, multiplandoLevel;
    public int damageNextLevel, healthNextLevel, splitandoNextLevel, grenandoNextLevel, dashandoNextLevel, multiplandoNextLevel;
    public TextMeshProUGUI damageLevelText, healthLevelText, splitandoLevelText, grenandoLevelText, dashandoLevelText, multiplandoLevelText;
    public bool isDashUnlocked, isGrenandoUnlocked, isMultiplandoUnlocked;

    public GameObject unlockDashButton, unlockGrenandoButton, unlockMultiplando;

    public static SkillLevels instance;

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

        damageLevelText.text = damageLevel.ToString() + " --> " + damageNextLevel.ToString();
        healthLevelText.text = healthLevel.ToString() + " --> " + healthNextLevel.ToString();
        splitandoLevelText.text = splitandoLevel.ToString() + " --> " + splitandoNextLevel.ToString();
        grenandoLevelText.text = grenandoLevel.ToString() + " --> " + grenandoNextLevel.ToString();
        dashandoLevelText.text = dashandoLevel.ToString() + " --> " + dashandoNextLevel.ToString();
        multiplandoLevelText.text = multiplandoLevel.ToString() + " --> " + multiplandoNextLevel.ToString();
    }

    public void UnlockDashando()
    {
        isDashUnlocked = true;
        dashandoLevel = 1;
        unlockDashButton.SetActive(false);
        dashandoNextLevel = 2;
        dashandoLevelText.text = dashandoLevel.ToString() + " --> " + dashandoNextLevel.ToString();
    }

    public void UnlockGrenado()
    {
        isGrenandoUnlocked = true;
        grenandoLevel = 1;
        unlockGrenandoButton.SetActive(false);
        grenandoNextLevel = 2;
        grenandoLevelText.text = grenandoLevel.ToString() + " --> " + grenandoNextLevel.ToString();
    }

    public void UnlockMultiplando()
    {
        isMultiplandoUnlocked = true;
        multiplandoLevel = 1;
        unlockMultiplando.SetActive(false);
        multiplandoNextLevel = 2;
        multiplandoLevelText.text = multiplandoLevel.ToString() + " --> " + multiplandoNextLevel.ToString();
    }

    public void LevelUpDamage()
    {
        damageLevel++;
        damageNextLevel = damageLevel + 1;

        damageLevelText.text = damageLevel.ToString() + " --> " + damageNextLevel.ToString();
    }

    public void LevelUpHealth()
    {
        healthLevel++;
        healthNextLevel = healthLevel + 1;

        healthLevelText.text = healthLevel.ToString() + " --> " + healthNextLevel.ToString();
    }

    public void LevelUpSplitando()
    {
        splitandoLevel++;
        splitandoNextLevel = splitandoLevel + 1;

        splitandoLevelText.text = splitandoLevel.ToString() + " --> " + splitandoNextLevel.ToString();
    }

    public void LevelUpGrenando()
    {
        if (isGrenandoUnlocked == true)
        {
            grenandoLevel++;
            grenandoNextLevel = grenandoLevel + 1;

            grenandoLevelText.text = grenandoLevel.ToString() + " --> " + grenandoNextLevel.ToString();
        }

    }

    public void LevelUpDashando()
    {
        if (isDashUnlocked == true)
        {
            dashandoLevel++;
            dashandoNextLevel = dashandoLevel + 1;

            dashandoLevelText.text = dashandoLevel.ToString() + " --> " + dashandoNextLevel.ToString();
        }

    }

    public void LevelUpMultiplando()
    {
        if (isMultiplandoUnlocked == true)
        {
            multiplandoLevel++;
            multiplandoNextLevel = multiplandoLevel + 1;

            multiplandoLevelText.text = multiplandoLevel.ToString() + " --> " + multiplandoNextLevel.ToString();
        }
    }
}
