using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float PlayerSpeed = 50f;

    //animator
    [SerializeField]
    private Animator animator;
    //input
    Vector2 movement;

    //dash variables
    public bool isdash = false;
    public float cooldown, dashforce, dashlength;

    private float dashtimer;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        SetAnime();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dashtimer = dashlength;
            Dashing();

        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isdash)
            rb.MovePosition(rb.position + (movement * PlayerSpeed) * Time.deltaTime);
        else
        {
            rb.AddForce(rb.position + (movement * dashforce) * Time.deltaTime);
        }
    }

    void Dashing()
    {
        if(dashtimer > 0)
        {
            dashtimer -= Time.deltaTime;
            isdash = true;
        }
        else
        {
            dashtimer = 0;
            rb.velocity = Vector2.zero;
            isdash = false;
        }


    }

    void SetAnime()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.SqrMagnitude());
    }

}
