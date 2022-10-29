using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCameraControll : MonoBehaviour
{

    [SerializeField]
    private float length, power, rotationMultiplier;
    private float StartTimeRemaining, ShakePower, ShakeFadeTimer, ShakeRotation;
    public GameMenager shake;

    void LateUpdate()
    {

        if (shake.cameraShakeState == true)
        {
            if (StartTimeRemaining > 0)
            {
                StartTimeRemaining -= Time.deltaTime;

                float xAmount = Random.Range(-1f, 1f) * ShakePower;
                float yAmount = Random.Range(-1f, 1f) * ShakePower;

                transform.position += new Vector3(xAmount, yAmount, 0f);

                ShakePower = Mathf.MoveTowards(ShakePower, 0f, ShakeFadeTimer * Time.deltaTime);

                ShakeRotation = Mathf.MoveTowards(ShakeRotation, 0f, ShakeFadeTimer * rotationMultiplier * Time.deltaTime);

            }
        }

        transform.rotation = Quaternion.Euler(0, 0, ShakeRotation * Random.Range(-1f, 1f));

    }

    public void StartShake(float length, float power , float rotateMult)
    {
        rotationMultiplier = rotateMult;
        StartTimeRemaining = length;
        ShakePower = power;

        ShakeFadeTimer = power / length;

        ShakeRotation = power * rotationMultiplier;
    }

}
