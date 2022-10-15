using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenades : MonoBehaviour
{

    public GameObject bullPrefab;
    public Transform firepoint;
    private Vector2 mousePos;

    public float GDmg,GRadius, GCooldown, GTimer, GForce;


    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse1))//left click
        {
            AtiraGrenade();
        }
    }

    void AtiraGrenade()
    {
        Vector3 normalizer = new Vector3(0f, 0f, -90f);
        GameObject grena = Instantiate(bullPrefab, firepoint.position, Quaternion.Euler(firepoint.rotation.eulerAngles + normalizer));
        grena.GetComponent<P_grenade>().SetGrenadeValues(GDmg,GTimer,GForce);
        Rigidbody2D rbBull = grena.GetComponent<Rigidbody2D>();
        rbBull.AddForce((grena.transform.up * GForce), ForceMode2D.Impulse);
    }
}
