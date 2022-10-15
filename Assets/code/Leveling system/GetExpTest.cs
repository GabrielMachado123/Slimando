using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetExpTest : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown("space") && (ExpSystem.instance.isLevelUpPanelOpen == false))
        {
            ExpSystem.instance.GainExp(25);
        }
    }
}
