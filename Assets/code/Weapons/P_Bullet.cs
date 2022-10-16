using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Bullet : MonoBehaviour
{
    private float bulletDMG;

    [SerializeField]
    private GameObject trail;

    public void SetBulletDMG( float dmg)
    {
        bulletDMG = dmg;
    }

    public float GetBulletDmg()
    {
        return bulletDMG;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);
    }

}
