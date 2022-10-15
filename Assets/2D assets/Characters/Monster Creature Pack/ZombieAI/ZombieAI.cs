using UnityEngine;



public class ZombieAI : MonoBehaviour
{
    public EnemyInfo enemyInfo;
    public Bucket bucket;

    int hashAttl;
    int hashAttr;
    int hashAttDown;
    int hashAttUp;
    int hashDieR;
    int hashDieL;

    private Transform Target;
    private Rigidbody2D rb;
    private Animator anim;

    private bool isattacking = false;
    private bool isCollinding = false;

    private float speed;
    private float damage;
    private float health;

    private bool disapear = false;

    private Vector3 direction;
    private Vector3 BP;

    void Start()
    {
        bucket.CreateZombie(gameObject);

        hashAttDown = Animator.StringToHash("AD");
        hashAttUp = Animator.StringToHash("AU");
        hashAttl = Animator.StringToHash("AL");
        hashAttr = Animator.StringToHash("AR");

        hashDieL = Animator.StringToHash("DL");
        hashDieR = Animator.StringToHash("DR");

        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        speed = enemyInfo.speed;
        damage = enemyInfo.damage;
        health = enemyInfo.health;

        BP = enemyInfo.GetBucketPosition();
    }

    
    void Update()
    {
            if (health < 0)
            {
            if (direction.x > 0)
            {
                anim.SetTrigger(hashDieR);
            }
            else
            {
                anim.SetTrigger(hashDieL);
            }

            if(disapear)
            {
                InBucket();
                transform.position = BP;
                bucket.PutInBucketZombie(gameObject);
            }

            }
           else if (!isCollinding)
            {
                direction = (Target.transform.position - transform.position).normalized;
                rb.velocity = direction * speed;
                anim.SetFloat("Horizontal", direction.x);
                anim.SetFloat("Vertical", direction.y);
            }
            else if (!isattacking)
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
        isCollinding = false;
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
        disapear = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isCollinding = true;
        }
        
        if(collision.gameObject.tag == "PlayerBullet")
        {
            float damage;
            damage = collision.gameObject.GetComponent<P_Bullet>().GetBulletDmg();

            health -= damage;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isCollinding = false;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
