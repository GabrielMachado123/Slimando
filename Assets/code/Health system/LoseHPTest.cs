using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseHPTest : MonoBehaviour
{

    public PlayerHealth hp;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            hp.P_TakeDamage(25f);
        }
    }
}
