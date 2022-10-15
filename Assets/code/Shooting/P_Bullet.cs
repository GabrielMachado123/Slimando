using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Bullet : MonoBehaviour
{
    private float bulletDMG; 

    public void SetBulletDMG( float dmg)
    {
        bulletDMG = dmg;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);
    }

}
