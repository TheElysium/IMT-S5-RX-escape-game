using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidController : MonoBehaviour
{
    public AudioSource audioSource;
    private bool isStarted = false;

    public void StartDroid()
    {
        if (isStarted) return;
        audioSource.Play();
        isStarted = true;
    }
}
