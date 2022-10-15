using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bullPrefab;
    public Transform firepoint;
    public float bullforce, bullRange, numBull;

    private Vector2 mousePos;

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //lazy stuff idc
        if(Input.GetKeyDown(KeyCode.Mouse0))//left click
        {
            Shoot();
        }

    }

    void FixedUpdate()
    {
        Vector2 lookdir = mousePos - new Vector2(firepoint.position.x,firepoint.position.y);
        float angle = Mathf.Atan2(lookdir.y,lookdir.x) * Mathf.Rad2Deg;
        
    }
    
    void Shoot()
    {
        Vector3 normalizer = new Vector3(0f,0f,-90f);
        GameObject bull = Instantiate(bullPrefab,firepoint.position,Quaternion.Euler(firepoint.rotation.eulerAngles+normalizer));
        //GameObject bull = Instantiate(bullPrefab,firepoint.position,firepoint.rotation);
        Rigidbody2D rbBull = bull.GetComponent<Rigidbody2D>();
        rbBull.AddForce((bull.transform.up * bullforce),ForceMode2D.Impulse);
    }

}
