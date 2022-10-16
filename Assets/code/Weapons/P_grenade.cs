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

    // Update is called once per frame
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
        Debug.DrawLine(test.transform.position, (test.transform.position + new Vector3(0,0,-3)) + new Vector3(g_rad, 0,0), Color.black, 3f);
        foreach (Collider2D col in colliders)
        {
            Debug.Log(col.gameObject.name);
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
        else if (col.transform.CompareTag("Player"))//add in case new enemy
        {
            Debug.Log("immagine blowing yourself up");
            col.gameObject.GetComponent<PlayerHealth>().P_TakeDamage( Mathf.RoundToInt(g_dmg/2) );
        }
        else
        {
            Debug.Log("this is dumb , but also check if you but in the new reference script of the enemy");
        }

    }



}
