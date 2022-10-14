using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float PlayerSpeed = 50f;


    //input
    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movement * PlayerSpeed) * Time.deltaTime);
    }
}
