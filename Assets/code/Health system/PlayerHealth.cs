using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth, currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void LateUpdate()
    {

        if(currentHealth <= 0)
        {
            P_Death();
        }

    }

    void P_TakeDamage(float DMG)
    {
        currentHealth -= DMG;
    }

    void P_Death()
    {
        Animator anim = GetComponentInChildren<Animator>();
        anim.SetBool("isDead", true);

        Destroy(this.gameObject, 0.5f);

    }


}
