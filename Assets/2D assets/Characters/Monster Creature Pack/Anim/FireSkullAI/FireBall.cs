using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float power;
    private int hashExplosion;
    private Animator anim;


    private void Start()
    {
        hashExplosion = Animator.StringToHash("Explode");
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<PlayerHealth>().P_TakeDamage(power);
        }

        Explode();

    }

    public void SetDamage(float damage)
    {
        power = damage;
    }

    private void disapear()
    {
        Destroy(this.gameObject);
    }

    private void Explode()
    {
        anim.SetTrigger(hashExplosion);
    }
}
