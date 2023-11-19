using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTriggerHandler : MonoBehaviour
{
    public bool isLeverDown = false;
    private void Update()
    {
        if (transform.rotation.eulerAngles.x > 35) 
        {
            isLeverDown = true;
        }
        else { isLeverDown = false; }
    }
}
