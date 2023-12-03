using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTriggerHandler : MonoBehaviour
{
    public bool isLeverDown = false;
    public AudioSource audioSource;

    private void Update()
    {
        if (transform.rotation.eulerAngles.x > 35 && !isLeverDown) 
        {
            isLeverDown = true;
            audioSource.Play();
        }
    }
}
