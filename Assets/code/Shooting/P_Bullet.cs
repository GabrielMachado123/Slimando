using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Bullet : MonoBehaviour
{
    private float bulletDMG; 

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);
    }

}
