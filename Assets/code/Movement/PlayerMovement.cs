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
    public float beginDashTimer;
    public float dashSpeed;
    public float dashTimer;
    private int direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTimer = beginDashTimer;

    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        SetAnime();
    }

    void FixedUpdate()
    {

        rb.MovePosition(rb.position + (movement * PlayerSpeed) * Time.deltaTime);

        /*if (direction == 0)
        {
            if (Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.A)))
            {
                direction = 1;
                Debug.Log("Dashed");
            }
            else if (Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.D)))
            {
                direction = 2;
                Debug.Log("Dashed");
            }
            else if (Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.W)))
            {
                direction = 3;
                Debug.Log("Dashed");
            }
            else if (Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.S)))
            {
                direction = 4;
                Debug.Log("Dashed");
            }
        }
        else
        {
            if (dashTimer <= 0)
            {
                direction = 0;
                dashTimer = beginDashTimer;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTimer -= Time.deltaTime;

                if (direction == 1)
                {
                    rb.MovePosition(rb.position + Vector2.left) * dashSpeed;
                }
                else if (direction == 2)
                {
                    rb.MovePosition(rb.position + Vector2.right) * dashSpeed;
                }
                else if (direction == 3)
                {
                    rb.MovePosition(rb.position + Vector2.up) * dashSpeed;
                }
                else if (direction == 4)
                { 
                    rb.MovePosition(rb.position + Vector2.down) * dashSpeed;
                }
            }
        }*/
    }

    void SetAnime()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.SqrMagnitude());
    }

}
