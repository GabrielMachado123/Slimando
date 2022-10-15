using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetExpTest : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ExpSystem.instance.GainExp(25);
        }
    }
}
