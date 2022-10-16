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
    public float cooldown=3f, dashforce, dashlength=0.5f;

    [SerializeField]
    private float dashtimer,Cooldownholder=0f;

    [SerializeField]
    private AnimationCurve AC;

    public SkillLevels unlock;
    public GameObject unlockInfoText;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        SetAnime();

        if (Input.GetKeyDown(KeyCode.Space) )
        {
            if (unlock.isDashUnlocked == true)
            {
                Dashing();
            }
            else
            {
                unlockInfoText.SetActive(true);
                StartCoroutine(ExecuteAfterTime(2));
            }
        }
            Cooldownholder -= Time.deltaTime;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isdash)
            rb.MovePosition(rb.position + (movement * PlayerSpeed) * Time.deltaTime);
        else
        {
            dashtimer += Time.fixedDeltaTime;

            Vector3 dir = transform.position+new Vector3(movement.x,movement.y,0).normalized * dashforce;
            rb.position = Vector3.Lerp(transform.position,dir , AC.Evaluate(dashtimer/10));
            
            if(dashtimer > dashlength)
            {
                Cooldownholder = cooldown;
                dashtimer = 0;
                isdash = false;
            }

        }
    }

    void Dashing()
    {
        if (Cooldownholder < 0)
        {
            isdash = true;
        }
    }

    void SetAnime()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.SqrMagnitude());
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        unlockInfoText.SetActive(false);
    }
}
