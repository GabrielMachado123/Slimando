using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth, currentHealth;
    public HealthBar healthBar;

    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip clip;
    public GameObject deathScreen; 

    void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    void start()
    {
    }

    void LateUpdate()
    {
        if (currentHealth <= 0)
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
        Animator anim = GetComponentInChildren<Animator>();
        anim.SetBool("isDead", true);
        Debug.Log("death");
        //audio
        source.PlayOneShot(clip);

        Destroy(this.gameObject, 1f);

        StartCoroutine(ExecuteAfterTime(0.95f));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        deathScreen.SetActive(true);
    }
}
