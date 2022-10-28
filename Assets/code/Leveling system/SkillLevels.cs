using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillLevels : MonoBehaviour
{
    private int damageLevel, healthLevel, splitandoLevel, grenandoLevel, dashandoLevel, multiplandoLevel;
    private int damageNextLevel, healthNextLevel, splitandoNextLevel, grenandoNextLevel, dashandoNextLevel, multiplandoNextLevel;

    public TextMeshProUGUI[] upgardeText = new TextMeshProUGUI[6];
    // [0] - damageLevelText || [1] - healthLevelText || [2] - splitandoLevelText
    // [3] - grenandoLevelText || [4] - dashandoLevelText  || [5] - multiplandoLevelText

    public bool isDashUnlocked, isGrenandoUnlocked, isMultiplandoUnlocked;

    public GameObject[] unlock = new GameObject[3];
    // [0] - unlockDashButton || [1] - unlockGrenandoButton || [2] - unlockMultiplando

    public GameObject[] upgrade = new GameObject[4];
    // [0] - upgradeButtonSplitando || [1] - upgradeButtonDash || [2] - upgradeButtonGrenando || [3] - upgradeButtonMultiplando

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

        upgardeText[0].text = "Level\n" + damageLevel.ToString() + " --> " + damageNextLevel.ToString();
        upgardeText[1].text = "Level\n" + healthLevel.ToString() + " --> " + healthNextLevel.ToString();
        upgardeText[2].text = "Level\n" + splitandoLevel.ToString() + " --> " + splitandoNextLevel.ToString();
        upgardeText[3].text = "Level\n" + grenandoLevel.ToString() + " --> " + grenandoNextLevel.ToString();
        upgardeText[4].text = "Level\n" + dashandoLevel.ToString() + " --> " + dashandoNextLevel.ToString();
        upgardeText[5].text = "Level\n" + multiplandoLevel.ToString() + " --> " + multiplandoNextLevel.ToString();
    }

    public void UnlockDashando()
    {
        if (isDashUnlocked == false)
        {
            isDashUnlocked = true;
            dashandoLevel = 1;
            unlock[0].SetActive(false);
            dashandoNextLevel = 2;
            upgardeText[4].text = "Level\n" + dashandoLevel.ToString() + " --> " + dashandoNextLevel.ToString();
        }
    }

    public void UnlockGrenado()
    {
        if (isGrenandoUnlocked == false)
        {
            isGrenandoUnlocked = true;
            grenandoLevel = 1;
            unlock[1].SetActive(false);
            grenandoNextLevel = 2;
            upgardeText[3].text = "Level\n" + grenandoLevel.ToString() + " --> " + grenandoNextLevel.ToString();
        }
    }

    public void UnlockMultiplando()
    {
        if (isMultiplandoUnlocked == false) 
        { 
            isMultiplandoUnlocked = true;
            multiplandoLevel = 1;
            unlock[2].SetActive(false);
            multiplandoNextLevel = 2;
            upgardeText[5].text = "Level\n" + multiplandoLevel.ToString() + " --> " + multiplandoNextLevel.ToString();
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
        upgardeText[0].text = "Level\n" + damageLevel.ToString() + " --> " + damageNextLevel.ToString();
    }

    public void LevelUpHealth()
    {
        healthLevel++;
        healthNextLevel = healthLevel + 1;
        hp.P_IncreaseMaxHP(15f);
        hpBar.SetMaxHealth(hp.maxHealth += 15);
        hpBar.SetHealth(hp.maxHealth);
        upgardeText[1].text = "Level\n" + healthLevel.ToString() + " --> " + healthNextLevel.ToString();
    }

    public void LevelUpSplitando()
    {
        splitandoLevel++;
        splitandoNextLevel = splitandoLevel + 1;
        dmg.SetBulletDMG(shoot.bullDmg += 5);
        upgardeText[2].text = "Level\n" + splitandoLevel.ToString() + " --> " + splitandoNextLevel.ToString();
        shoot.firerate -= 0.025f;
        if (splitandoLevel == 8)
        {
            upgardeText[2].text = "Level\n" + splitandoLevel.ToString();
            upgrade[0].SetActive(false);
        }
    } 

    public void LevelUpGrenando()
    {
        if (isGrenandoUnlocked == true)
        {
            grenandoLevel++;
            grenandoNextLevel = grenandoLevel + 1;
            grenade.firerate -= 0.15f;
            grenade.GDmg += 10;
            upgardeText[3].text = "Level\n" + grenandoLevel.ToString() + " --> " + grenandoNextLevel.ToString();

            if (grenandoLevel == 8)
            {
                upgardeText[3].text = "Level\n" + grenandoLevel.ToString();
                upgrade[2].SetActive(false);
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
            upgardeText[4].text = "Level\n" + dashandoLevel.ToString() + " --> " + dashandoNextLevel.ToString();

            if (dashandoLevel == 5)
            {
                upgardeText[4].text = "Level\n" + dashandoLevel.ToString();
                upgrade[1].SetActive(false);
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
            upgardeText[5].text = "Level\n" + multiplandoLevel.ToString() + " --> " + multiplandoNextLevel.ToString();

            if (multiplandoLevel == 3)
            {
                upgardeText[5].text = "Level\n" + multiplandoLevel.ToString();
                upgrade[3].SetActive(false);
            }
        }
    }
}
