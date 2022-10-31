using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_grenade : MonoBehaviour
{
    private float g_dmg, g_timer, g_rad;

    private Rigidbody2D rb;
    public AudioSource source;
    public AudioClip clip;

    [SerializeField]
    private GameObject explosionEffect;
    private ShakeCameraControll shake;

    private ExpSystem XPsys;

    void Awake()
    {
        XPsys = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<ExpSystem>();
    }

    void FixedUpdate()
    {

        if (g_timer <= 0)
        {
            explode();
        }

        g_timer -= Time.deltaTime;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;

        if (col.transform.tag == "PlayerBullet")
        {
            explode();
        }

    }

    /*void OnCollisionEnter2D(Collision2D col)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;

        if (col.transform.tag == "PlayerBullet")
        {
            explode();
        }

    }*/

    public void SetGrenadeValues(float dmg, float timer, float radius,ShakeCameraControll shv)
    {
        g_timer = timer;
        g_dmg = dmg;
        g_rad = radius;
        shake = shv;
    }


    void explode()
    {
        source.PlayOneShot(clip);

        //explosion animation
        //shake.StartShake(0.3f, 0.7f, 0.7f);

        GameObject test = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(test, 0.5f);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, g_rad);

        int xp_acumulator = 0;

        foreach (Collider2D col in colliders)
        {
            xp_acumulator+=CheckEntity(col);
        }

        if(( XPsys.GetCurrentXP() + xp_acumulator) >= XPsys.GetGoalXP() )
        {
            Camera.main.GetComponent<ShakeCameraControll>().enabled = false;
        }
        else
        {
            Camera.main.GetComponent<ShakeCameraControll>().enabled = true;
            shake.StartShake(0.3f, 0.7f, 0.7f);
        }


        Destroy(this.gameObject);
    }

    int CheckEntity(Collider2D col)
    {


        if (col.gameObject.GetComponent<ZombieAI>() != null)
        {
            col.gameObject.GetComponent<ZombieAI>().TakeDamage(g_dmg);
            return col.gameObject.GetComponent<ZombieAI>().enemyInfo.XP;
        }
        else if(col.gameObject.GetComponent<WraithAI>() != null)
        {
            col.gameObject.GetComponent<WraithAI>().TakeDamage(g_dmg);
            return col.gameObject.GetComponent<WraithAI>().enemyInfo.XP;
        }
        else if (col.gameObject.GetComponent<FireSkullAI>() != null)
        {
            col.gameObject.GetComponent<FireSkullAI>().TakeDamage(g_dmg);
            return col.gameObject.GetComponent<FireSkullAI>().enemyInfo.XP;
        }
        else if(col.gameObject.GetComponent<MummyAI>() != null)
        {
            col.gameObject.GetComponent<MummyAI>().TakeDamage(g_dmg);
            return col.gameObject.GetComponent<MummyAI>().enemyInfo.XP;
        }
        else if (col.transform.CompareTag("Player"))//add in case new enemy
        {
            col.gameObject.GetComponent<PlayerHealth>().P_TakeDamage(Mathf.RoundToInt(g_dmg/3));
        }

        return 0;
    }



}
