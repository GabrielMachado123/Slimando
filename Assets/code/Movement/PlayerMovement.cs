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

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.SqrMagnitude());

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movement * PlayerSpeed) * Time.deltaTime);
    }

    Animator GetAnimator()
    {
        return animator;
    }
}
