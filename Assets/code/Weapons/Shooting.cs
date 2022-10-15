using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bullPrefab;
    public Transform firepoint;
    public float bullSpread ,bullforce, bullRange, numBull, bullDmg;


    public bool isMultishoot = false;
    private Vector2 mousePos;

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //lazy stuff idc
        if (Input.GetKeyDown(KeyCode.Mouse0))//left click
        {
            if (!isMultishoot)
                Shoot();
            else
                Multishoot();
        }

    }

    void FixedUpdate()
    {
        Vector2 lookdir = mousePos - new Vector2(firepoint.position.x, firepoint.position.y);
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg;

    }

    void Shoot()
    {
        Vector3 normalizer = new Vector3(0f, 0f, -90f);
        GameObject bull = Instantiate(bullPrefab, firepoint.position, Quaternion.Euler(firepoint.rotation.eulerAngles + normalizer));
        bull.GetComponent<P_Bullet>().SetBulletDMG(bullDmg);
        Rigidbody2D rbBull = bull.GetComponent<Rigidbody2D>();
        rbBull.AddForce((bull.transform.up * bullforce), ForceMode2D.Impulse);

        Destroy(bull, 8f);
    }

    void Multishoot()
    {
        float bullet_force = bullforce;
        float total_spread = bullet_force * 2;
        float angle_adder = total_spread / numBull;
        float uni_rot = -bullSpread;

        if(numBull >= 3)
        {
            for(int i=0;i<numBull;i++ )
            {
                //this makes it always shoot to the front
                Vector3 normalizer = new Vector3(0f,0f,-90f);
                //saves the new rotation for each bullet
                Vector3 spread_v = new Vector3(0,0,uni_rot);
                //associating an instatiating bullet to a varible for later use
                GameObject bullet = Instantiate(bullPrefab,firepoint.position,Quaternion.Euler(firepoint.rotation.eulerAngles + spread_v+normalizer));
                bullet.GetComponent<P_Bullet>().SetBulletDMG(bullDmg);
                //getting the ridged body of sayd bullet to detect colisions
                Rigidbody2D bull_rb = bullet.GetComponent<Rigidbody2D>();
                bullet.GetComponent<P_Bullet>().SetBulletDMG(bullDmg);
                //adding a force or a velocity + direction for the bulets to have movement;
                bull_rb.AddForce((bullet.transform.up * bullet_force), ForceMode2D.Impulse);
                //increment rotation of bullet
                uni_rot += angle_adder;
                Destroy(bullet, 8f);
            }//end for loop for each bullet

        }
        else
        {
            for(int i=0;i<2;i++ )
            {
                //this makes it always shoot to the front
                Vector3 normalizer = new Vector3(0f,0f,-90f);
                //saves the new rotation for each bullet
                Vector3 spread_v = new Vector3(0,0,uni_rot);
                //associating an instatiating bullet to a varible for later use
                GameObject bullet = Instantiate(bullPrefab,firepoint.position,Quaternion.Euler(firepoint.rotation.eulerAngles + spread_v+normalizer));
                bullet.GetComponent<P_Bullet>().SetBulletDMG(bullDmg);
                //getting the ridged body of sayd bullet to detect colisions
                Rigidbody2D bull_rb = bullet.GetComponent<Rigidbody2D>();
                bullet.GetComponent<P_Bullet>().SetBulletDMG(bullDmg);
                //adding a force or a velocity + direction for the bulets to have movement;
                bull_rb.AddForce((bullet.transform.up * bullet_force), ForceMode2D.Impulse);
                //changes the bullets spread to its original value
                Destroy(bullet, 8f);
                uni_rot = bullSpread;
            }//end for loop for each bullet
        }

    }

}
