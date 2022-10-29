using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth, currentHealth;
    public PlayFabManager playfabManager;
    private bool isDead;
    public HealthBar healthBar;
    public GameObject deathScreen;
    public AudioSource source;
    public AudioClip clip;

    public TextMeshProUGUI slimeLevel, timeSurvived;

    public Timer score;


    void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        isDead = false;
    }

    void start()
    {
    }

    void LateUpdate()
    {
        if(currentHealth <= 0)
        {
            P_Death();
        }
    }

    public void P_IncreaseMaxHP(float moreHP)
    {
        maxHealth += moreHP;
        currentHealth += moreHP;
    }

    public void P_TakeDamage(float DMG)
    {
        currentHealth -= DMG;
        healthBar.SetHealth(currentHealth);
    }

    void P_Death()
    {
        if (isDead == false)
        {
            isDead = true;
            source.PlayOneShot(clip);
            Animator anim = GetComponentInChildren<Animator>();
            anim.SetBool("isDead", true);
            playfabManager.SendLeaderboard(score.currentTime);
            Debug.Log(score.currentTime);
            Destroy(this.gameObject, 1f);
            StartCoroutine(ExecuteAfterTime(0.95f));
            slimeLevel.text = ExpSystem.instance.playerLevel.ToString();
            timeSurvived.text = score.currentTime.ToString();
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        deathScreen.SetActive(true);
    }
}
