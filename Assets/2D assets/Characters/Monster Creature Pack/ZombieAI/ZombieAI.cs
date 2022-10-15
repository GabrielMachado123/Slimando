using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    int hashAttl;
    int hashAttr;
    int hashAttDown;
    int hashAttUp;

    private Transform Target;
    private Rigidbody2D rb;
    private Animator anim;

    private bool isattacking = false;
    private bool isCollinding = false;

    private float speed = 5f;
    private Vector3 direction;


    void Start()
    {
        hashAttDown = Animator.StringToHash("AD");
        hashAttUp = Animator.StringToHash("AU");
        hashAttl = Animator.StringToHash("AL");
        hashAttr = Animator.StringToHash("AR");

        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


    }

    
    void Update()
    {
        if(!isCollinding)
        {
            direction = (Target.transform.position - transform.position).normalized;
            rb.velocity = direction * speed;
            anim.SetFloat("Horizontal", direction.x);
            anim.SetFloat("Vertical", direction.y);
        }
        else if(!isattacking)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            isattacking = true;

            if (direction.x > 0 && direction.y < 0.5 && direction.y > -0.5)
            {
                anim.SetTrigger(hashAttr);
            }
            else if(direction.x < 0 && direction.y < 0.5 && direction.y > -0.5)
            {
                anim.SetTrigger(hashAttl);
            }
            else if(direction.y > 0)
            {
                anim.SetTrigger(hashAttUp);
            }
            else
            {
                anim.SetTrigger(hashAttDown);
            }
        }
        
    }


    private void ResetVariables()
    {
        isattacking = false;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        anim.ResetTrigger(hashAttr);
        anim.ResetTrigger(hashAttl);
        anim.ResetTrigger(hashAttUp);
        anim.ResetTrigger(hashAttDown);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isCollinding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isCollinding = false;
        }
    }
}
