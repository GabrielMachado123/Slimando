using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenades : MonoBehaviour
{

    public GameObject bullPrefab;
    public Transform firepoint;
    private Vector2 mousePos;

    public float GDmg, GRadius, GCooldown, GTimer, GForce;

    public float firerate = 3f, nextfire = 0f;

    private ShakeCameraControll shv;

    public SkillLevels unlock;
    public GameObject unlockInfoText;

    void Awake()
    {
        shv = Camera.main.GetComponent<ShakeCameraControll>();
    }


    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse1) && Time.time > nextfire)//left click
        {
            nextfire = Time.time + firerate;
            AtiraGrenade();
        }
    }

    void AtiraGrenade()
    {
        if (unlock.isGrenandoUnlocked == true)
        {
            Vector3 normalizer = new Vector3(0f, 0f, -90f);
            GameObject grena = Instantiate(bullPrefab, firepoint.position, Quaternion.Euler(firepoint.rotation.eulerAngles + normalizer));
            grena.GetComponent<P_grenade>().SetGrenadeValues(GDmg, GTimer, GForce, shv);
            Rigidbody2D rbBull = grena.GetComponent<Rigidbody2D>();
            rbBull.AddForce((grena.transform.up * GForce), ForceMode2D.Impulse);
        }
        else
        {
            unlockInfoText.SetActive(true);
            StartCoroutine(ExecuteAfterTime(2));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        unlockInfoText.SetActive(false);
    }
 }
