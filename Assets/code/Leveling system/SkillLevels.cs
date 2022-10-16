using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillLevels : MonoBehaviour
{
    private int damageLevel, healthLevel, splitandoLevel, grenandoLevel, dashandoLevel, multiplandoLevel;
    private int damageNextLevel, healthNextLevel, splitandoNextLevel, grenandoNextLevel, dashandoNextLevel, multiplandoNextLevel;
    public TextMeshProUGUI damageLevelText, healthLevelText, splitandoLevelText, grenandoLevelText, dashandoLevelText, multiplandoLevelText;
    public bool isDashUnlocked, isGrenandoUnlocked, isMultiplandoUnlocked;

    public GameObject unlockDashButton, unlockGrenandoButton, unlockMultiplando;
    public GameObject upgradeButtonSplitando, upgradeButtonDash, upgradeButtonGrenando, upgradeButtonMultiplando;

    public HealthBar hpBar;
    public PlayerHealth hp;

    public P_Bullet dmg;
    public Shooting shoot;

    public Grenades grenade;

    public PlayerMovement dash;

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
            shoot.numBull += 1;
            shoot.isMultishoot = true;
        }
    }

    public void LevelUpDamage()
    {
        damageLevel++;
        damageNextLevel = damageLevel + 1;
        dmg.SetBulletDMG(shoot.bullDmg += 2);
        grenade.GDmg += 2;
        damageLevelText.text = "Level\n" + damageLevel.ToString() + " --> " + damageNextLevel.ToString();
    }

    public void LevelUpHealth()
    {
        healthLevel++;
        healthNextLevel = healthLevel + 1;
        hp.P_IncreaseMaxHP(15f);
        hpBar.SetMaxHealth(hp.maxHealth += 15);
        hpBar.SetHealth(hp.maxHealth);
        healthLevelText.text = "Level\n" + healthLevel.ToString() + " --> " + healthNextLevel.ToString();
    }

    public void LevelUpSplitando()
    {
        splitandoLevel++;
        splitandoNextLevel = splitandoLevel + 1;
        dmg.SetBulletDMG(shoot.bullDmg += 5);
        splitandoLevelText.text = "Level\n" + splitandoLevel.ToString() + " --> " + splitandoNextLevel.ToString();
        shoot.firerate -= 0.025f;
        if (splitandoLevel == 8)
        {
            splitandoLevelText.text = "Level\n" + splitandoLevel.ToString();
            upgradeButtonSplitando.SetActive(false);
        }
    } 

    public void LevelUpGrenando()
    {
        if (isGrenandoUnlocked == true)
        {
            grenandoLevel++;
            grenandoNextLevel = grenandoLevel + 1;
            grenade.firerate -= 0.15f;
            grenade.GDmg += 40;
            grenandoLevelText.text = "Level\n" + grenandoLevel.ToString() + " --> " + grenandoNextLevel.ToString();

            if (grenandoLevel == 8)
            {
                grenandoLevelText.text = "Level\n" + grenandoLevel.ToString();
                upgradeButtonGrenando.SetActive(false);
            }
        }

    }

    public void LevelUpDashando()
    {
        if (isDashUnlocked == true)
        {
            dashandoLevel++;
            dashandoNextLevel = dashandoLevel + 1;
            dash.cooldown -= 0.5f;
            dashandoLevelText.text = "Level\n" + dashandoLevel.ToString() + " --> " + dashandoNextLevel.ToString();

            if (dashandoLevel == 5)
            {
                dashandoLevelText.text = "Level\n" + dashandoLevel.ToString();
                upgradeButtonDash.SetActive(false);
            }
        }

    }

    public void LevelUpMultiplando()
    {
        if (isMultiplandoUnlocked == true)
        {
            multiplandoLevel++;
            multiplandoNextLevel = multiplandoLevel + 1;
            shoot.numBull += 1;
            multiplandoLevelText.text = "Level\n" + multiplandoLevel.ToString() + " --> " + multiplandoNextLevel.ToString();

            if (multiplandoLevel == 3)
            {
                multiplandoLevelText.text = "Level\n" + multiplandoLevel.ToString();
                upgradeButtonMultiplando.SetActive(false);
            }
        }
    }
}
