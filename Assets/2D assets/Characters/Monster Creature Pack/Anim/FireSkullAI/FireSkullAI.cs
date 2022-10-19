using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FireSkullAI : MonoBehaviour
{
    public EnemyInfo enemyInfo;
    private Bucket bucket;

    int hashAttl;
    int hashAttr;
    int hashAttDown;
    int hashAttUp;
    int hashDieR;
    int hashDieL;

    private Transform Target;
    private PlayerHealth playerHealth;
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D collider;

    private bool isattacking = false;
   

    private float speed;
    private float damage;
    private float health;


    private bool isdying = false;

    private Vector3 direction;
    private Vector3 BP;

    void Start()
    {
        bucket = GameObject.FindGameObjectWithTag("GameSpawner").GetComponent<Bucket>();

        hashAttDown = Animator.StringToHash("AD");
        hashAttUp = Animator.StringToHash("AU");
        hashAttl = Animator.StringToHash("AL");
        hashAttr = Animator.StringToHash("AR");

        hashDieL = Animator.StringToHash("DL");
        hashDieR = Animator.StringToHash("DR");
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        }
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();

        speed = enemyInfo.speed;
        damage = enemyInfo.damage;
        health = enemyInfo.health;

        BP = enemyInfo.GetBucketPosition();

    }


    void Update()
    {
        if (Target != null)
        {
            if (health < 0)
            {
                if (direction.x < 0 && isdying == false)
                {
                    isdying = true;
                    anim.SetTrigger(hashDieR);
                    ExpSystem.instance.GainExp(50);
                }
                else if (isdying == false)
                {
                    ExpSystem.instance.GainExp(50);
                    isdying = true;
                    anim.SetTrigger(hashDieL);
                }

                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                collider.enabled = false;
            }
            else if (!isattacking && (Vector3.Distance(transform.position, Target.transform.position) < 10))
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                isattacking = true;

                if (direction.x > 0 && direction.y < 0.5 && direction.y > -0.5)
                {
                    anim.SetTrigger(hashAttr);
                }
                else if (direction.x < 0 && direction.y < 0.5 && direction.y > -0.5)
                {
                    anim.SetTrigger(hashAttl);
                }
                else if (direction.y > 0)
                {
                    anim.SetTrigger(hashAttUp);
                }
                else
                {
                    anim.SetTrigger(hashAttDown);
                }
            }
            else
            {
                direction = (Target.transform.position - transform.position).normalized;
                rb.velocity = direction * speed;
                anim.SetFloat("Horizontal", direction.x);
                anim.SetFloat("Vertical", direction.y);
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

    public void InBucket()
    {
        isattacking = false;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        anim.ResetTrigger(hashAttr);
        anim.ResetTrigger(hashAttl);
        anim.ResetTrigger(hashAttUp);
        anim.ResetTrigger(hashAttDown);
        anim.ResetTrigger(hashDieR);
        anim.ResetTrigger(hashDieL);

        health = enemyInfo.health;

        gameObject.SetActive(false);
    }

    private void die()
    {
       
        InBucket();
        collider.enabled = true;
        transform.position = BP;
        bucket.PutInBucketFireSkull(gameObject);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        isdying = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "PlayerBullet")
        {

            float damage;
            damage = collision.gameObject.GetComponent<P_Bullet>().GetBulletDmg();

            health -= damage;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public GameObject bullPrefab;
    private int bullforce = 5;
    public void Shoot()
    {
        if(Target != null)
        {
            GameObject bull = Instantiate(bullPrefab, transform.position, Quaternion.identity);
            bull.GetComponent<FireBall>().SetDamage(damage);
            Rigidbody2D rbBull = bull.GetComponent<Rigidbody2D>();
            Vector3 direction = (Target.transform.position - transform.position).normalized;
            rbBull.velocity = direction * bullforce;           
        }
   
    }

}
