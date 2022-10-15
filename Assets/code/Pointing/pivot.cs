using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pivot : MonoBehaviour
{
    public GameObject player;

    void FixedUpdate()
    {

        Vector3 diferance = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diferance.Normalize();

        float rotationz = Mathf.Atan2(diferance.y, diferance.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotationz);

        if (rotationz < -90 || rotationz > 90)
        {

            if (player.transform.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotationz);
            }
            else if (player.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationz);
            }

        }

    }

}
