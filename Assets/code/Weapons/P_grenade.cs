using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_grenade : MonoBehaviour
{
    private float g_dmg, g_timer, g_rad;

    private Rigidbody2D rb;

    [SerializeField]
    private GameObject explosionEffect;

    private ShakeCameraControll shake;

    void FixedUpdate()
    {

        if (g_timer <= 0)
        {
            explode();
        }

        g_timer -= Time.deltaTime;

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;

        if (col.transform.tag == "PlayerBullet")
        {
            explode();
        }

    }

    public void SetGrenadeValues(float dmg, float timer, float radius,ShakeCameraControll shv)
    {
        g_timer = timer;
        g_dmg = dmg;
        g_rad = radius;
        shake = shv;
    }


    void explode()
    {
        //explosion animation
        shake.StartShake(0.3f, 0.7f, 0.7f);
        GameObject test = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(test, 0.5f);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, g_rad);
        
        foreach (Collider2D col in colliders)
        {
          
            CheckEntity(col);
        }
        Destroy(this.gameObject);
    }

    void CheckEntity(Collider2D col)
    {

        if (col.gameObject.GetComponent<ZombieAI>() != null)
        {
            col.gameObject.GetComponent<ZombieAI>().TakeDamage(g_dmg);
        }
        else if(col.gameObject.GetComponent<WraithAI>() != null)
        {
            col.gameObject.GetComponent<WraithAI>().TakeDamage(g_dmg);
        }
        else if (col.gameObject.GetComponent<FireSkullAI>() != null)
        {
            col.gameObject.GetComponent<FireSkullAI>().TakeDamage(g_dmg);
        }
        else if (col.transform.CompareTag("Player"))//add in case new enemy
        {
            
            col.gameObject.GetComponent<PlayerHealth>().P_TakeDamage( Mathf.RoundToInt(g_dmg/2) );
        }
    }



}
