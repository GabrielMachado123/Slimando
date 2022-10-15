using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_grenade : MonoBehaviour
{
    private float g_dmg, g_timer, g_rad;

    private Rigidbody2D rb;

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
    }

    public void SetGrenadeValues(float dmg, float timer, float radius)
    {
        g_timer = timer;
        g_dmg = dmg;
        g_rad = radius;
    }


    void explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, g_rad);

        foreach (Collider2D col in colliders)
        {
            CheckEntity(col);
        }

        Destroy(this.gameObject);

    }

    void CheckEntity(Collider2D col)
    {

    }



}
