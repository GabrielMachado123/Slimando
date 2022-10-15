using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField]
    private Vector3 offset = new Vector3(0, 0, 10f);

    [SerializeField]
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    private Transform Target;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Target != null)
        {
            Vector3 targetposition = Target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetposition, ref velocity, smoothTime);
        }
    }
}
