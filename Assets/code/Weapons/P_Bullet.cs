using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Bullet : MonoBehaviour
{
    private float bulletDMG;

    private int MaxPierce,CountPierce = 0;

    public void SetBulletDMG(float dmg)
    {
        bulletDMG = dmg;
    }

    public void SetBulletPierce(int pierce)
    {
        MaxPierce = pierce;
    }

    public float GetBulletDmg()
    {
        return bulletDMG;
    }

    void LateUpdate()
    {
        if(CountPierce == MaxPierce)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Walls")
        {
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("hit");
            CountPierce += 1;
        }
    }

}
