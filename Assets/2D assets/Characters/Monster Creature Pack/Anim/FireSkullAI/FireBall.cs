using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float power;
    private int hashExplosion;
    private Animator anim;
    private Rigidbody2D rb;


    private void Start()
    {
        hashExplosion = Animator.StringToHash("Explode");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().P_TakeDamage(power);
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
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        anim.SetTrigger(hashExplosion);
    }
}
